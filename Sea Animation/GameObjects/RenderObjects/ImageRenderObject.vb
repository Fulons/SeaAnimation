Public Class ImageRenderObject : Inherits RenderObject
    Public img As Image

    Public Sub New(img As Image, Optional centered As Boolean = False)
        Me.img = img
        Me.centered = centered
    End Sub

    Public Overrides Sub Render(ByRef g As Graphics)
        If centered = True Then
            g.DrawImage(img, New RectangleF(-img.Width / 2, -img.Height / 2, img.Width, img.Height))
        Else
            g.DrawImage(img, New RectangleF(0, 0, img.Width, img.Height))
        End If
    End Sub

    Public Overrides Sub RenderPreview(ByRef g As Graphics, size As Vector2)
        Dim scaleX As Double = img.Size.Width / size.X
        Dim scaleY As Double = img.Size.Height / size.Y
        If (scaleX > scaleY) Then
            g.DrawImage(img, New RectangleF(0, (size.Y - img.Size.Height / scaleX) / 2, img.Size.Width / scaleX, img.Size.Height / scaleX))
        Else
            g.DrawImage(img, New RectangleF((size.X - img.Size.Width / scaleY) / 2, 0, img.Size.Width / scaleY, img.Size.Height / scaleY))
        End If
    End Sub
End Class