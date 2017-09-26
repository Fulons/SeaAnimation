Imports System.Numerics
Imports System.Xml

Public Class Form1
    'Public animations As New List(Of Animation)
    Public resourcePath As New String("G:\Data\")
    Public tick As Integer = 0
    Public sw As New Stopwatch
    Public ticksLastFrame As Long
    Public key(255) As Boolean
    'Private t As TranslationAnimation

    'Private Function AddAnimation(ByRef a As Animation) As Animation
    '    animations.Add(a)
    '    Return a
    'End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim msPerFrame As Double = (sw.ElapsedTicks - ticksLastFrame) / Stopwatch.Frequency
        ticksLastFrame = sw.ElapsedTicks

        For Each g In gameObjects
            g.Update(msPerFrame)
        Next

        Me.Invalidate()
        tick += 1
    End Sub

    Public gameObjects As New List(Of GameObject)

    Public selectedGameObject As GameObject
    Public selectedRenderable As Renderable
    Public selectedAnimation As Animation

    Public Sub SelectGameObjectRecursive(name As String, ByRef go As GameObject)
        If name = go.name Then
            selectedGameObject = go
        Else
            For Each child As GameObject In go.children
                SelectGameObjectRecursive(name, child)
            Next
        End If
    End Sub

    Public Sub SelectGameObject(name As String)
        selectedGameObject = Nothing
        selectedRenderable = Nothing
        selectedAnimation = Nothing
        For Each go As GameObject In gameObjects
            SelectGameObjectRecursive(name, go)
        Next
    End Sub

    Public Sub SelectRenderable(id As Guid)
        selectedRenderable = Nothing
        selectedAnimation = Nothing
        SelectRenderableRecursive(id, selectedGameObject.renderable)
    End Sub

    Private Sub SelectRenderableRecursive(id As Guid, ByRef r As Renderable)
        If r.id = id Then
            selectedRenderable = r
            Return
        End If
        For Each child As Renderable In r.children
            SelectRenderableRecursive(id, child)
        Next
    End Sub

    Public Sub SelectAnimation(id As Guid)
        selectedAnimation = Nothing
        SelectAnimationRecursively(id, selectedRenderable.animation)
    End Sub

    Private Function GetGameObjectRecursively(name As String, ByRef go As List(Of GameObject), ByRef parent As GameObject, Optional remove As Boolean = False) As GameObject
        For i As Integer = 0 To go.Count() - 1
            If go(i).name = name Then
                If remove = True Then
                    If parent IsNot Nothing Then
                        Dim ret As GameObject = go(i)
                        parent.children.RemoveAt(i)
                        Return ret
                    Else
                        Dim ret As GameObject = go(i)
                        Me.gameObjects.RemoveAt(i)
                        Return ret
                    End If
                    Return go(i)
                End If
            Else
                Dim g As GameObject = GetGameObjectRecursively(name, go(i).children, go(i), remove)
                If g IsNot Nothing Then Return g
            End If
        Next
        Return Nothing
    End Function

    Public Function GetGameObject(name As String) As GameObject
        Return GetGameObjectRecursively(name, gameObjects, Nothing)
    End Function

    Public Function GetAndRemoveGameObject(name As String) As GameObject
        Return GetGameObjectRecursively(name, gameObjects, Nothing, True)
    End Function

    Private Function GetRenderableRecursively(id As Guid, r As Renderable, parent As Renderable, Optional remove As Boolean = False) As Renderable
        If r.id = id Then
            If parent IsNot Nothing AndAlso remove Then parent.children.Remove(r)
            Return r
        End If
        For Each child In r.children
            Dim ret As Renderable = GetRenderableRecursively(id, child, r, remove)
            If ret IsNot Nothing Then Return ret
        Next
        Return Nothing
    End Function

    Public Function GetRenderable(id As Guid) As Renderable
        Return GetRenderableRecursively(id, selectedGameObject.renderable, Nothing)
    End Function

    Public Function GetAndRemoveRenderable(id As Guid) As Renderable
        Return GetRenderableRecursively(id, selectedGameObject.renderable, Nothing, True)
    End Function

    Private Function GetAnimationRecursively(id As Guid, a As Animation, parent As Animation, Optional remove As Boolean = False) As Animation
        If a.id = id Then
            If remove Then parent.children.Remove(a)
            Return a
        End If
        For Each child In a.children
            Dim ret As Animation = GetAnimationRecursively(id, child, a, remove)
            If ret IsNot Nothing Then Return ret
        Next
        Return Nothing
    End Function

    Public Function GetAnimation(id As Guid) As Animation
        Return GetAnimationRecursively(id, selectedRenderable.animation, Nothing)
    End Function

    Public Function GetAndRemoveAnimation(id As Guid) As Animation
        Return GetAnimationRecursively(id, selectedRenderable.animation, Nothing, True)
    End Function

    Private Sub SelectAnimationRecursively(id As Guid, ByRef a As Animation)
        If a.id = id Then
            selectedAnimation = a
        End If
        For Each child As Animation In a.children
            SelectAnimationRecursively(id, child)
        Next
    End Sub

    Private Sub CreateHelicopter()
        Dim ro As New ImageRenderObject("G:\Images\Helli Anim\helli_1.png")
        Dim rotorImage As New ImageRenderObject("G:\Images\Helli Anim\helli_prop.png", True)

        Dim a As RotatorAnimation = New RotatorAnimation()

        Dim rotor As New Renderable
        rotor.where = New Vector2(150, 50)
        rotor.what = rotorImage
        rotor.animation = a

        Dim r As New Renderable
        r.where = New Vector2(100, 100)
        r.what = ro
        r.children.Add(rotor)

        Dim g As New GameObject
        g.name = "FirstGameObject"
        g.pos = New Vector2(0, 0)
        g.renderable = r

        gameObjects.Add(g)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CreateHelicopter()
        sw.Start()

        ticksLastFrame = sw.ElapsedTicks
        'Editor.Show()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'For a As Integer = 0 To animations.Count() - 1
        '    animations(a).Draw(e.Graphics)
        'Next

        For g As Integer = 0 To gameObjects.Count() - 1
            gameObjects(g).Draw(e.Graphics)
        Next
        'Editor.Activate()
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

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = "E" Or e.KeyChar = "e" Then Editor.Show()
    End Sub

    Public Sub LoadXml(ByRef doc As XmlDocument)
        For Each node As XmlNode In doc.ChildNodes
            If node.Name = "Scene" Then
                For Each n As XmlNode In node.ChildNodes
                    If n.Name = "GameObject" Then
                        gameObjects.Add(New GameObject(n))
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub SaveXml(ByRef doc As XmlDocument)
        Dim n As XmlNode = doc.CreateElement("Scene")
        For Each go As GameObject In gameObjects
            n.AppendChild(go.Save(doc))
        Next
        doc.AppendChild(n)
    End Sub

End Class




'Public Class StaticAnimation : Inherits Animation
'    Public image As Image
'    Public pos As Vec2
'
'    Public Sub New(name As String, image As Image)
'        MyBase.New(name)
'        Me.image = image
'    End Sub
'
'    Public Sub New(name As String, image As Image, pos As Vec2)
'        MyBase.New(name)
'        Me.image = image
'        Me.pos = pos
'    End Sub
'
'    Public Overrides Sub Update(sLastFrame As Double)
'
'    End Sub
'
'    Public Overrides Sub Draw(ByRef g As Graphics)
'        g.DrawImage(image, pos.AsPoint())
'    End Sub
'End Class
'
'Public Class Rotator : Inherits Animation
'    Public image As Image
'    Public angle As Integer
'    Public speed As Integer
'    Public pos As Vec2
'
'    Public Sub New(name As String, ByRef img As Image, pos As Vec2)
'        MyBase.New(name)
'        Me.image = img
'        Me.pos = pos
'        Me.speed = 1
'    End Sub
'    Public Overrides Sub Draw(ByRef g As Graphics)
'        g.TranslateTransform(pos.x, pos.y)
'        g.RotateTransform(angle)
'        g.DrawImage(image, New Rectangle(-image.Width / 2, -image.Height / 2, image.Width, image.Height))
'        g.ResetTransform()
'    End Sub
'
'    Public Overrides Sub Update(sLastFrame As Double)
'        angle += speed * sLastFrame
'    End Sub
'End Class
'
'Public Class NewRotator : Inherits Animation
'    Public rend As Animation
'    Public angle As Double
'    Public Speed As Integer
'
'
'    Public Sub New()
'        MyBase.New("Rotator")
'    End Sub
'
'    Public Overrides Sub Update(sLastFrame As Double)
'        angle += Speed * sLastFrame
'    End Sub
'
'    Public Overrides Sub Draw(ByRef g As Graphics)
'        g.RotateTransform(angle)
'        rend.Draw(g)
'    End Sub
'End Class
'
'Public Class ImageSwitcherAnimation : Inherits Animation
'    Public images As New List(Of Image)
'    Public speed As Integer
'    Public fade As Boolean
'    Public currentImageIndex As Integer
'    Public pos As New Vec2
'
'    Public Sub New(name As String)
'        MyBase.New(name)
'    End Sub
'
'    Public Sub New(name As String, pos As Vec2)
'        MyBase.New(name)
'        Me.pos = pos
'    End Sub
'
'    Public Sub AddImage(ByRef img As Image)
'        images.Add(img)
'    End Sub
'
'    Public Overrides Sub Draw(ByRef g As Graphics)
'        g.DrawImage(images(currentImageIndex), pos.AsPoint())
'    End Sub
'
'    Public Overrides Sub Update(sLastFrame As Double)
'        currentImageIndex += 1
'        If currentImageIndex >= images.Count() Then
'            currentImageIndex = 0
'        End If
'    End Sub
'End Class
'
'Public Class TranslationAnimation : Inherits Animation
'#Region "New stuff"
'    Public image As Image
'    Public pos As New Vec2
'    Public targets As New List(Of Vec2)
'    Public speed As Double = 2
'    Public currentTarget As Integer = 0
'    Public posAfterLastTarget As Vec2
'
'    Public repeatX As Boolean = True
'    Public repeatY As Boolean = True
'
'    Public targetReached As Boolean = False
'    Public loopTargets As Boolean = False
'#End Region
'
'    Public Sub New(name As String, ByRef image As Image)
'        MyBase.New(name)
'        Me.image = image
'    End Sub
'
'    Public Sub New(name As String, ByRef image As Image, pos As Vec2)
'        MyBase.New(name)
'        Me.image = image
'        Me.pos = pos
'    End Sub
'
'    Public Sub SetCurrentTargetPos(ByVal pos As Vec2)
'        targets(currentTarget) = pos
'        targetReached = False
'    End Sub
'
'    Public Sub SetCurrentTargetIndex(i As Integer)
'        If i < targets.Count Then
'            currentTarget = i
'            targetReached = False
'        End If
'    End Sub
'
'    Public Sub NextTarget()
'        currentTarget += 1
'        If currentTarget >= targets.Count() Then
'            If posAfterLastTarget IsNot Nothing Then
'                pos = posAfterLastTarget
'            End If
'            currentTarget = 0
'        End If
'        targetReached = False
'    End Sub
'
'    Public Sub AddTarget(pos As Vec2)
'        targets.Add(pos)
'    End Sub
'
'    Public Sub RemoveTarget(i As Integer)
'        If i < targets.Count Then
'            targets.RemoveAt(i)
'        End If
'    End Sub
'
'    Public Overrides Sub Draw(ByRef g As Graphics)
'        'Draw image in diagonal direction from image
'        If repeatX AndAlso repeatY Then
'            If pos.x > 0 Then
'                If pos.y > 0 Then
'                    g.DrawImage(image, New Rectangle(pos.x - image.Width, pos.y - image.Height, image.Width, image.Height))
'                Else
'                    g.DrawImage(image, New Rectangle(pos.x - image.Width, pos.y + image.Height, image.Width, image.Height))
'                End If
'            Else
'                If pos.y > 0 Then
'                    g.DrawImage(image, New Rectangle(pos.x + image.Width, pos.y - image.Height, image.Width, image.Height))
'                Else
'                    g.DrawImage(image, New Rectangle(pos.x + image.Width, pos.y + image.Height, image.Width, image.Height))
'                End If
'            End If
'        End If
'
'        'Draw image horisontal direction from image
'        If repeatX Then
'            If pos.x > 0 Then
'                g.DrawImage(image, New Rectangle(pos.x - image.Width, pos.y, image.Width, image.Height))
'            Else
'                g.DrawImage(image, New Rectangle(pos.x + image.Width, pos.y, image.Width, image.Height))
'            End If
'        End If
'
'        'Draw image in vertical direction from image
'        If repeatY Then
'            If pos.y > 0 Then
'                g.DrawImage(image, New Rectangle(pos.x, pos.y - image.Height, image.Width, image.Height))
'            Else
'                g.DrawImage(image, New Rectangle(pos.x, pos.y + image.Height, image.Width, image.Height))
'            End If
'        End If
'        'Draw image
'        g.DrawImage(image, New Rectangle(pos.x, pos.y, image.Width, image.Height))
'    End Sub
'
'    Public Overrides Sub Update(sLastFrame As Double)
'        If repeatX Then
'            If pos.x >= image.Width Then
'                pos.x -= image.Width
'            ElseIf pos.x < -image.Width Then
'                pos.x += image.Width
'            End If
'        End If
'        If repeatY Then
'            If pos.y >= image.Height Then
'                pos.y -= image.Height
'            ElseIf pos.y < -image.Height Then
'                pos.y += image.Height
'            End If
'        End If
'
'        If targetReached Then Return
'        Dim posWas As Vec2 = pos
'        Dim target As Vec2 = targets(currentTarget)
'        pos += Vec2.Normalize(target - pos) * speed * sLastFrame
'
'        Dim dot As Double = Vec2.Dot(target - pos, pos)
'        Dim dotWas As Double = Vec2.Dot(posWas - pos, pos)
'
'        If (dot < 0 AndAlso dotWas < 0) Or
'           (dot > 0 AndAlso dotWas > 0) Or
'           (dot = 0 AndAlso dotWas = 0) Then
'            targetReached = True
'            If loopTargets Then
'                Me.NextTarget()
'            End If
'        End If
'    End Sub
'End Class
