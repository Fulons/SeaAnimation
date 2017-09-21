

Public Class Form1
    Private sky As Layer
    Private boat As Layer
    Private seaWave1 As Layer
    Private seaWave2 As Layer
    Private seaWave3 As Layer
    Private seaWave4 As Layer
    Private seaBerg As Layer
    Private seaBerg2 As Layer
    Private clouds As Layer
    Private rotor As Rotator

    Private resourcePath As New String("D:")

    Dim tick As Integer = 0

    Dim splits As Integer = 4
    Dim splitLength As Integer

    Dim currentTarget As Integer
    Dim transitioning As Boolean = True

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        sky.Update()
        boat.Update()
        seaWave1.Update()
        seaWave2.Update()
        seaWave3.Update()
        seaWave4.Update()
        seaBerg.Update()
        seaBerg2.Update()
        clouds.Update()

        rotor.Update()

        Me.Invalidate()
        tick += 1
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sky = New Layer(1193, 5880, 0, 25, System.Drawing.Image.FromFile(resourcePath + "\Images\SkyLine.png"))
        Dim animationLenght As Integer = 5880
        Dim numTransitions = 6
        Dim skyTransitions(numTransitions - 1) As Integer
        Dim currentAnimationPos = 0
        For i As Integer = 0 To numTransitions - 1
            skyTransitions(i) = currentAnimationPos
            currentAnimationPos -= animationLenght / numTransitions
        Next
        sky.AddTransitions(skyTransitions)
        boat = New Layer(1193, 588, 0, 0, System.Drawing.Image.FromFile(resourcePath + "\Images\seaShip.png"))
        seaWave1 = New Layer(1193, 588, 1, 0, System.Drawing.Image.FromFile(resourcePath + "\Images\seaWave1.png"))
        seaWave2 = New Layer(1193, 588, 3, 0, System.Drawing.Image.FromFile(resourcePath + "\Images\seaWave2.png"))
        seaWave3 = New Layer(1193, 588, 6, 0, System.Drawing.Image.FromFile(resourcePath + "\Images\seaWave3.png"))
        seaWave4 = New Layer(1193, 588, 12, 0, System.Drawing.Image.FromFile(resourcePath + "\Images\seaWave4.png"))
        seaBerg = New Layer(1193, 588, 2, 0, System.Drawing.Image.FromFile(resourcePath + "\Images\seaBerg.png"))
        seaBerg2 = New Layer(1193, 588, 1, 0, System.Drawing.Image.FromFile(resourcePath + "\Images\seaBerg.png"), 500)
        clouds = New Layer(1193, 588, 3, 0, System.Drawing.Image.FromFile(resourcePath + "\Images\clouds.png"))

        rotor = New Rotator(System.Drawing.Image.FromFile(resourcePath + "\Images\heliprop.png"), New Point(50, 100))

        splitLength = 5880 / splits
        currentTarget = 0
    End Sub

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


    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        sky.Draw(e.Graphics)
        clouds.Draw(e.Graphics)
        seaBerg2.Draw(e.Graphics)
        boat.Draw(e.Graphics)
        seaWave1.Draw(e.Graphics)
        seaWave2.Draw(e.Graphics)
        seaWave3.Draw(e.Graphics)
        seaWave4.Draw(e.Graphics)
        seaBerg.Draw(e.Graphics)
        rotor.Draw(e.Graphics)
        'DrawBezier(e.Graphics)

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then sky.TransitionNext()
        If e.KeyCode = Keys.D0 Then sky.Transition(0)
        If e.KeyCode = Keys.D1 Then sky.Transition(1)
        If e.KeyCode = Keys.D2 Then sky.Transition(2)
        If e.KeyCode = Keys.D3 Then sky.Transition(3)
        If e.KeyCode = Keys.D4 Then sky.Transition(4)
        If e.KeyCode = Keys.D5 Then sky.Transition(5)
        If e.KeyCode = Keys.D6 Then sky.Transition(6)
        If e.KeyCode = Keys.D7 Then sky.Transition(7)
        If e.KeyCode = Keys.D8 Then sky.Transition(8)
        If e.KeyCode = Keys.D9 Then sky.Transition(9)
        If e.KeyCode = Keys.Add Then sky.ySpeed += 20
        If e.KeyCode = Keys.Subtract Then sky.ySpeed -= 20
        If e.KeyCode = Keys.Up Then sky.img1PosY -= 20
        If e.KeyCode = Keys.Down Then sky.img1PosY += 20
    End Sub

End Class

Public MustInherit Class Animation
    Public MustOverride Sub Update()
    Public MustOverride Sub Draw(ByRef g As Graphics)
End Class


Public Class Rotator : Inherits Animation
    Private image As Image
    Private angle As Integer
    Private speed As Integer
    Private pos As Point

    Public Sub New(ByRef img As Image, pos As Point)
        Me.image = img
        Me.pos = pos
    End Sub
    Public Overrides Sub Draw(ByRef g As Graphics)
        'g.DrawImage(image, New Point(-image.Width / 2, -image.Height / 2))
        g.TranslateTransform(pos.X, pos.Y)
        g.RotateTransform(angle)
        g.FillPie(Brushes.Black, New Rectangle(New Point(-50, -50), New Size(100, 100)), 0, 20)
        g.FillPie(Brushes.Black, New Rectangle(New Point(-50, -50), New Size(100, 100)), 90, 20)
        g.FillPie(Brushes.Black, New Rectangle(New Point(-50, -50), New Size(100, 100)), 180, 20)
        g.FillPie(Brushes.Black, New Rectangle(New Point(-50, -50), New Size(100, 100)), 270, 20)
        g.ResetTransform()
    End Sub

    Public Overrides Sub Update()
        angle += 1
    End Sub
End Class

Public Class ImageSwitcher : Inherits Animation
    Private images As List(Of Image)
    Private speed As Integer
    Private fade As Boolean
    Private currentImageIndex As Integer
    Private pos As Point

    Public Sub AddImage(ByRef img As Image)
        images.Add(img)
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        g.DrawImage(images(currentImageIndex), pos)
    End Sub

    Public Overrides Sub Update()
        currentImageIndex += 1
    End Sub
End Class

Public Class Layer : Inherits Animation
    Private img1PosX As Integer
    Private img2PosX As Integer

    Public img1PosY As Integer
    Public img2PosY As Integer

    Private sizeX As Integer
    Private sizeY As Integer
    Private xSpeed As Integer
    Public ySpeed As Integer
    Private image As Image

    Private transitions() As Integer
    Private currentTransitionTarget As Integer = 0
    Private transitioning As Boolean = False

    Public Sub AddTransitions(transitions() As Integer)
        Me.transitions = transitions
    End Sub

    Public Sub Transition(transitionIndex As Integer)
        If transitions.Length > transitionIndex Then
            currentTransitionTarget = transitionIndex
            transitioning = True
        End If
    End Sub

    Public Sub TransitionNext()
        If Not transitioning Then
            currentTransitionTarget += 1
            If transitions.Length <= currentTransitionTarget Then
                currentTransitionTarget = 0
            End If
            transitioning = True
        End If
    End Sub

    Public max As Integer = 0
    Public min As Integer = 0

    Public Sub New(sizeX As Integer, sizeY As Integer, xSpeed As Single, ySpeed As Single, ByRef image As Image, Optional offset As Integer = 0)
        Me.img1PosX = 0 + offset
        If xSpeed = 0 Then
            Me.img2PosX = 0
        Else
            Me.img2PosX = sizeX + offset
        End If

        Me.img1PosY = 0
        If ySpeed = 0 Then
            Me.img2PosY = 0
        Else Me.img2PosY = sizeY
        End If


        Me.sizeX = sizeX
        Me.sizeY = sizeY

        Me.xSpeed = xSpeed
        Me.ySpeed = ySpeed
        Me.image = image
    End Sub

    Public Overrides Sub Update()
        If transitions IsNot Nothing Then
            If Not transitioning Then
                Return
            End If
        End If

        If img1PosX <= -sizeX Then
            img1PosX = img2PosX + sizeX
        End If
        If img2PosX <= -sizeX Then
            img2PosX = img1PosX + sizeX
        End If

        If img1PosY <= -sizeY Then
            img1PosY = img2PosY + sizeY
        End If
        If img2PosY <= -sizeY Then
            img2PosY = img1PosY + sizeY
        End If
        If max < img1PosY Then max = img1PosY
        If min > img1PosY Then min = img1PosY

        Dim img1PosXwas As Integer = img1PosX
        Dim img2PosXwas As Integer = img2PosX
        Dim img1PosYwas As Integer = img1PosY
        Dim img2PosYwas As Integer = img2PosY

        img1PosX -= xSpeed
        img2PosX -= xSpeed

        img1PosY -= ySpeed
        img2PosY -= ySpeed

        If transitions IsNot Nothing Then
            If transitioning Then
                If img1PosY < 0 Then
                    If (img1PosYwas >= transitions(currentTransitionTarget) AndAlso img1PosY < transitions(currentTransitionTarget)) Or
                        (img1PosYwas <= transitions(currentTransitionTarget) AndAlso img1PosY > transitions(currentTransitionTarget)) Then
                        transitioning = False
                    End If
                    If img2PosYwas > 0 AndAlso img2PosY < 0 Then
                        If (img2PosYwas >= transitions(currentTransitionTarget) AndAlso img2PosY < transitions(currentTransitionTarget)) Or
                           (img2PosYwas <= transitions(currentTransitionTarget) AndAlso img2PosY > transitions(currentTransitionTarget)) Then
                            transitioning = False
                        End If
                    End If
                Else
                    If (img2PosYwas >= transitions(currentTransitionTarget) AndAlso img2PosY < transitions(currentTransitionTarget)) Or
                   (img2PosYwas <= transitions(currentTransitionTarget) AndAlso img2PosY > transitions(currentTransitionTarget)) Then
                        transitioning = False
                    End If
                    If img1PosYwas > 0 AndAlso img1PosY < 0 Then
                        If (img1PosYwas >= transitions(currentTransitionTarget) AndAlso img1PosY < transitions(currentTransitionTarget)) Or
                           (img1PosYwas <= transitions(currentTransitionTarget) AndAlso img1PosY > transitions(currentTransitionTarget)) Then
                            transitioning = False
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Overrides Sub Draw(ByRef g As Graphics)
        g.DrawImage(image, img1PosX, img1PosY, image.Width, image.Height)
        g.DrawImage(image, img2PosX, img2PosY, image.Width, image.Height)
    End Sub
End Class
