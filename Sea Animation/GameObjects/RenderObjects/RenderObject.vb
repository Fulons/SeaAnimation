Imports System.Xml

Public MustInherit Class RenderObject
#Region "Member variables"
    Public centered As Boolean
#End Region

#Region "Must override Methods"
    Public MustOverride Sub Render(ByRef g As Graphics)                         'Used to render the object on screen
    Public MustOverride Sub RenderPreview(ByRef g As Graphics, size As Vector2) 'Used to create a preview of the object to fit inside a PictureBox of size size
    Public MustOverride Function Save(doc As XmlDocument) As XmlNode            'Used to save the object to a XmlNode
    Public MustOverride Sub Load(node As XmlNode)                               'Used to load the object from a XmlNode
#End Region
#Region "Public shared methods"
    'Loads a specific RenderObject defined in the XmlNode
    Public Shared Function LoadRenderObject(node As XmlNode) As RenderObject
        Dim r As RenderObject = Nothing
        Dim typeName As XmlNode = node.Attributes.GetNamedItem("Type")
        If typeName.Value = "ImageRenderObject" Then
            r = New ImageRenderObject(node)
        End If

        Return r
    End Function
#End Region
End Class