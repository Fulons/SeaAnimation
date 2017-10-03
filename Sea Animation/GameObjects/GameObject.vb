Imports System.Xml

Public Class GameObject
#Region "Member variables"
    Public renderable As Renderable
    Public name As String
    Public pos As New Vector2

    Public children As New List(Of GameObject)
#End Region

#Region "Contructors"
    Public Sub New()

    End Sub

    Public Sub New(name As String)
        Me.name = name
    End Sub

    'Creates a new GameObject from a xmlNode
    Public Sub New(node As XmlNode)
        Me.Load(node)
    End Sub
#End Region
#Region "Public Methods"
    'Update the renderable and all children
    Public Sub Update(dt As Double)
        If renderable IsNot Nothing Then
            renderable.Update(dt)
        End If
        For Each child As GameObject In children
            child.Update(dt)
        Next
    End Sub

    'Draws the renderable and all children
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

    'Restarts the renderables animation and all childrens renderables animations to ensure they are synced up
    Public Sub RestartAnimation()
        renderable.RestartAnimation()
        For Each child In children
            child.RestartAnimation()
        Next
    End Sub
#End Region
#Region "Save/Load"
    'Creates a xmlNode containing all essential member variables
    Public Function Save(doc As XmlDocument) As XmlNode
        Dim n As XmlNode = doc.CreateNode(XmlNodeType.Element, "GameObject", "")

        'centered
        Dim attribute As XmlAttribute = doc.CreateAttribute("Name")
        attribute.Value = Me.name
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("PosX")
        attribute.Value = pos.X
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("PosY")
        attribute.Value = pos.Y
        n.Attributes.Append(attribute)

        If renderable IsNot Nothing Then
            n.AppendChild(renderable.Save(doc))
        End If

        For Each child In children
            n.AppendChild(child.Save(doc))
        Next

        Return n
    End Function

    'Loads values from a xmlNode
    Public Sub Load(node As XmlNode)
        For Each attribute As XmlAttribute In node.Attributes
            If attribute.Name = "Name" Then
                Me.name = attribute.Value
            ElseIf attribute.Name = "PosX" Then
                Me.pos.X = attribute.Value
            ElseIf attribute.Name = "PosY" Then
                Me.pos.Y = attribute.Value
            End If
        Next

        For Each element As XmlNode In node.ChildNodes
            If element.Name = "GameObject" Then
                children.Add(New GameObject(element))
            ElseIf element.Name = "Renderable" Then
                renderable = New Renderable(element)
            End If
        Next

    End Sub
#End Region
End Class