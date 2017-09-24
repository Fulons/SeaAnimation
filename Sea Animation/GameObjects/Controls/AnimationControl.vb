Public Class AnimationControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        raControl.Hide()
    End Sub

    Public Sub SetValues(a As Animation)
        raControl.Hide()
        If TypeOf a Is RotatorAnimation Then
            raControl.Show()
            raControl.SetValues(a)
        End If
    End Sub
End Class
