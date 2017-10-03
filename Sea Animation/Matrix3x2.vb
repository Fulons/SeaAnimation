Public Class Matrix3x2

    Public M11 As Single
    Public M12 As Single

    Public M21 As Single
    Public M22 As Single

    Public M31 As Single
    Public M32 As Single

    Public Sub New(M11 As Single, M21 As Single, M31 As Single, M12 As Single, M22 As Single, M32 As Single)
        Me.M11 = M11
        Me.M12 = M12

        Me.M21 = M21
        Me.M22 = M22

        Me.M31 = M31
        Me.M32 = M32
    End Sub

    Public Sub New()
        Me.M11 = 1
        Me.M12 = 0

        Me.M21 = 0
        Me.M22 = 1

        Me.M31 = 0
        Me.M32 = 0
    End Sub

    Public Shared Function Identity() As Matrix3x2
        Return New Matrix3x2(1, 0, 0, 0, 1, 0)
    End Function

    Public Shared Operator *(mat1 As Matrix3x2, mat2 As Matrix3x2) As Matrix3x2
        Return New Matrix3x2(mat2.M11 * mat1.M11 + mat2.M21 * mat1.M12,
                             mat2.M11 * mat1.M21 + mat2.M21 * mat1.M22,
                             mat2.M11 * mat1.M31 + mat2.M21 * mat1.M32 + mat2.M31,
                             mat2.M12 * mat1.M11 + mat2.M22 * mat1.M12,
                             mat2.M12 * mat1.M21 + mat2.M22 * mat1.M22,
                             mat2.M12 * mat1.M31 + mat2.M22 * mat1.M32 + mat2.M32)
    End Operator

    Public Shared Operator *(mat1 As Matrix3x2, ByVal vec1 As Vector2) As Vector2
        Return New Vector2(vec1.X * mat1.M11 + vec1.Y * mat1.M21 + mat1.M31,
                           vec1.X * mat1.M12 + vec1.Y * mat1.M22 + mat1.M32)
    End Operator

    Public Shared Function CreateTranslation(vec As Vector2) As Matrix3x2
        Return New Matrix3x2(1, 0, vec.X,
                             0, 1, vec.Y)
    End Function

    Public Shared Function CreateRotation(angle As Single) As Matrix3x2
        Dim s As Single = Math.Sin(angle)
        Dim c As Single = Math.Cos(angle)
        Return New Matrix3x2(c, -s, 0,
                             s, c, 0)
    End Function

End Class
