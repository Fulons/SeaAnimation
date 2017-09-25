

Public Class LinearMoveAnimationControl

    Public Sub SetValues(a As LinearMoveAnimation)
        Me.posTarget.SetVec(a.target)
        Me.udSpeed.Value = a.speed
        Me.cbReturn.Checked = a.returnAfterTargetReached
        Me.cbRepeat.Checked = a.repeat
    End Sub

    Private Sub cbRepeat_CheckedChanged(sender As Object, e As EventArgs) Handles cbRepeat.CheckedChanged
        Dim a As LinearMoveAnimation = CType(Form1.selectedAnimation, LinearMoveAnimation)
        a.repeat = cbRepeat.Checked
    End Sub

    Private Sub cbReturn_CheckedChanged(sender As Object, e As EventArgs) Handles cbReturn.CheckedChanged
        Dim a As LinearMoveAnimation = CType(Form1.selectedAnimation, LinearMoveAnimation)
        a.returnAfterTargetReached = cbReturn.Checked
    End Sub

    Private Sub udSpeed_ValueChanged(sender As Object, e As EventArgs) Handles udSpeed.ValueChanged
        Dim a As LinearMoveAnimation = CType(Form1.selectedAnimation, LinearMoveAnimation)
        a.speed = udSpeed.Value
    End Sub

    Private Sub posTarget_XPosChanged(val As Double) Handles posTarget.XPosChanged
        Dim a As LinearMoveAnimation = CType(Form1.selectedAnimation, LinearMoveAnimation)
        a.target = New Vector2(val, a.target.Y)
    End Sub

    Private Sub posTarget_YPosChanged(val As Double) Handles posTarget.YPosChanged
        Dim a As LinearMoveAnimation = CType(Form1.selectedAnimation, LinearMoveAnimation)
        a.target = New Vector2(a.target.X, val)
    End Sub
End Class
