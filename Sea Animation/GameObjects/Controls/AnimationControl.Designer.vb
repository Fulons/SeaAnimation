<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AnimationControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.raControl = New Sea_Animation.RotatorAnimationControl()
        Me.lmaControl = New Sea_Animation.LinearMoveAnimationControl()
        Me.SuspendLayout()
        '
        'raControl
        '
        Me.raControl.AutoSize = True
        Me.raControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.raControl.Location = New System.Drawing.Point(0, 0)
        Me.raControl.Name = "raControl"
        Me.raControl.Size = New System.Drawing.Size(150, 52)
        Me.raControl.TabIndex = 0
        '
        'lmaControl
        '
        Me.lmaControl.AutoSize = True
        Me.lmaControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.lmaControl.Location = New System.Drawing.Point(0, 0)
        Me.lmaControl.Name = "lmaControl"
        Me.lmaControl.Size = New System.Drawing.Size(195, 99)
        Me.lmaControl.TabIndex = 1
        '
        'AnimationControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.lmaControl)
        Me.Controls.Add(Me.raControl)
        Me.Name = "AnimationControl"
        Me.Size = New System.Drawing.Size(198, 102)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents raControl As RotatorAnimationControl
    Friend WithEvents lmaControl As LinearMoveAnimationControl
End Class
