Public Structure Vector2
    Public X As Single
    Public Y As Single
    Public Sub New(Optional x As Single = 0, Optional y As Single = 0)
        Me.X = x
        Me.Y = y
    End Sub

    Public Sub New(vec As Vector2)
        Me.X = vec.X
        Me.Y = vec.Y
    End Sub

    Public Shared Function DistanceSquared(vec1 As Vector2, vec2 As Vector2) As Single
        Return DistanceSquared(vec2 - vec1)
    End Function

    Public Shared Function DistanceSquared(vec1 As Vector2) As Single
        Return vec1.X * vec1.X + vec1.Y * vec1.Y
    End Function

    Public Shared Operator +(vec1 As Vector2, vec2 As Vector2) As Vector2
        Return New Vector2(vec1.X + vec2.X, vec1.Y + vec2.Y)
    End Operator

    Public Shared Operator -(vec1 As Vector2, vec2 As Vector2) As Vector2
        Return New Vector2(vec1.X - vec2.X, vec1.Y - vec2.Y)
    End Operator

    Public Shared Operator *(vec1 As Vector2, scale As Single) As Vector2
        Return New Vector2(vec1.X * scale, vec1.Y * scale)
    End Operator

    Public Shared Function Magnitude(vec1 As Vector2) As Single
        Return Math.Sqrt(DistanceSquared(vec1))
    End Function

    Public Shared Function Normalize(vec1 As Vector2) As Vector2
        Dim length As Single = Magnitude(vec1)
        Return New Vector2(vec1.X / length, vec1.Y / length)
    End Function

End Structure
