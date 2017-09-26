
Public Class RotatorAnimationControl
#Region "Event handlers"
    Private Sub cbDeg_CheckedChanged(sender As Object, e As EventArgs) Handles cbDeg.CheckedChanged
        If cbDeg.Checked Then
            Me.udTargetAngle.Value = CType(Form1.selectedAnimation, RotatorAnimation).target / (Math.PI * 2) * 360
            Me.udInitialAngle.Value = CType(Form1.selectedAnimation, RotatorAnimation).initialAngle / (Math.PI * 2) * 360
        Else
            Me.udTargetAngle.Value = CType(Form1.selectedAnimation, RotatorAnimation).target
            Me.udInitialAngle.Value = CType(Form1.selectedAnimation, RotatorAnimation).initialAngle
        End If
    End Sub

    Private Sub RotatorAnimationControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cbDeg.Checked = False
    End Sub

    Private Sub udSpeed_ValueChanged(sender As Object, e As EventArgs) Handles udSpeed.ValueChanged
        CType(Form1.selectedAnimation, RotatorAnimation).speed = udSpeed.Value
        CType(Form1.selectedAnimation, RotatorAnimation).RestartAnimation()
    End Sub

    Private Sub udAngle_ValueChanged(sender As Object, e As EventArgs) Handles udTargetAngle.ValueChanged
        If cbDeg.Checked Then
            CType(Form1.selectedAnimation, RotatorAnimation).target = udTargetAngle.Value / 360 * (Math.PI * 2)
        Else
            CType(Form1.selectedAnimation, RotatorAnimation).target = udTargetAngle.Value
        End If
        CType(Form1.selectedAnimation, RotatorAnimation).RestartAnimation()
    End Sub

    Private Sub udInitialAngle_ValueChanged(sender As Object, e As EventArgs) Handles udInitialAngle.ValueChanged
        If cbDeg.Checked Then
            CType(Form1.selectedAnimation, RotatorAnimation).initialAngle = udInitialAngle.Value / 360.0 * (Math.PI * 2)
        Else
            CType(Form1.selectedAnimation, RotatorAnimation).initialAngle = udInitialAngle.Value
        End If
        CType(Form1.selectedAnimation, RotatorAnimation).RestartAnimation()
    End Sub

    Private Sub cbReturn_CheckedChanged(sender As Object, e As EventArgs) Handles cbReturn.CheckedChanged
        CType(Form1.selectedAnimation, RotatorAnimation).returnAfterTargetReached = cbReturn.Checked()
        CType(Form1.selectedAnimation, RotatorAnimation).RestartAnimation()
    End Sub

    Private Sub cbRepeat_CheckedChanged(sender As Object, e As EventArgs) Handles cbRepeat.CheckedChanged
        CType(Form1.selectedAnimation, RotatorAnimation).repeat = cbRepeat.Checked()
        CType(Form1.selectedAnimation, RotatorAnimation).RestartAnimation()
    End Sub
#End Region

    'Helper duntion to easily set control values from a RotatorAnimation object
    Public Sub SetValues(a As RotatorAnimation)
        If Me.cbDeg.Checked = False Then
            Me.udTargetAngle.Value = a.target
            Me.udInitialAngle.Value = a.initialAngle
        Else
            Me.udTargetAngle.Value = a.target / (Math.PI * 2) * 360
            Me.udInitialAngle.Value = a.initialAngle / (Math.PI * 2) * 360
        End If
        Me.udSpeed.Value = a.speed
        Me.cbReturn.Checked = a.returnAfterTargetReached
        Me.cbRepeat.Checked = a.repeat
    End Sub
End Class