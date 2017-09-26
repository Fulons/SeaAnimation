Imports System.Xml

Public Class GameObject
    Public renderable As Renderable
    Public name As String
    Public pos As Vector2

    Public children As New List(Of GameObject)

    Public Sub Update(dt As Double)
        If renderable IsNot Nothing Then
            renderable.Update(dt)
        End If
        For Each child As GameObject In children
            child.Update(dt)
        Next
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(name As String)
        Me.name = name
    End Sub

    Public Sub New(node As XmlNode)
        Me.Load(node)
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

End Class