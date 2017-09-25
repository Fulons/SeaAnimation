
Imports Sea_Animation

Public Class LinearMoveAnimation : Inherits Animation

    Private _target As New Vector2(0, 0)
    Public Property target As Vector2
        Get
            Return _target
        End Get
        Set(value As Vector2)
            reverse = False
            targetReached = False
            currentPos.X = 0
            currentPos.Y = 0
            If value.X = 0 AndAlso value.Y = 0 Then
                direction.X = 0
                direction.Y = 0
            Else
                direction = Vector2.Normalize(value)
            End If
            _target = value
        End Set
    End Property
    Private _speed As Double = 0
    Public Property speed As Double
        Get
            Return _speed
        End Get
        Set(value As Double)
            reverse = False
            targetReached = False
            currentPos.X = 0
            currentPos.Y = 0
            _speed = value
        End Set
    End Property

    Public returnAfterTargetReached As Boolean = False
    Public repeat As Boolean = False

    Private direction As New Vector2
    Private reverse As Boolean = False
    Private currentPos As New Vector2(0, 0)
    Private targetReached As Boolean = False

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
                If repeat = True Then
                    _speed *= -1
                Else
                    targetReached = True
                End If
            End If
        Else
            If Vector2.DistanceSquared(New Vector2(0, 0), currentPos) > Vector2.DistanceSquared(New Vector2(0, 0), target) Then
                currentPos = _target
                If returnAfterTargetReached = True Then
                    _speed *= -1
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
        MyBase.updateRenderObject(renderObject)
    End Sub

End Class
