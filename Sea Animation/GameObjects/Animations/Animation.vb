
Public MustInherit Class Animation
    Public children As New List(Of Animation)
    Public id As Guid

    Public Sub New()
        id = Guid.NewGuid()
    End Sub

    Public Overridable Sub Update(dt As Double)
        For Each child In children
            child.Update(dt)
        Next
    End Sub

    Protected Function GetChildrenTransformation() As Matrix3x2
        Dim m As Matrix3x2 = Matrix3x2.Identity
        For Each child In children
            m = m * child.GetTransformation()
        Next
        Return m
    End Function
    Public MustOverride Function GetTransformation() As Matrix3x2

    Public Overridable Sub updateRenderObject(ByRef renderObject As RenderObject)
        For Each child In children
            child.updateRenderObject(renderObject)
        Next
    End Sub
End Class