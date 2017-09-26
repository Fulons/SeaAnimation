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
        Me.udTargetAngle = New System.Windows.Forms.NumericUpDown()
        Me.cbDeg = New System.Windows.Forms.CheckBox()
        Me.lblSpeed = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbRepeat = New System.Windows.Forms.CheckBox()
        Me.cbReturn = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.udInitialAngle = New System.Windows.Forms.NumericUpDown()
        CType(Me.udSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udTargetAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udInitialAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'udSpeed
        '
        Me.udSpeed.Location = New System.Drawing.Point(75, 55)
        Me.udSpeed.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.udSpeed.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.udSpeed.Name = "udSpeed"
        Me.udSpeed.Size = New System.Drawing.Size(47, 20)
        Me.udSpeed.TabIndex = 0
        '
        'udTargetAngle
        '
        Me.udTargetAngle.Location = New System.Drawing.Point(76, 3)
        Me.udTargetAngle.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.udTargetAngle.Minimum = New Decimal(New Integer() {1000000, 0, 0, -2147483648})
        Me.udTargetAngle.Name = "udTargetAngle"
        Me.udTargetAngle.Size = New System.Drawing.Size(46, 20)
        Me.udTargetAngle.TabIndex = 1
        '
        'cbDeg
        '
        Me.cbDeg.AutoSize = True
        Me.cbDeg.Location = New System.Drawing.Point(128, 4)
        Me.cbDeg.Name = "cbDeg"
        Me.cbDeg.Size = New System.Drawing.Size(46, 17)
        Me.cbDeg.TabIndex = 2
        Me.cbDeg.Text = "Deg"
        Me.cbDeg.UseVisualStyleBackColor = True
        '
        'lblSpeed
        '
        Me.lblSpeed.AutoSize = True
        Me.lblSpeed.Location = New System.Drawing.Point(2, 57)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(38, 13)
        Me.lblSpeed.TabIndex = 3
        Me.lblSpeed.Text = "Speed"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Target Angle"
        '
        'cbRepeat
        '
        Me.cbRepeat.AutoSize = True
        Me.cbRepeat.Location = New System.Drawing.Point(2, 104)
        Me.cbRepeat.Name = "cbRepeat"
        Me.cbRepeat.Size = New System.Drawing.Size(61, 17)
        Me.cbRepeat.TabIndex = 5
        Me.cbRepeat.Text = "Repeat"
        Me.cbRepeat.UseVisualStyleBackColor = True
        '
        'cbReturn
        '
        Me.cbReturn.AutoSize = True
        Me.cbReturn.Location = New System.Drawing.Point(2, 81)
        Me.cbReturn.Name = "cbReturn"
        Me.cbReturn.Size = New System.Drawing.Size(111, 17)
        Me.cbReturn.TabIndex = 6
        Me.cbReturn.Text = "Return from target"
        Me.cbReturn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Initial Angle"
        '
        'udInitialAngle
        '
        Me.udInitialAngle.Location = New System.Drawing.Point(76, 29)
        Me.udInitialAngle.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.udInitialAngle.Minimum = New Decimal(New Integer() {1000000, 0, 0, -2147483648})
        Me.udInitialAngle.Name = "udInitialAngle"
        Me.udInitialAngle.Size = New System.Drawing.Size(46, 20)
        Me.udInitialAngle.TabIndex = 7
        '
        'RotatorAnimationControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.udInitialAngle)
        Me.Controls.Add(Me.cbReturn)
        Me.Controls.Add(Me.cbRepeat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSpeed)
        Me.Controls.Add(Me.cbDeg)
        Me.Controls.Add(Me.udTargetAngle)
        Me.Controls.Add(Me.udSpeed)
        Me.Name = "RotatorAnimationControl"
        Me.Size = New System.Drawing.Size(177, 124)
        CType(Me.udSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udTargetAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udInitialAngle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents udSpeed As NumericUpDown
    Friend WithEvents udTargetAngle As NumericUpDown
    Friend WithEvents cbDeg As CheckBox
    Friend WithEvents lblSpeed As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbRepeat As CheckBox
    Friend WithEvents cbReturn As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents udInitialAngle As NumericUpDown
End Class
