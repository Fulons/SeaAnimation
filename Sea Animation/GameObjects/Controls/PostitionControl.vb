Imports System.ComponentModel
Public Class PostitionControl



    Event XPosChanged(val As Double)
    Event YPosChanged(val As Double)

    Public Sub SetVec(vec As Vector2)
        txtXPos.Text = vec.X.ToString
        txtYPos.Text = vec.Y.ToString
    End Sub


    Private Sub txtXPos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtXPos.KeyPress, txtYPos.KeyPress
        Dim c As Integer = Asc(e.KeyChar)
        If Asc(e.KeyChar) <> 8 AndAlso Asc(e.KeyChar) <> 46 AndAlso Asc(e.KeyChar) <> 45 AndAlso (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtXPos_TextChanged(sender As Object, e As EventArgs) Handles txtXPos.TextChanged
        If String.IsNullOrEmpty(txtXPos.Text) Then
            RaiseEvent XPosChanged(0)
        Else
            Try
                RaiseEvent XPosChanged(txtXPos.Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub txtYPos_TextChanged(sender As Object, e As EventArgs) Handles txtYPos.TextChanged
        If String.IsNullOrEmpty(txtYPos.Text) Then
            RaiseEvent YPosChanged(0)
        Else
            Try
                RaiseEvent YPosChanged(txtYPos.Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub txtYPos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtYPos.KeyDown, txtXPos.KeyDown
        If e.KeyCode = Keys.Up Then
            txtYPos.Text = Convert.ToDouble(txtYPos.Text) - 1
            e.Handled = True
        ElseIf e.KeyCode = Keys.Down Then
            txtYPos.Text = Convert.ToDouble(txtYPos.Text) + 1
            e.Handled = True
        ElseIf e.KeyCode = Keys.Right Then
            txtXPos.Text = Convert.ToDouble(txtXPos.Text) + 1
            e.Handled = True
        ElseIf e.KeyCode = Keys.Left Then
            txtXPos.Text = Convert.ToDouble(txtXPos.Text) - 1
            e.Handled = True
        End If
    End Sub
End Class
