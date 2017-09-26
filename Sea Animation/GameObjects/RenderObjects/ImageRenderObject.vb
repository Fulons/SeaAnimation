Imports System.Xml
Imports System.Drawing.Drawing2D

Public Class ImageRenderObject : Inherits RenderObject
#Region "Member variables"
    Public img As Image     'Image that is rendered
    Public path As String   'Path of the image on disk
#End Region

#Region "Constructors"
    'Load image with no path (no image placeholder should be used)
    Public Sub New(img As Image, Optional centered As Boolean = False)
        Me.path = "NoPath"
        Me.img = img
        Me.centered = centered
    End Sub

    Public Sub New(path As String, Optional centered As Boolean = False)
        Me.path = path
        Me.img = Image.FromFile(path)
        Me.centered = centered
    End Sub

    'Load image from XmlNode
    Public Sub New(node As XmlNode)
        Me.Load(node)
    End Sub
#End Region
#Region "Public ovverides methods"
    'Render image to screen
    Public Overrides Sub Render(ByRef g As Graphics)
        If centered = True Then
            g.DrawImage(img, New RectangleF(-img.Width / 2, -img.Height / 2, img.Width, img.Height))
        Else
            g.DrawImage(img, New RectangleF(0, 0, img.Width, img.Height))
        End If
    End Sub

    'Render preview to Graphics (g)
    Public Overrides Sub RenderPreview(ByRef g As Graphics, size As Vector2)
        Dim scaleX As Double = img.Size.Width / size.X
        Dim scaleY As Double = img.Size.Height / size.Y
        If (scaleX > scaleY) Then
            g.DrawImage(img, New RectangleF(0, (size.Y - img.Size.Height / scaleX) / 2, img.Size.Width / scaleX, img.Size.Height / scaleX))
        Else
            g.DrawImage(img, New RectangleF((size.X - img.Size.Width / scaleY) / 2, 0, img.Size.Width / scaleY, img.Size.Height / scaleY))
        End If
    End Sub

    'Loads values from XmlNode
    Public Overrides Sub Load(node As XmlNode)
        For Each attribute As XmlAttribute In node.Attributes
            If attribute.Name = "Centered" Then
                Me.centered = attribute.Value
            ElseIf attribute.Name = "Path" Then
                Me.path = attribute.Value
                If Me.path = "NoPath" Then
                    Me.img = New Bitmap(200, 200)
                    Dim g As Graphics = Graphics.FromImage(img)
                    g.SmoothingMode = SmoothingMode.AntiAlias
                    Dim pen As Pen = New Pen(Color.Red, 5)
                    g.DrawLine(pen, 0, 0, img.Width, img.Height)
                    g.DrawLine(pen, img.Width, 0, 0, img.Height)
                    pen.Width = 10
                    g.DrawRectangle(pen, 0, 0, img.Width, img.Height)
                Else
                    Me.img = Image.FromFile(Me.path)
                End If
            End If
        Next
    End Sub

    'Creates an XmlNode represention of the object
    Public Overrides Function Save(doc As XmlDocument) As XmlNode
        Dim n As XmlNode = doc.CreateNode(XmlNodeType.Element, "RenderObject", "")

        Dim attribute As XmlAttribute = doc.CreateAttribute("Type")
        attribute.Value = "ImageRenderObject"
        n.Attributes.Append(attribute)

        'centered
        attribute = doc.CreateAttribute("Centered")
        attribute.Value = Me.centered.ToString
        n.Attributes.Append(attribute)

        attribute = doc.CreateAttribute("Path")
        attribute.Value = path
        n.Attributes.Append(attribute)

        Return n
    End Function
#End Region
End Class