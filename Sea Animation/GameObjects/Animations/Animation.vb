Imports System.Xml

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

    Public Overridable Sub UpdateRenderObject(ByRef renderObject As RenderObject)
        For Each child In children
            child.UpdateRenderObject(renderObject)
        Next
    End Sub

    Public MustOverride Function Save(doc As XmlDocument) As XmlNode
    Public MustOverride Sub Load(node As XmlNode)

    Public Shared Function LoadAnimation(ByRef node As XmlNode) As Animation
        Dim a As Animation = Nothing
        Dim typeName As XmlNode = node.Attributes.GetNamedItem("Type")
        If typeName.Value = "LinearMoveAnimation" Then
            a = New LinearMoveAnimation(node)
        ElseIf typeName.Value = "RotatorAnimation" Then
            a = New RotatorAnimation(node)
        End If
        Return a
    End Function

    Protected Sub LoadChildren(ByRef node As XmlNode)
        For Each child As XmlNode In node.ChildNodes
            Dim typeName As XmlNode = child.Attributes.GetNamedItem("Type")
            If typeName.Value = "LinearMoveAnimation" Then
                children.Add(New LinearMoveAnimation(child))
            ElseIf typeName.Value = "RotatorAnimation" Then
                children.Add(New RotatorAnimation(child))
            End If
        Next
    End Sub
End Class