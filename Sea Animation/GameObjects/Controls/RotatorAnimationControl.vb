Public Class RotatorAnimationControl
    Public Sub SetValues(a As RotatorAnimation)
        Me.udSpeed.Value = a.speed
        If Me.cbDeg.Checked = False Then
            Me.udAngle.Value = a.angle
        Else
            Me.udAngle.Value = a.angle / (Math.PI * 2) * 360
        End If
    End Sub

    Private Sub cbDeg_CheckedChanged(sender As Object, e As EventArgs) Handles cbDeg.CheckedChanged
        If cbDeg.Checked Then
            Me.udAngle.Value = CType(Form1.selectedAnimation, RotatorAnimation).angle / (Math.PI * 2) * 360
        Else
            Me.udAngle.Value = CType(Form1.selectedAnimation, RotatorAnimation).angle
        End If
    End Sub

    Private Sub RotatorAnimationControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cbDeg.Checked = False
    End Sub

    Private Sub udSpeed_ValueChanged(sender As Object, e As EventArgs) Handles udSpeed.ValueChanged
        CType(Form1.selectedAnimation, RotatorAnimation).speed = udSpeed.Value
    End Sub

    Private Sub udAngle_ValueChanged(sender As Object, e As EventArgs) Handles udAngle.ValueChanged
        CType(Form1.selectedAnimation, RotatorAnimation).angle = udAngle.Value
    End Sub
End Class
