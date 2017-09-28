Public Class Vector2
    Public X As Single
    Public Y As Single
    Public Sub New(x As Single, y As Single)

    End Sub

    Public Sub New()

    End Sub

    Public Shared Function DistanceSquared(vec1 As Vector2, vec2 As Vector2)

    End Function

    Public Shared Operator +(vec1 As Vector2, vec2 As Vector2)

    End Operator

    Public Shared Operator -(vec1 As Vector2, vec2 As Vector2)

    End Operator

    Public Shared Operator *(vec1 As Vector2, scale As Single)

    End Operator

    Public Shared Function Normalize(vec1 As Vector2) As Vector2

    End Function

End Class
