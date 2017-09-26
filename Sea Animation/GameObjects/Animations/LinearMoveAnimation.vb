
Imports System.Xml
Imports Sea_Animation

Public Class LinearMoveAnimation : Inherits Animation

    Private _target As New Vector2(0, 0)
    Public Property target As Vector2
        Get
            Return _target
        End Get
        Set(value As Vector2)
            _target = value
            RestartAnimation()
        End Set
    End Property
    Private _speed As Double = 0
    Public Property speed As Double
        Get
            Return _speed
        End Get
        Set(value As Double)
            _speed = value
            RestartAnimation()
        End Set
    End Property

    Public returnAfterTargetReached As Boolean = False
    Public repeat As Boolean = False

    Private direction As New Vector2
    Private reverse As Boolean = False
    Private currentPos As New Vector2(0, 0)
    Private targetReached As Boolean = False

    Private Sub Recalculate()
        If _target.X = 0 AndAlso _target.Y = 0 Then
            direction = New Vector2(0, 0)
        Else
            direction = Vector2.Normalize(_target)
        End If
        reverse = False
        currentPos = New Vector2(0, 0)
        targetReached = False
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(node As XmlNode)
        Me.Load(node)
        RestartAnimation()
    End Sub

    Public Overrides Function GetTransformation() As Matrix3x2
        Dim m As Matrix3x2 = GetChildrenTransformation()
        Dim a As Matrix3x2 = Matrix3x2.CreateTranslation(currentPos)
        Return Matrix3x2.CreateTranslation(currentPos) * GetChildrenTransformation()
    End Function

    Public Overrides Sub Update(dt As Double)
        MyBase.Update(dt)

        If targetReached = True Then Return

        currentPos += direction * _speed * dt
        If reverse = True Then
            If Vector2.DistanceSquared(_target, currentPos) > Vector2.DistanceSquared(target, New Vector2(0, 0)) Then
                currentPos.X = 0
                currentPos.Y = 0
                reverse = False
                direction *= -1
                If repeat = False Then
                    targetReached = True
                End If
            End If
        Else
            If Vector2.DistanceSquared(New Vector2(0, 0), currentPos) > Vector2.DistanceSquared(New Vector2(0, 0), target) Then
                currentPos = _target
                If returnAfterTargetReached = True Then
                    direction *= -1
                    reverse = True
                ElseIf repeat = True Then
                    currentPos.X = 0
                    currentPos.Y = 0
                Else
                    targetReached = True
                End If
            End If
        End If
    End Sub

    Public Overrides Sub UpdateRenderObject(ByRef renderObject As RenderObject)
        MyBase.UpdateRenderObject(renderObject)
    End Sub

    Public Overrides Function Save(doc As XmlDocument) As XmlNode
        Dim n As XmlNode = doc.CreateNode(XmlNodeType.Element, "Animation", "")
        'id As Attribute

        Dim attribute As XmlAttribute = doc.CreateAttribute("Type")
        attribute.Value = "LinearMoveAnimation"
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("id")
        attribute.Value = Me.id.ToString
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("TargetX")
        attribute.Value = _target.X
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("TargetY")
        attribute.Value = _target.Y
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("Speed")
        attribute.Value = _speed
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("ReturnAfterTargetReached")
        attribute.Value = returnAfterTargetReached.ToString
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("Repeat")
        attribute.Value = repeat.ToString
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
            ElseIf attribute.Name = "TargetX" Then
                Me._target.X = attribute.Value
            ElseIf attribute.Name = "TargetY" Then
                Me._target.Y = attribute.Value
            ElseIf attribute.Name = "Speed" Then
                Me._speed = attribute.Value
            ElseIf attribute.Name = "ReturnAfterTargetReached" Then
                Me.returnAfterTargetReached = attribute.Value
            ElseIf attribute.Name = "Repeat" Then
                Me.repeat = attribute.Value
            End If
        Next
        LoadChildren(node)
    End Sub

    Public Overrides Sub RestartAnimation()
        Recalculate()
        For Each child In children
            child.RestartAnimation()
        Next
    End Sub
End Class
