<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RotatorAnimationControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.udSpeed = New System.Windows.Forms.NumericUpDown()
        Me.udAngle = New System.Windows.Forms.NumericUpDown()
        Me.cbDeg = New System.Windows.Forms.CheckBox()
        Me.lblSpeed = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.udSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'udSpeed
        '
        Me.udSpeed.Location = New System.Drawing.Point(48, 3)
        Me.udSpeed.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.udSpeed.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.udSpeed.Name = "udSpeed"
        Me.udSpeed.Size = New System.Drawing.Size(47, 20)
        Me.udSpeed.TabIndex = 0
        '
        'udAngle
        '
        Me.udAngle.Location = New System.Drawing.Point(49, 29)
        Me.udAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.udAngle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
        Me.udAngle.Name = "udAngle"
        Me.udAngle.Size = New System.Drawing.Size(46, 20)
        Me.udAngle.TabIndex = 1
        '
        'cbDeg
        '
        Me.cbDeg.AutoSize = True
        Me.cbDeg.Location = New System.Drawing.Point(101, 30)
        Me.cbDeg.Name = "cbDeg"
        Me.cbDeg.Size = New System.Drawing.Size(46, 17)
        Me.cbDeg.TabIndex = 2
        Me.cbDeg.Text = "Deg"
        Me.cbDeg.UseVisualStyleBackColor = True
        '
        'lblSpeed
        '
        Me.lblSpeed.AutoSize = True
        Me.lblSpeed.Location = New System.Drawing.Point(3, 5)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(38, 13)
        Me.lblSpeed.TabIndex = 3
        Me.lblSpeed.Text = "Speed"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Angle"
        '
        'RotatorAnimationControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSpeed)
        Me.Controls.Add(Me.cbDeg)
        Me.Controls.Add(Me.udAngle)
        Me.Controls.Add(Me.udSpeed)
        Me.Name = "RotatorAnimationControl"
        Me.Size = New System.Drawing.Size(150, 52)
        CType(Me.udSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udAngle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents udSpeed As NumericUpDown
    Friend WithEvents udAngle As NumericUpDown
    Friend WithEvents cbDeg As CheckBox
    Friend WithEvents lblSpeed As Label
    Friend WithEvents Label1 As Label
End Class
