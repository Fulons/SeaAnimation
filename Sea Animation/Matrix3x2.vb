Public Class Matrix3x2

    Public M11 As Single
    Public M12 As Single

    Public M21 As Single
    Public M22 As Single

    Public M31 As Single
    Public M32 As Single

    Public Sub New(M11 As Single, M12 As Single, M21 As Single, M22 As Single, M31 As Single, M32 As Single)
        Me.M11 = M11
        Me.M12 = M12

        Me.M21 = M21
        Me.M22 = M22

        Me.M31 = M31
        Me.M32 = M32
    End Sub

    Public Shared Function Identity() As Matrix3x2
        Return New Matrix3x2(1, 0, 0, 1, 0, 0)
    End Function

    Public Shared Operator *(mat1 As Matrix3x2, mat2 As Matrix3x2) As Matrix3x2
        Return New Matrix3x2(mat1.M11 * mat2.M11 + mat1.M12 * mat2.M21 + 0, mat1.M11 * mat2.M12 + mat1.M12 * mat2.M22 + 0)
    End Operator

    Public Shared Function CreateTranslation(vec As Vector2) As Matrix3x2

    End Function

    Public Shared Function CreateRotation(angle As Single) As Matrix3x2

    End Function

End Class
