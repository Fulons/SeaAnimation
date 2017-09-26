Imports System.Xml

Public Class RotatorAnimation : Inherits Animation
    Public angle As Double = 0
    Public speed As Double = 1

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(node As XmlNode)
        Me.Load(node)
    End Sub

    Public Sub New(speed As Double, Optional angle As Double = 0)
        MyBase.New()
        If angle > (Math.PI * 2) Or angle < (-Math.PI * 2) Then angle = angle Mod Math.PI * 2
        Me.speed = speed
        Me.angle = angle
    End Sub

    Public Overrides Sub Update(dt As Double)
        MyBase.Update(dt)
        angle += speed * dt
        If angle > (Math.PI * 2) Or angle < (-Math.PI * 2) Then angle = angle Mod Math.PI * 2
    End Sub

    Public Overrides Function GetTransformation() As Matrix3x2
        Return Matrix3x2.CreateRotation(angle) * GetChildrenTransformation()
    End Function

    Public Overrides Function Save(doc As XmlDocument) As XmlNode
        Dim n As XmlNode = doc.CreateNode(XmlNodeType.Element, "Animation", "")

        Dim attribute As XmlAttribute = doc.CreateAttribute("Type")
        attribute.Value = "RotatorAnimation"
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("id")
        attribute.Value = Me.id.ToString
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("Speed")
        attribute.Value = speed
        n.Attributes.Append(attribute)

        For Each child In children
            n.AppendChild(child.Save(doc))
        Next

        Return n
    End Function

    Public Overrides Sub Load(node As XmlNode)
        For Each attribute As XmlAttribute In node.Attributes
            If attribute.Name = "id" Then
                Me.id = Guid.Parse(attribute.Value)
            ElseIf attribute.Name = "Speed" Then
                Me.speed = attribute.Value
            End If
        Next
        LoadChildren(node)
    End Sub


End Class