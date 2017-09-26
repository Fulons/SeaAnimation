Imports System.Numerics
Imports System.Xml

Public Class Form1
#Region "Member variables"
    'Public animations As New List(Of Animation)
    Public resourcePath As New String("G:\Data\")  'Default path for loading and saving scenes

    Private tick As Integer = 0                     'Incremented by one for every update loop
    Private sw As New Stopwatch                     'Used for timimng a tick
    Private ticksLastFrame As Long                  'Used for timimng a tick
    Private key(255) As Boolean                     'Holds the state of each button

    Public gameObjects As New List(Of GameObject)   'All objects currently being drawn

    Public selectedGameObject As GameObject         'Currently selected Gameobject in the GameObject Treeview in the Editor
    Public selectedRenderable As Renderable         'Currently selected Renderable in the Renderable Treeview in the Editor
    Public selectedAnimation As Animation           'Currently selected Animation in the Animation Treeview in the Editor
#End Region

#Region "Set selected: Methods that sets selectedGameObject, selectedRenderable or selectedAnimation"
    'Used for updating every object in the scene
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim msPerFrame As Double = (sw.ElapsedTicks - ticksLastFrame) / Stopwatch.Frequency
        ticksLastFrame = sw.ElapsedTicks

        For Each g In gameObjects
            g.Update(msPerFrame)
        Next

        Me.Invalidate()
        tick += 1
    End Sub

    'Used by SelectGameObject to search trough and set selectedGameObject recursively 
    Private Sub SelectGameObjectRecursive(name As String, ByRef go As GameObject)
        If name = go.name Then
            selectedGameObject = go
        Else
            For Each child As GameObject In go.children
                SelectGameObjectRecursive(name, child)
            Next
        End If
    End Sub

    'Search trough every GameObject and their children until a gamobject with the name is found, and set it as the SelectedGameObject
    Public Sub SelectGameObject(name As String)
        selectedGameObject = Nothing
        selectedRenderable = Nothing
        selectedAnimation = Nothing
        For Each go As GameObject In gameObjects
            SelectGameObjectRecursive(name, go)
        Next
    End Sub

    'Used by SelectRenderable to search trough and set selectedRenderable recursively 
    Private Sub SelectRenderableRecursive(id As Guid, ByRef r As Renderable)
        If r.id = id Then
            selectedRenderable = r
            Return
        End If
        For Each child As Renderable In r.children
            SelectRenderableRecursive(id, child)
        Next
    End Sub

    'Search trough every Renderable of selectedGameObject and their children until a Renderable with the id is found, and set it as the selectedRenderable
    Public Sub SelectRenderable(id As Guid)
        selectedRenderable = Nothing
        selectedAnimation = Nothing
        SelectRenderableRecursive(id, selectedGameObject.renderable)
    End Sub

    'Used by SelectAnimation to search trough and set selectedAnimation recursively 
    Private Sub SelectAnimationRecursively(id As Guid, ByRef a As Animation)
        If a.id = id Then
            selectedAnimation = a
        End If
        For Each child As Animation In a.children
            SelectAnimationRecursively(id, child)
        Next
    End Sub

    'Search trough every Animation of selectedRenderable and their children until a Animation with the id is found, and set it as the selectedAnimation
    Public Sub SelectAnimation(id As Guid)
        selectedAnimation = Nothing
        SelectAnimationRecursively(id, selectedRenderable.animation)
    End Sub
#End Region
#Region "Get objects: Methods that get and potentially remove GameObjects, Renderables or Animations from their parents"
    'Used by GetGameObject and GetAndRemoveGameObject to find, return and potentially remove a GameObject
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

    'Gets a GameObject with name without removing it
    Public Function GetGameObject(name As String) As GameObject
        Return GetGameObjectRecursively(name, gameObjects, Nothing)
    End Function

    'Gets a GameObject with name and removes it
    Public Function GetAndRemoveGameObject(name As String) As GameObject
        Return GetGameObjectRecursively(name, gameObjects, Nothing, True)
    End Function

    'Used by GetRenderable and GetAndRemoveRenderable to find, return and potentially remove a Renderable
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

    'Gets a Renderable with id without removing it
    Public Function GetRenderable(id As Guid) As Renderable
        Return GetRenderableRecursively(id, selectedGameObject.renderable, Nothing)
    End Function
    'Gets a Renderable with id and removes it
    Public Function GetAndRemoveRenderable(id As Guid) As Renderable
        Return GetRenderableRecursively(id, selectedGameObject.renderable, Nothing, True)
    End Function

    'Used by GetAnimation and GetAndRemoveAnimation to find, return and potentially remove an Animation
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

    'Gets an Animation with id without removing it
    Public Function GetAnimation(id As Guid) As Animation
        Return GetAnimationRecursively(id, selectedRenderable.animation, Nothing)
    End Function

    'Gets an Animation with id and removes it
    Public Function GetAndRemoveAnimation(id As Guid) As Animation
        Return GetAnimationRecursively(id, selectedRenderable.animation, Nothing, True)
    End Function
#End Region
#Region "Form event handlers: Handles loading, painting and key evenets"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sw.Start()
        ticksLastFrame = sw.ElapsedTicks
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        For g As Integer = 0 To gameObjects.Count() - 1
            gameObjects(g).Draw(e.Graphics)
        Next
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
#End Region
#Region "Save and Load scene: Saves and loads GameObjects from a xmlDocument"
    'Load GameObjects from a xml document
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

    'Saves GameObjects to a xml document
    Public Sub SaveXml(ByRef doc As XmlDocument)
        Dim n As XmlNode = doc.CreateElement("Scene")
        For Each go As GameObject In gameObjects
            n.AppendChild(go.Save(doc))
        Next
        doc.AppendChild(n)
    End Sub
#End Region
#Region "Doodeling"
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
        g.DrawBeziers(pen, points.ToArray)
    End Sub
#End Region

End Class