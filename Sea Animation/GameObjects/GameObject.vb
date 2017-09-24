Public Class GameObject
    Public renderable As Renderable
    Public name As String
    Public pos As Vector2

    Public children As New List(Of GameObject)

    Public Sub Update(dt As Double)
        If renderable IsNot Nothing Then
            renderable.Update(dt)
        End If
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(name As String)
        Me.name = name
    End Sub

    Public Sub Draw(ByRef g As Graphics)
        Dim transformStack As New Stack(Of Matrix3x2)
        transformStack.Push(Matrix3x2.CreateTranslation(pos))
        If renderable IsNot Nothing Then
            renderable.Render(g, transformStack)
        End If
        For Each child As GameObject In children
            child.Draw(g)
        Next
    End Sub
End Class