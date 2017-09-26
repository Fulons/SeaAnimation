Imports System.Xml

Public Class RotatorAnimation : Inherits Animation
#Region "Member variables"
    Private _target As Double = 0
    Public Property target As Double
        Get
            Return _target
        End Get
        Set(value As Double)
            _target = value
            Recalculate()
        End Set
    End Property
    Private _initialAngle As Double = 0
    Public Property initialAngle As Double
        Get
            Return _initialAngle
        End Get
        Set(value As Double)
            _initialAngle = value
            Recalculate()
        End Set
    End Property
    Public speed As Double = 1
    Public repeat As Boolean = False
    Public returnAfterTargetReached As Boolean = False

    Private direction As Double = 1
    Private reverse As Boolean = False
    Private currentAngle As Double = 0
    Private targetReached As Boolean = False
#End Region

#Region "Private helper methods"
    Private Sub Recalculate()
        direction = 1
        reverse = False
        currentAngle = 0
        targetReached = False
    End Sub
#End Region
#Region "Constructors"
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(node As XmlNode)
        Me.Load(node)
    End Sub

    Public Sub New(target As Double, speed As Double, Optional initialAngle As Double = 0, Optional repeat As Boolean = False, Optional returnAfteTarget As Boolean = False)
        MyBase.New()
        Me.target = target
        Me.initialAngle = initialAngle
        Me.speed = speed
        Me.repeat = repeat
        Me.returnAfterTargetReached = returnAfterTargetReached
    End Sub
#End Region
#Region "Public overrides methods"
    Public Overrides Sub Update(dt As Double)
        MyBase.Update(dt)
        If targetReached = True Then Return
        Dim lastAngle As Double = currentAngle
        currentAngle += direction * speed * dt
        If reverse = True Then
            If currentAngle - initialAngle >= 0 AndAlso lastAngle - initialAngle < 0 Or currentAngle - initialAngle <= 0 AndAlso lastAngle - initialAngle > 0 Then
                reverse = False
                direction *= -1
                currentAngle = initialAngle
                If repeat = False Then
                    targetReached = True
                End If
            End If
        Else
            If Math.Abs(currentAngle - initialAngle) > Math.Abs(target - initialAngle) Then
                If returnAfterTargetReached = True Then
                    reverse = True
                    direction *= -1
                    currentAngle = target
                ElseIf repeat = True Then
                    currentAngle = initialAngle
                Else
                    targetReached = True
                End If
            End If
        End If
    End Sub

    Public Overrides Function GetTransformation() As Matrix3x2
        Return Matrix3x2.CreateRotation(currentAngle) * GetChildrenTransformation()
    End Function

    Public Overrides Function Save(doc As XmlDocument) As XmlNode
        Dim n As XmlNode = doc.CreateNode(XmlNodeType.Element, "Animation", "")

        Dim attribute As XmlAttribute = doc.CreateAttribute("Type")
        attribute.Value = "RotatorAnimation"
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("id")
        attribute.Value = Me.id.ToString
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("Target")
        attribute.Value = target
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("InitialAngle")
        attribute.Value = initialAngle
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("Speed")
        attribute.Value = speed
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("Repeat")
        attribute.Value = repeat
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("ReturnAfterTargetReached")
        attribute.Value = returnAfterTargetReached
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
            ElseIf attribute.Name = "Target" Then
                Me.target = attribute.Value
            ElseIf attribute.Name = "InitialAngle" Then
                Me.initialAngle = attribute.Value
            ElseIf attribute.Name = "Speed" Then
                Me.speed = attribute.Value
            ElseIf attribute.Name = "Repeat" Then
                Me.repeat = attribute.Value
            ElseIf attribute.Name = "ReturnAfterTargetReached" Then
                Me.returnAfterTargetReached = attribute.Value
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
#End Region
End Class