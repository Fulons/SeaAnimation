Public Class Vec2
    Public x As Double
    Public y As Double

    Public Sub New(x As Double, y As Double)
        Me.x = x
        Me.y = y
    End Sub

    Public Sub New()
        Me.x = 0
        Me.y = 0
    End Sub

    Public Shared Operator +(ByVal v1 As Vec2, ByVal v2 As Vec2)
        Return New Vec2(v1.x + v2.x, v1.y + v2.y)
    End Operator

    Public Shared Operator -(ByVal v1 As Vec2, ByVal v2 As Vec2)
        Return New Vec2(v1.x - v2.x, v1.y - v2.y)
    End Operator

    Public Shared Operator *(ByVal v1 As Vec2, ByVal v2 As Double)
        Return New Vec2(v1.x * v2, v1.y * v2)
    End Operator

    Public Shared Operator /(ByVal v1 As Vec2, ByVal v2 As Double)
        Return New Vec2(v1.x / v2, v1.y / v2)
    End Operator

    Public Shared Function LengthSquared(ByVal v1) As Double
        Return v1.x * v1.x + v1.y * v1.y
    End Function

    Public Shared Function Length(ByVal v1) As Double
        Return Math.Sqrt(LengthSquared(v1))
    End Function

    Public Shared Function Normalize(ByVal v1) As Vec2
        Dim l As Double = Length(v1)
        Return New Vec2(v1.x / l, v1.y / l)
    End Function

    Public Shared Function AsPoint(ByVal v1) As Point
        Return New Point(v1.x, v1.y)
    End Function


    Public Shared Function Dot(ByVal v1, ByVal v2) As Double
        Return v1.x * v2.x + v1.y * v2.y
    End Function

End Class