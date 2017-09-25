Public Class AnimationControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        raControl.Hide()
        lmaControl.Hide()
    End Sub

    Public Sub SetValues(a As Animation)
        raControl.Hide()
        lmaControl.Hide()
        If TypeOf a Is RotatorAnimation Then
            raControl.Show()
            raControl.SetValues(a)
        ElseIf TypeOf a Is LinearMoveAnimation Then
            lmaControl.Show()
            lmaControl.SetValues(a)
        End If
    End Sub
End Class
