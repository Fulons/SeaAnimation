Public Class RotatorAnimation : Inherits Animation
    Public angle As Double = 0
    Public speed As Double = 1

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(speed As Double, Optional angle As Double = 0)
        MyBase.New()
        If angle > (Math.PI * 2) Or angle < (-Math.PI * 2) Then angle = angle Mod Math.PI * 2
        Me.speed = speed
        Me.angle = angle
    End Sub

    Public Overrides Sub Update(dt As Double)
        MyBase.Update(dt)
        angle += speed * dt
        If angle > (Math.PI * 2) Or angle < (-Math.PI * 2) Then angle = angle Mod Math.PI * 2
    End Sub

    Public Overrides Function GetTransformation() As Matrix3x2
        Return Matrix3x2.CreateRotation(angle) * GetChildrenTransformation()
    End Function
End Class