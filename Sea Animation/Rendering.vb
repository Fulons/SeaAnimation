Public MustInherit Class RenderObject

    Public MustOverride Sub Render(ByRef g As Graphics)

End Class

Public Class ImageRenderObject : Inherits RenderObject
    Public img As Image
    Public centered As Boolean

    Public Sub New(img As Image, Optional centered As Boolean = False)
        Me.img = img
        Me.centered = centered
    End Sub

    Public Overrides Sub Render(ByRef g As Graphics)
        If centered = True Then
            g.DrawImage(img, New RectangleF(-img.Width / 2, -img.Height / 2, img.Width, img.Height))
        Else
            g.DrawImage(img, New RectangleF(0, 0, img.Width, img.Height))
        End If
    End Sub
End Class

Public Class Renderable
    Public what As RenderObject
    Public where As Vector2
    Public animation As Animation

    Public children As New List(Of Renderable)

    Public Sub Update(dt As Double)
        If animation IsNot Nothing Then
            animation.Update(dt)
            animation.updateRenderObject(what)
        End If
        For Each child In children
            child.Update(dt)
        Next
    End Sub

    Public Sub Render(ByRef g As Graphics, ByRef transformStack As Stack(Of Matrix3x2))
        Dim m As Matrix3x2 = Matrix3x2.Identity
        If animation IsNot Nothing Then
            m = animation.GetTransformation()
        End If
        m = m * Matrix3x2.CreateTranslation(where) * transformStack.Peek()
        g.Transform = New Drawing2D.Matrix(m.M11, m.M12, m.M21, m.M22, m.M31, m.M32)
        what.Render(g)
        transformStack.Push(m)
        For Each child In children
            child.Render(g, transformStack)
        Next
        transformStack.Pop()
    End Sub
End Class

Public Class GameObject
    Public renderable As Renderable
    Public name As String
    Public pos As Vector2

    Public children As New List(Of GameObject)

    Public Sub Update(dt As Double)
        renderable.Update(dt)
    End Sub

    Public Sub Draw(ByRef g As Graphics)
        Dim transformStack As New Stack(Of Matrix3x2)
        transformStack.Push(Matrix3x2.CreateTranslation(pos))
        renderable.Render(g, transformStack)
    End Sub
End Class

Public Class RotatorAnimation : Inherits Animation
    Public angle As Double = 0
    Public speed As Double = 1
    Public Sub New()

    End Sub

    Public Sub New(speed As Double, Optional angle As Double = 0)
        Me.speed = speed
        Me.angle = angle
    End Sub

    Public Overrides Sub Update(dt As Double)
        angle += speed * dt
    End Sub

    Public Overrides Function GetTransformation() As Matrix3x2
        Return Matrix3x2.CreateRotation(angle)
    End Function
End Class

Public MustInherit Class Animation
    Public children As New List(Of Animation)

    Public Overridable Sub Update(dt As Double)
        For Each child In children
            child.Update(dt)
        Next
    End Sub

    Public MustOverride Function GetTransformation() As Matrix3x2

    Public Overridable Sub updateRenderObject(ByRef renderObject As RenderObject)
        For Each child In children
            child.updateRenderObject(renderObject)
        Next
    End Sub
End Class