Imports System.Runtime.InteropServices

Public Class frmConfig
    <System.Runtime.InteropServices.DllImportAttribute("user32.dll")> _
        Private Shared Function DestroyIcon(ByVal handle _
     As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")> Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential)> Structure LASTINPUTINFO
        <MarshalAs(UnmanagedType.U4)> Public cbSize As Integer
        <MarshalAs(UnmanagedType.U4)> Public dwTime As Integer
    End Structure

    Dim lastInputInf As New LASTINPUTINFO()

    Dim currentStatus As DeskStatus
    Dim activityStart As New DateTime  'When did the last period of activity start?
    Dim activeTime As New TimeSpan()   'How long has the user been active?

    Private BalloonOpen As Boolean = False

    Dim idleResetTime As Integer = 300  '5 minutes
    Dim timeLimit As New TimeSpan(0, 60, 0) '1 hour
    Dim breakLimit As New TimeSpan(0, 5, 0)

    Dim privateFonts As New System.Drawing.Text.PrivateFontCollection()

    Private Sub frmConfig_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                activityStart = activityStart.AddMinutes(-1)
                MakeIcon()
            Case Keys.F2
                Status = DeskStatus.Standing
                MakeIcon()
        End Select
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = 1000
        Timer1.Start()

        activityStart = NowNearestSecond()
        Status = DeskStatus.Idle

        'load the font into memory.
        ' create an unsafe memory block for the font data
        Dim data As IntPtr = Marshal.AllocCoTaskMem(My.Resources.MunroNarrow.Length)

        ' copy the bytes to the unsafe memory block
        Marshal.Copy(My.Resources.MunroNarrow, 0, data, My.Resources.MunroNarrow.Length)

        ' pass the font to the font collection
        privateFonts.AddMemoryFont(data, My.Resources.MunroNarrow.Length)

        ' free up the unsafe memory
        Marshal.FreeCoTaskMem(data)

        'Draw a tray icon.
        MakeIcon()


        ComboBox1.SelectedIndex = 1
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Tray.Visible = False
        Tray.Dispose()
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lastInputInf.cbSize = Marshal.SizeOf(lastInputInf)
        lastInputInf.dwTime = 0
        GetLastInputInfo(lastInputInf)
        'Label1.Text = CInt((Environment.TickCount - lastInputInf.dwTime) / 1000).ToString
        If CInt((Environment.TickCount - lastInputInf.dwTime) / 1000) > idleResetTime Then 'check if the user is idle.
            activityStart = NowNearestSecond() 'Reset the activity timer.

            If Status <> DeskStatus.Idle Then
                Status = DeskStatus.Idle
                Debug.Print("Entered idle")
                MakeIcon()
            End If
        ElseIf Not (CInt((Environment.TickCount - lastInputInf.dwTime) / 1000) > idleResetTime) And Status = DeskStatus.Idle Then
            Status = DeskStatus.Sitting
            MakeIcon()
            Debug.Print("Left idle")
        End If

        activeTime = NowNearestSecond().Subtract(activityStart)
        lblActiveTime.Text = activeTime.ToString
        lblIdleTime.Text = New TimeSpan(0, 0, CInt((Environment.TickCount - lastInputInf.dwTime) / 1000)).ToString

        'Redo the icon once a minute.
        If activeTime.Seconds < 2 And Not Status = DeskStatus.Idle Then MakeIcon()

        'Check if it's break time.
        Select Case Status
            Case DeskStatus.Break, DeskStatus.Standing
                If breakLimit.Subtract(activeTime).TotalSeconds <= 0 Then
                    activityStart = NowNearestSecond()
                    Status = DeskStatus.Idle
                End If
            Case Else

                If timeLimit.Subtract(activeTime).TotalSeconds <= 0 Then

                    If ComboBox1.SelectedIndex = 1 Then PlayAlert(True) Else PlayAlert(False)
                    Status = DeskStatus.Break
                    activityStart = NowNearestSecond()

                    Tray.BalloonTipTitle = "Take a break or stand up!"
                    Tray.BalloonTipText = "You have " & breakLimit.TotalMinutes.ToString & " minutes"
                    Tray.ShowBalloonTip(5000)
                End If
        End Select


    End Sub

    Private Sub Tray_BalloonTipClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tray.BalloonTipClosed
        BalloonOpen = False
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Tray_BalloonTipShown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tray.BalloonTipShown
        BalloonOpen = True
    End Sub

    Private Sub Tray_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tray.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub Tray_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tray.MouseClick
        Select Case Status
            Case DeskStatus.Break, DeskStatus.Standing
                Tray.BalloonTipText = "Resume sitting in: " & breakLimit.Subtract(activeTime).ToString
            Case Else
                Tray.BalloonTipText = "Next break in: " & timeLimit.Subtract(activeTime).ToString

        End Select


        If e.Button = Windows.Forms.MouseButtons.Left Then
            Tray.BalloonTipTitle = DeskStr(currentStatus)
            Tray.ShowBalloonTip(3000)
        End If

        My.Computer.Audio.Stop()
    End Sub

    Private Sub Tray_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tray.MouseMove

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        timeLimit = New TimeSpan(0, nudLimit.Value, 0)
        breakLimit = New TimeSpan(0, nudBreak.Value, 0)
        idleResetTime = nudTimeout.Value

        Me.Hide()
        My.Computer.Audio.Stop()
    End Sub


    Private Sub MakeIcon()

        ' Create a Bitmap. 
        Dim myBitmap As New Bitmap(16, 16, Imaging.PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(myBitmap)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Draw to the bitmap.
        g.FillEllipse(New SolidBrush(Color.FromArgb(220, 220, 220)), 0, 0, 15, 15)


        Dim protoB As Color = Color.FromArgb(128, Color.Aquamarine)
        Dim protoP As Color = Color.Blue

        Select Case Status
            Case DeskStatus.Break
                protoB = SwapChannel(protoB, True, True, False)
                protoP = SwapChannel(protoP, True, False, True)

            Case DeskStatus.Standing
                protoB = SwapChannel(protoB, True, False, True)
                protoP = SwapChannel(protoP, False, True, True)
            Case DeskStatus.Idle
                protoP = Color.Orchid
        End Select

        Dim brush As New SolidBrush(protoB)  'Progress brush
        Dim pen As New Pen(protoP)

        Dim output As String
        Dim percent As Long
        Select Case Status
            Case DeskStatus.Break, DeskStatus.Standing
                output = (breakLimit.Subtract(activeTime).Minutes + 1).ToString()
                percent = (activeTime.Ticks / breakLimit.Ticks) * 360
            Case DeskStatus.Idle
                output = "Zz"
                percent = 0
            Case Else
                output = (timeLimit.Subtract(activeTime).Minutes + 1).ToString()
                percent = (activeTime.Ticks / timeLimit.Ticks) * 360
        End Select


        g.FillPie(brush, 0, 0, 15, 15, 0, percent)

        g.DrawEllipse(pen, 0, 0, 15, 15)

        If timeLimit.Subtract(activeTime).TotalMinutes >= 60 Then g.FillEllipse(brush, 12, 12, 3, 3)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim font As New Font(privateFonts.Families(0), 9)

        g.DrawString(output, font, New SolidBrush(Color.FromArgb(64, Color.Black)), 9, 9, stringFormat)
        g.DrawString(output, font, Brushes.Black, 8, 8, stringFormat)

        ' Get an Hicon for myBitmap. 
        Dim HIcon As IntPtr = myBitmap.GetHicon()

        ' Create a new icon from the handle. 
        Dim newIcon As Icon = System.Drawing.Icon.FromHandle(HIcon)

        ' Set the Icon attribute to the new icon. 
        Tray.Icon = newIcon.Clone()

        ' You can now destroy the icon, since the form creates its  
        ' own copy of the icon accessible through the Form.Icon property.
        DestroyIcon(newIcon.Handle)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub frmConfig_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Visible = False
    End Sub

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        PlayAlert()
    End Sub

    Private Sub btnOpenSnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenSnd.Click
        Dim dlg As New OpenFileDialog()
        dlg.Filter = "Wave files (*.wav)|*.wav|All Files|*"
        Dim result As DialogResult = dlg.ShowDialog(Me)

        If result = Windows.Forms.DialogResult.OK Then lblSnd.Text = dlg.FileName
    End Sub

    Private Function DeskStr(ByVal val As DeskStatus) As String

        Select Case val
            Case DeskStatus.Idle
                Return "Idle"
            Case DeskStatus.Sitting
                Return "Sitting down"
            Case DeskStatus.Standing
                Return "Standing up"
            Case DeskStatus.Break
                Return "On break"
            Case Else
                Return "Unknown"
        End Select

    End Function

    Private Function DeskColor(ByVal val As DeskStatus) As Color
        Select Case val
            Case DeskStatus.Idle, DeskStatus.Sitting
                Return Color.FromArgb(192, 192, 255)
            Case DeskStatus.Break
                Return Color.FromArgb(255, 192, 192)
            Case DeskStatus.Standing
                Return Color.FromArgb(192, 255, 192)

        End Select
    End Function

    Private Property Status() As DeskStatus
        Get
            Return currentStatus
        End Get
        Set(ByVal value As DeskStatus)
            'If value = currentStatus Then Exit Property
            currentStatus = value

            Tray.Text = "Status: " & DeskStr(currentStatus)
            mnuStatus2.Text = DeskStr(currentStatus)

            Select Case currentStatus
                Case DeskStatus.Break
                    mnuStatus.Image = imgStatus.Images("Break")
                Case DeskStatus.Standing
                    mnuStatus.Image = imgStatus.Images("Standing")
                Case Else
                    mnuStatus.Image = imgStatus.Images("Idle")
            End Select
            mnuStatus.BackColor = DeskColor(currentStatus)
        End Set
    End Property

    Private Function NowNearestSecond() As DateTime
        Dim out As DateTime = DateTime.Now
        out = out.AddTicks(-(out.Ticks Mod TimeSpan.TicksPerSecond))  'Round to the nearest second.
        Return out
    End Function

    Private Sub PlayAlert(Optional ByVal looping As Boolean = False)
        If looping = True Then
            Try
                My.Computer.Audio.Play(lblSnd.Text, AudioPlayMode.BackgroundLoop)

            Catch ex As Exception
                My.Computer.Audio.Play(My.Resources.DefaultSound, AudioPlayMode.BackgroundLoop)
            End Try

        Else
            Try
                My.Computer.Audio.Play(lblSnd.Text, AudioPlayMode.Background)

            Catch ex As Exception
                My.Computer.Audio.Play(My.Resources.DefaultSound, AudioPlayMode.Background)
            End Try
        End If
    End Sub

    Private Sub lblSnd_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lblSnd.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        lblSnd.Text = files(0)
    End Sub

    Private Sub lblSnd_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lblSnd.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub


    Private Function SwapChannel(ByVal col As Color, Optional ByVal r As Boolean = False, Optional ByVal g As Boolean = False, Optional ByVal b As Boolean = False) As Color
        Dim r2, g2, b2 As Integer

        If r = True And g = True And b = True Then
            r2 = col.B
            g2 = col.R
            b2 = col.G

        ElseIf r = True And g = True Then
            r2 = col.G
            g2 = col.R
            b2 = col.B
        ElseIf r = True And b = True Then
            r2 = col.B
            g2 = col.G
            b2 = col.R
        ElseIf g = True And b = True Then
            r2 = col.R
            g2 = col.B
            b2 = col.G
        Else
            r2 = col.R
            g2 = col.G
            b2 = col.B
        End If

        Return Color.FromArgb(r2, g2, b2)
    End Function

    Private Sub mnuStatus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuStatus2.Click
        If Status = DeskStatus.Break Then
            Status = DeskStatus.Standing
            MakeIcon()
        ElseIf Status = DeskStatus.Standing Then
            Status = DeskStatus.Break
            MakeIcon()
        End If
    End Sub
End Class


Enum DeskStatus
    Break = -1
    Idle = 0
    Sitting = 1
    Standing = 2
End Enum


