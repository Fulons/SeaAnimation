Imports System.Xml

Public MustInherit Class Animation
#Region "Member variables"
    Public children As New List(Of Animation)
    Public id As Guid
#End Region

#Region "Constructors"
    Public Sub New()
        id = Guid.NewGuid()
    End Sub
#End Region
#Region "Overrideable methods"
    'Base method can be used to update children
    Public Overridable Sub Update(dt As Double)
        For Each child In children
            child.Update(dt)
        Next
    End Sub

    'Base method can be used to let children update the RenderObject
    Public Overridable Sub UpdateRenderObject(ByRef renderObject As RenderObject)
        For Each child In children
            child.UpdateRenderObject(renderObject)
        Next
    End Sub
#End Region
#Region "MustOverride methods"
    Public MustOverride Function Save(doc As XmlDocument) As XmlNode
    Public MustOverride Sub Load(node As XmlNode)
    Public MustOverride Function GetTransformation() As Matrix3x2
    Public MustOverride Sub RestartAnimation()
#End Region
#Region "Public shared methods"
    'Loads a specific Animation defined in the XmlNode
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
#End Region
#Region "Helper methods"
    'Helper function to retrieve childrens transformation matrix
    Protected Function GetChildrenTransformation() As Matrix3x2
        Dim m As Matrix3x2 = Matrix3x2.Identity
        For Each child In children
            m = m * child.GetTransformation()
        Next
        Return m
    End Function

    'Helper method to laod children from XmlNode
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
#End Region


End Class