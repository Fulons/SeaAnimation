Public MustInherit Class RenderObject
    Public centered As Boolean
    Public MustOverride Sub Render(ByRef g As Graphics)
    Public MustOverride Sub RenderPreview(ByRef g As Graphics, size As Vector2)
End Class