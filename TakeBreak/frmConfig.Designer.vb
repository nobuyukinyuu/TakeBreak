<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblActiveTime = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.nudBreak = New System.Windows.Forms.NumericUpDown
        Me.nudLimit = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.Tray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuStatus = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStatus2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ConfigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lblSnd = New System.Windows.Forms.Label
        Me.btnOpenSnd = New System.Windows.Forms.Button
        Me.btnPlay = New System.Windows.Forms.Button
        Me.imgStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.nudTimeout = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblIdleTime = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.nudBreak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.nudTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'lblActiveTime
        '
        Me.lblActiveTime.AutoSize = True
        Me.lblActiveTime.Location = New System.Drawing.Point(80, 208)
        Me.lblActiveTime.Name = "lblActiveTime"
        Me.lblActiveTime.Size = New System.Drawing.Size(49, 13)
        Me.lblActiveTime.TabIndex = 1
        Me.lblActiveTime.Text = "00:00:00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(331, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Take a                   minute break every                    minutes."
        '
        'nudBreak
        '
        Me.nudBreak.Location = New System.Drawing.Point(72, 32)
        Me.nudBreak.Name = "nudBreak"
        Me.nudBreak.Size = New System.Drawing.Size(40, 20)
        Me.nudBreak.TabIndex = 3
        Me.nudBreak.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'nudLimit
        '
        Me.nudLimit.Location = New System.Drawing.Point(240, 32)
        Me.nudLimit.Maximum = New Decimal(New Integer() {720, 0, 0, 0})
        Me.nudLimit.Name = "nudLimit"
        Me.nudLimit.Size = New System.Drawing.Size(48, 20)
        Me.nudLimit.TabIndex = 4
        Me.nudLimit.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Active Time:"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(16, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 2)
        Me.Label1.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 39)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Default:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sound File: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Notification Style"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Play a sound once", "Play a sound continuously"})
        Me.ComboBox1.Location = New System.Drawing.Point(112, 144)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(184, 21)
        Me.ComboBox1.TabIndex = 9
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(272, 216)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(88, 24)
        Me.btnOk.TabIndex = 11
        Me.btnOk.Text = "&Okay"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Tray
        '
        Me.Tray.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Tray.Icon = CType(resources.GetObject("Tray.Icon"), System.Drawing.Icon)
        Me.Tray.Text = "Status: Sitting down"
        Me.Tray.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStatus, Me.mnuStatus2, Me.ToolStripMenuItem1, Me.ConfigToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 104)
        '
        'mnuStatus
        '
        Me.mnuStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.mnuStatus.Font = New System.Drawing.Font("Tahoma", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuStatus.Name = "mnuStatus"
        Me.mnuStatus.Size = New System.Drawing.Size(184, 22)
        Me.mnuStatus.Text = "Current Status"
        '
        'mnuStatus2
        '
        Me.mnuStatus2.Font = New System.Drawing.Font("Tahoma", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuStatus2.Name = "mnuStatus2"
        Me.mnuStatus2.Size = New System.Drawing.Size(184, 22)
        Me.mnuStatus2.Text = "Sitting Down"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 6)
        '
        'ConfigToolStripMenuItem
        '
        Me.ConfigToolStripMenuItem.Image = CType(resources.GetObject("ConfigToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem"
        Me.ConfigToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ConfigToolStripMenuItem.Text = "&Config"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(181, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'lblSnd
        '
        Me.lblSnd.AllowDrop = True
        Me.lblSnd.AutoEllipsis = True
        Me.lblSnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSnd.Location = New System.Drawing.Point(112, 168)
        Me.lblSnd.Name = "lblSnd"
        Me.lblSnd.Size = New System.Drawing.Size(184, 20)
        Me.lblSnd.TabIndex = 12
        Me.lblSnd.Text = "(default)"
        '
        'btnOpenSnd
        '
        Me.btnOpenSnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOpenSnd.Image = CType(resources.GetObject("btnOpenSnd.Image"), System.Drawing.Image)
        Me.btnOpenSnd.Location = New System.Drawing.Point(304, 168)
        Me.btnOpenSnd.Name = "btnOpenSnd"
        Me.btnOpenSnd.Size = New System.Drawing.Size(32, 20)
        Me.btnOpenSnd.TabIndex = 13
        Me.btnOpenSnd.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPlay.Image = CType(resources.GetObject("btnPlay.Image"), System.Drawing.Image)
        Me.btnPlay.Location = New System.Drawing.Point(336, 168)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(24, 20)
        Me.btnPlay.TabIndex = 14
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'imgStatus
        '
        Me.imgStatus.ImageStream = CType(resources.GetObject("imgStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.imgStatus.Images.SetKeyName(0, "Idle")
        Me.imgStatus.Images.SetKeyName(1, "Break")
        Me.imgStatus.Images.SetKeyName(2, "Standing")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Timespan"
        '
        'nudTimeout
        '
        Me.nudTimeout.Location = New System.Drawing.Point(168, 64)
        Me.nudTimeout.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nudTimeout.Name = "nudTimeout"
        Me.nudTimeout.Size = New System.Drawing.Size(72, 20)
        Me.nudTimeout.TabIndex = 16
        Me.nudTimeout.Value = New Decimal(New Integer() {240, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(297, 16)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Idle timeout begins after                               seconds."
        '
        'lblIdleTime
        '
        Me.lblIdleTime.AutoSize = True
        Me.lblIdleTime.Location = New System.Drawing.Point(80, 224)
        Me.lblIdleTime.Name = "lblIdleTime"
        Me.lblIdleTime.Size = New System.Drawing.Size(49, 13)
        Me.lblIdleTime.TabIndex = 18
        Me.lblIdleTime.Text = "00:00:00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 224)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Idle Time:"
        '
        'frmConfig
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 243)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblIdleTime)
        Me.Controls.Add(Me.nudTimeout)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.btnOpenSnd)
        Me.Controls.Add(Me.lblSnd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nudLimit)
        Me.Controls.Add(Me.lblActiveTime)
        Me.Controls.Add(Me.nudBreak)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.ShowIcon = False
        Me.Text = "Config"
        Me.TopMost = True
        CType(Me.nudBreak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.nudTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblActiveTime As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudBreak As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Tray As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ConfigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSnd As System.Windows.Forms.Label
    Friend WithEvents btnOpenSnd As System.Windows.Forms.Button
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents mnuStatus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgStatus As System.Windows.Forms.ImageList
    Friend WithEvents mnuStatus2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblIdleTime As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
