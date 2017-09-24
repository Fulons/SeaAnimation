Public Class Renderable
    Public what As RenderObject
    Public where As Vector2
    Public animation As Animation
    Public id As Guid

    Public children As New List(Of Renderable)

    Public Sub New()
        id = Guid.NewGuid()
    End Sub

    Public Sub Update(dt As Double)
        If animation IsNot Nothing Then
            animation.Update(dt)
            animation.updateRenderObject(what)
        End If
        For Each child In children
            child.Update(dt)
        Next
    End Sub

    Public Sub RenderPreview(ByRef g As Graphics, size As Vector2)
        what.RenderPreview(g, size)
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