Imports System.Xml

Public MustInherit Class RenderObject
    Public centered As Boolean
    Public MustOverride Sub Render(ByRef g As Graphics)
    Public MustOverride Sub RenderPreview(ByRef g As Graphics, size As Vector2)
    Public MustOverride Function Save(doc As XmlDocument) As XmlNode
    Public MustOverride Sub Load(node As XmlNode)

    Public Shared Function LoadRenderObject(node As XmlNode) As RenderObject
        Dim r As RenderObject = Nothing
        Dim typeName As XmlNode = node.Attributes.GetNamedItem("Type")
        If typeName.Value = "ImageRenderObject" Then
            r = New ImageRenderObject(node)
        End If

        Return r
    End Function
End Class