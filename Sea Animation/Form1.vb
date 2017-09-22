Imports System.Windows.Input

Public Class Form1
    Private animations As New List(Of Animation)
    Private resourcePath As New String("G:\")
    Private tick As Integer = 0
    Private sw As New Stopwatch
    Private ticksLastFrame As Long

    Private Function AddAnimation(ByRef a As Animation) As Animation
        animations.Add(a)
        Return a
    End Function

    Private key(255) As Boolean

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim msPerFrame As Double = (sw.ElapsedTicks - ticksLastFrame) / TimeSpan.TicksPerSecond
        ticksLastFrame = sw.ElapsedTicks
        For Each a In animations
            a.Update(msPerFrame)
        Next
        Me.Invalidate()
        tick += 1

        Dim sp As Integer = 10
        If key(Keys.Right) = True Then pos += New Vec2(-sp, 0)
        If key(Keys.Left) Then pos += New Vec2(sp, 0)
        If key(Keys.Down) Then pos += New Vec2(0, -sp)
        If key(Keys.Up) Then pos += New Vec2(0, sp)
        t.pos = pos
    End Sub

    Private t As TranslationAnimation

    Private Sub CreateHelicopter()
        t = AddAnimation(New TranslationAnimation(Image.FromFile(resourcePath + "Images\CityScroll.png"), New Vec2(0, 0)))
        t.AddTarget(New Vec2(0, 0))
        t.posAfterLastTarget = New Vec2
        t.speed = 100
        t.repeatX = True
        t.repeatY = True

        'Dim s As StaticAnimation = AddAnimation(New StaticAnimation(Image.FromFile(resourcePath + "Images\Helli Anim\helli_1.png"), New Vec2(100, 100)))
        Dim i As ImageSwitcher = AddAnimation(New ImageSwitcher(New Vec2(500, 100)))
        'i.AddImage(Image.FromFile(resourcePath + "Images\Helli Anim\helli_1.png"))
        i.AddImage(Image.FromFile(resourcePath + "Images\Helli Anim\helli_2.png"))
        i.AddImage(Image.FromFile(resourcePath + "Images\Helli Anim\helli_3.png"))
        i.AddImage(Image.FromFile(resourcePath + "Images\Helli Anim\helli_4.png"))
        i.AddImage(Image.FromFile(resourcePath + "Images\Helli Anim\helli_5.png"))
        Dim r As Rotator = AddAnimation(New Rotator(Image.FromFile(resourcePath + "Images\Helli Anim\helli_prop.png"), New Vec2(700, 140))) '200, 40
        r.speed = 1000

        Animation.clientRect = Me.DisplayRectangle
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateHelicopter()

        sw.Start()
        ticksLastFrame = sw.ElapsedTicks
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        For a As Integer = 0 To animations.Count() - 1
            animations(a).Draw(e.Graphics)
        Next
    End Sub
    Private pos As New Vec2

    Private Sub DrawBezier(ByRef g As System.Drawing.Graphics)
        Rnd()
        Dim pen As Pen = Pens.WhiteSmoke
        Dim points As New List(Of Point)

        Dim iterations As Integer = 4

        Dim upperBound As Integer = 10
        Dim lowerBound As Integer = 0

        Dim waveWidth As Integer = Me.Width / (iterations * 6)
        For i As Integer = 0 To iterations
            Dim width As Integer = waveWidth
            Dim totalWidth As New Integer
            points.Add(New Point(Me.Width / (iterations * 6) * (i * 6 + 0), 300 + CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound))
            points.Add(New Point(Me.Width / (iterations * 6) * (i * 6 + 1), 350 + CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound))
            points.Add(New Point(Me.Width / (iterations * 6) * (i * 6 + 2), 350 + CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound))

            points.Add(New Point(Me.Width / (iterations * 6) * (i * 6 + 3), 300 + CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound))
            points.Add(New Point(Me.Width / (iterations * 6) * (i * 6 + 4), 250 + CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound))
            points.Add(New Point(Me.Width / (iterations * 6) * (i * 6 + 5), 250 + CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound))



        Next
        points.Add(New Point(Me.Width / iterations * iterations, 300 + CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound))

        'Dim start As New Point(100, 200)
        'Dim control1 As New Point(300, 600)
        'Dim control2 As New Point(500, 150)
        'Dim control3 As New Point(700, 100)
        'Dim control4 As New Point(900,)
        'Dim control5 As New Point(1100)

        'Dim points As Point() = {start, control1, control2, control3, control4, control5}
        g.DrawBeziers(pen, points.ToArray)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue < 255 Then key(e.KeyValue) = True
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue < 255 Then key(e.KeyValue) = False
    End Sub
End Class

Public MustInherit Class Animation
    Public Shared clientRect As Rectangle
    Public MustOverride Sub Update(sLastFrame As Double)
    Public MustOverride Sub Draw(ByRef g As Graphics)
End Class

Public Class StaticAnimation : Inherits Animation
    Public image As Image
    Public pos As Vec2

    Public Sub New(image As Image)
        Me.image = image
    End Sub

    Public Sub New(image As Image, pos As Vec2)
        Me.image = image
        Me.pos = pos
    End Sub

    Public Overrides Sub Update(sLastFrame As Double)

    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        g.DrawImage(image, pos.AsPoint())
    End Sub
End Class

Public Class Rotator : Inherits Animation
    Private image As Image
    Private angle As Integer
    Public speed As Integer
    Public pos As Vec2

    Public Sub New(ByRef img As Image, pos As Vec2)
        Me.image = img
        Me.pos = pos
        Me.speed = 1
    End Sub
    Public Overrides Sub Draw(ByRef g As Graphics)
        g.TranslateTransform(pos.x, pos.y)
        g.RotateTransform(angle)
        g.DrawImage(image, New Rectangle(-image.Width / 2, -image.Height / 2, image.Width, image.Height))
        g.ResetTransform()
    End Sub

    Public Overrides Sub Update(sLastFrame As Double)
        angle += speed * sLastFrame
    End Sub
End Class

Public Class ImageSwitcher : Inherits Animation
    Private images As New List(Of Image)
    Private speed As Integer
    Private fade As Boolean
    Private currentImageIndex As Integer
    Private pos As New Vec2

    Public Sub New()

    End Sub

    Public Sub New(pos As Vec2)
        Me.pos = pos
    End Sub

    Public Sub AddImage(ByRef img As Image)
        images.Add(img)
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        g.DrawImage(images(currentImageIndex), pos.AsPoint())
    End Sub

    Public Overrides Sub Update(sLastFrame As Double)
        currentImageIndex += 1
        If currentImageIndex >= images.Count() Then
            currentImageIndex = 0
        End If
    End Sub
End Class

Public Class TranslationAnimation : Inherits Animation
#Region "New stuff"
    Public image As Image
    Public pos As New Vec2
    Public targets As New List(Of Vec2)
    Public speed As Double = 2
    Public currentTarget As Integer = 0
    Public repeatX As Boolean = True
    Public repeatY As Boolean = True
    Public posAfterLastTarget As Vec2

    Private targetReached As Boolean = False
    Private loopTargets As Boolean = False
#End Region

    Public Sub New(ByRef image As Image)
            Me.image = image
        End Sub

    Public Sub New(ByRef image As Image, pos As Vec2)
        Me.image = image
        Me.pos = pos
    End Sub

    Public Sub SetCurrentTargetPos(ByVal pos As Vec2)
        targets(currentTarget) = pos
        targetReached = False
    End Sub

    Public Sub NextTarget()
        currentTarget += 1
        If currentTarget >= targets.Count() Then
            If posAfterLastTarget IsNot Nothing Then
                pos = posAfterLastTarget
            End If
            currentTarget = 0
        End If
        targetReached = False
    End Sub

    Public Sub AddTarget(pos As Vec2)
        targets.Add(pos)
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        'Draw image in diagonal direction from image
        If repeatX AndAlso repeatY Then
            If pos.x > 0 Then
                If pos.y > 0 Then
                    g.DrawImage(image, New RectangleF(pos.x - image.Width, pos.y - image.Height, image.Width, image.Height))
                Else
                    g.DrawImage(image, New RectangleF(pos.x - image.Width, pos.y + image.Height, image.Width, image.Height))
                End If
            Else
                If pos.y > 0 Then
                    g.DrawImage(image, New RectangleF(pos.x + image.Width, pos.y - image.Height, image.Width, image.Height))
                Else
                    g.DrawImage(image, New RectangleF(pos.x + image.Width, pos.y + image.Height, image.Width, image.Height))
                End If
            End If
        End If

        'Draw image horisontal direction from image
        If repeatX Then
            If pos.x > 0 Then
                g.DrawImage(image, New RectangleF(pos.x - image.Width, pos.y, image.Width, image.Height))
            Else
                g.DrawImage(image, New RectangleF(pos.x + image.Width, pos.y, image.Width, image.Height))
            End If
        End If

        'Draw image in vertical direction from image
        If repeatY Then
            If pos.y > 0 Then
                g.DrawImage(image, New RectangleF(pos.x, pos.y - image.Height, image.Width, image.Height))
            Else
                g.DrawImage(image, New RectangleF(pos.x, pos.y + image.Height, image.Width, image.Height))
            End If
        End If
        'Draw image
        g.DrawImage(image, New RectangleF(pos.x, pos.y, image.Width, image.Height))
    End Sub

    Public Overrides Sub Update(sLastFrame As Double)
        If repeatX Then
            If pos.x >= image.Width Then
                pos.x -= image.Width
            ElseIf pos.x < -image.Width Then
                pos.x += image.Width
            End If
        End If
        If repeatY Then
            If pos.y >= image.Height Then
                pos.y -= image.Height
            ElseIf pos.y < -image.Height Then
                pos.y += image.Height
            End If
        End If

        If targetReached Then Return
        Dim posWas As Vec2 = pos
        Dim target As Vec2 = targets(currentTarget)
        pos += Vec2.Normalize(target - pos) * speed * sLastFrame

        Dim dot As Double = Vec2.Dot(pos - target, target)
        Dim dotWas As Double = Vec2.Dot(posWas - target, target)

        If (dot < 0 AndAlso dotWas > 0) Or
           (dot > 0 AndAlso dotWas < 0) Or
           (dot = 0 AndAlso dotWas = 0) Then
            targetReached = True
            If loopTargets Then
                Me.NextTarget()
            End If
        End If
    End Sub
End Class

'Public Class Layer : Inherits Animation
'    Private img1PosX As Integer
'    Private img2PosX As Integer
'
'    Public img1PosY As Integer
'    Public img2PosY As Integer
'
'    Private sizeX As Integer
'    Private sizeY As Integer
'    Private xSpeed As Integer
'    Public ySpeed As Integer
'    Private image As Image
'
'    Private transitions() As Integer
'    Private currentTransitionTarget As Integer = 0
'    Private transitioning As Boolean = False
'
'    Public Sub AddTransitions(transitions() As Integer)
'Me.transitions = transitions
'End Sub
'
'    Public Sub Transition(transitionIndex As Integer)
'If transitions.Length > transitionIndex Then
'currentTransitionTarget = transitionIndex
'transitioning = True
'End If
'End Sub
'
'    Public Sub TransitionNext()
'If Not transitioning Then
'currentTransitionTarget += 1
'If transitions.Length <= currentTransitionTarget Then
'currentTransitionTarget = 0
'End If
'transitioning = True
'End If
'End Sub
'
'    Public max As Integer = 0
'    Public min As Integer = 0
'
'    Public Sub New(sizeX As Integer, sizeY As Integer, xSpeed As Single, ySpeed As Single, ByRef image As Image, Optional offset As Integer = 0)
'Me.img1PosX = 0 + offset
'If xSpeed = 0 Then
'Me.img2PosX = 0
'Else
'Me.img2PosX = sizeX + offset
'End If
'
'Me.img1PosY = 0
'If ySpeed = 0 Then
'Me.img2PosY = 0
'Else : Me.img2PosY = sizeY
'End If
'
'
'Me.sizeX = sizeX
'Me.sizeY = sizeY
'
'Me.xSpeed = xSpeed
'Me.ySpeed = ySpeed
'Me.image = image
'
'
'End Sub
'
'    Public Overrides Sub Update(sLastFrame As Double)
'If transitions IsNot Nothing Then
'    If Not transitioning Then
'        Return
'    End If
'End If
'
'If img1PosX <= -image.Width Then
'    'img1PosX = img2PosX + image.Width
'    If img1PosX > 0 Then
'        img2PosX = img1PosX + image.Width
'    Else
'        img2PosX = img1PosX - image.Width
'    End If
'End If
'
''If img2PosX <= -sizeX Then
''    img2PosX = img1PosX + sizeX
''End If
'
'If img1PosY <= -sizeY Then
'    img1PosY = img2PosY + sizeY
'End If
'If img2PosY <= -sizeY Then
'    img2PosY = img1PosY + sizeY
'End If
'
'If max < img1PosY Then max = img1PosY
'If min > img1PosY Then min = img1PosY
'
'Dim img1PosXwas As Integer = img1PosX
'Dim img2PosXwas As Integer = img2PosX
'Dim img1PosYwas As Integer = img1PosY
'Dim img2PosYwas As Integer = img2PosY
'
'img1PosX -= xSpeed
'img2PosX -= xSpeed
'
'img1PosY -= ySpeed
'img2PosY -= ySpeed
'
'If transitions IsNot Nothing Then
'    If transitioning Then
'        If img1PosY < 0 Then
'            If (img1PosYwas >= transitions(currentTransitionTarget) AndAlso img1PosY < transitions(currentTransitionTarget)) Or
'                (img1PosYwas <= transitions(currentTransitionTarget) AndAlso img1PosY > transitions(currentTransitionTarget)) Then
'                transitioning = False
'            End If
'            If img2PosYwas > 0 AndAlso img2PosY < 0 Then
'                If (img2PosYwas >= transitions(currentTransitionTarget) AndAlso img2PosY < transitions(currentTransitionTarget)) Or
'                   (img2PosYwas <= transitions(currentTransitionTarget) AndAlso img2PosY > transitions(currentTransitionTarget)) Then
'                    transitioning = False
'                End If
'            End If
'        Else
'            If (img2PosYwas >= transitions(currentTransitionTarget) AndAlso img2PosY < transitions(currentTransitionTarget)) Or
'           (img2PosYwas <= transitions(currentTransitionTarget) AndAlso img2PosY > transitions(currentTransitionTarget)) Then
'                transitioning = False
'            End If
'            If img1PosYwas > 0 AndAlso img1PosY < 0 Then
'                If (img1PosYwas >= transitions(currentTransitionTarget) AndAlso img1PosY < transitions(currentTransitionTarget)) Or
'                   (img1PosYwas <= transitions(currentTransitionTarget) AndAlso img1PosY > transitions(currentTransitionTarget)) Then
'                    transitioning = False
'                End If
'            End If
'        End If
'    End If
'End If
'End Sub
'
'    Public Overrides Sub Draw(ByRef g As Graphics)
'g.DrawImage(image, img1PosX, img1PosY, image.Width, image.Height)
'g.DrawImage(image, img2PosX, img2PosY, image.Width, image.Height)

'Draw code

'If repeatX AndAlso repeatY Then
'    If pos.x > 0 Then
'        g.DrawImage(image, New Point(pos.x - image.Width, pos.y))
'        'draw other x image at pos.x - image.width
'        If pos.y > 0 Then
'            g.DrawImage(image, New Point(pos.x - image.Width, pos.y - image.Height))
'            'draw diag image at pos.x - image.width, pos.y - image.height
'        Else
'            'draw diag image at pos.x - image.width, pos.y + image.height
'            g.DrawImage(image, New Point(pos.x - image.Width, pos.y + image.Height))
'        End If
'    Else
'        g.DrawImage(image, New Point(pos.x + image.Width, pos.y))
'        If pos.y > 0 Then
'            g.DrawImage(image, New Point(pos.x + image.Width, pos.y - image.Height))
'            'draw diag image at pos.x + image.width, pos.y - image.height
'        Else
'            g.DrawImage(image, New Point(pos.x + image.Width, pos.y + image.Height))
'            'draw diag image at pos.x + image.width, pos.y + image.height
'        End If
'    End If
'ElseIf repeatX Then
'    If pos.x > 0 Then
'        g.DrawImage(image, New Point(pos.x - image.Width, pos.y))
'    Else
'        g.DrawImage(image, New Point(pos.x + image.Width, pos.y))
'    End If
'ElseIf repeatY Then
'    If pos.y > 0 Then
'        g.DrawImage(image, New Point(pos.x, pos.y - image.Height))
'    Else
'        g.DrawImage(image, New Point(pos.x, pos.y + image.Height))
'    End If
'End If

'End Sub
'End Class

