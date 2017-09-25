<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LinearMoveAnimationControl
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
        Me.posTarget = New Sea_Animation.PostitionControl()
        Me.udSpeed = New System.Windows.Forms.NumericUpDown()
        Me.cbRepeat = New System.Windows.Forms.CheckBox()
        Me.cbReturn = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.udSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'posTarget
        '
        Me.posTarget.AutoSize = True
        Me.posTarget.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.posTarget.Location = New System.Drawing.Point(0, 0)
        Me.posTarget.Margin = New System.Windows.Forms.Padding(0)
        Me.posTarget.Name = "posTarget"
        Me.posTarget.Size = New System.Drawing.Size(195, 26)
        Me.posTarget.TabIndex = 1
        '
        'udSpeed
        '
        Me.udSpeed.Location = New System.Drawing.Point(50, 29)
        Me.udSpeed.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.udSpeed.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.udSpeed.Name = "udSpeed"
        Me.udSpeed.Size = New System.Drawing.Size(55, 20)
        Me.udSpeed.TabIndex = 2
        '
        'cbRepeat
        '
        Me.cbRepeat.AutoSize = True
        Me.cbRepeat.Location = New System.Drawing.Point(3, 79)
        Me.cbRepeat.Name = "cbRepeat"
        Me.cbRepeat.Size = New System.Drawing.Size(61, 17)
        Me.cbRepeat.TabIndex = 3
        Me.cbRepeat.Text = "Repeat"
        Me.cbRepeat.UseVisualStyleBackColor = True
        '
        'cbReturn
        '
        Me.cbReturn.AutoSize = True
        Me.cbReturn.Location = New System.Drawing.Point(3, 56)
        Me.cbReturn.Name = "cbReturn"
        Me.cbReturn.Size = New System.Drawing.Size(111, 17)
        Me.cbReturn.TabIndex = 4
        Me.cbReturn.Text = "Return from target"
        Me.cbReturn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Speed:"
        '
        'LinearMoveAnimationControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbReturn)
        Me.Controls.Add(Me.cbRepeat)
        Me.Controls.Add(Me.udSpeed)
        Me.Controls.Add(Me.posTarget)
        Me.Name = "LinearMoveAnimationControl"
        Me.Size = New System.Drawing.Size(195, 99)
        CType(Me.udSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents posTarget As PostitionControl
    Friend WithEvents udSpeed As NumericUpDown
    Friend WithEvents cbRepeat As CheckBox
    Friend WithEvents cbReturn As CheckBox
    Friend WithEvents Label1 As Label
End Class
