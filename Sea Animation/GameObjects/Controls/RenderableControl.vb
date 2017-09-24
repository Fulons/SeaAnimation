﻿Public Class RenderableControl

    Private Sub CreateAnimationTree(ByRef n As TreeNode, ByRef r As Animation)
        n.Name = r.id.ToString()
        If TypeOf r Is RotatorAnimation Then
            n.Text = "RotatorAnimation"
        End If

        For Each child As Animation In r.children
            Dim node As New TreeNode()
            CreateAnimationTree(node, child)
            n.Nodes.Add(node)
        Next
    End Sub

    Public Sub SetValues(ByRef r As Renderable)
        pos.SetVec(r.where)

        Dim img As New Bitmap(pbRenderObject.Width, pbRenderObject.Height)
        Dim g As Graphics = Graphics.FromImage(img)

        r.RenderPreview(g, New Vector2(pbRenderObject.Width, pbRenderObject.Height))
        pbRenderObject.Image = img

        cbCentered.Checked = r.what.centered
        tvAnimations.Nodes.Clear()
        If r.animation IsNot Nothing Then
            Dim n As New TreeNode()
            CreateAnimationTree(n, r.animation)
            tvAnimations.Nodes.Add(n)
        End If
        AnimationControl1.Hide()
    End Sub

    Private Sub tvAnimations_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvAnimations.AfterSelect
        Form1.SelectAnimation(Guid.Parse(tvAnimations.SelectedNode.Name))
        If Form1.selectedAnimation IsNot Nothing Then
            AnimationControl1.Show()
            AnimationControl1.SetValues(Form1.selectedAnimation)
        Else
            AnimationControl1.Hide()
        End If
    End Sub

    Private Sub pbRenderObject_DragDrop(sender As Object, e As DragEventArgs) Handles pbRenderObject.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            If TypeOf Form1.selectedRenderable.what Is ImageRenderObject Then
                CType(Form1.selectedRenderable.what, ImageRenderObject).img = Image.FromFile(path)
                Me.SetValues(Form1.selectedRenderable)
            End If
        Next
    End Sub

    Private Sub pbRenderObject_DragEnter(sender As Object, e As DragEventArgs) Handles pbRenderObject.DragEnter
        Dim files As String = e.Data.GetData(DataFormats.FileDrop)(0)
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub RenderableControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbRenderObject.AllowDrop = True
        AnimationControl1.Hide()
    End Sub

    Private Sub pos_XPosChanged(val As Double) Handles pos.XPosChanged
        Form1.selectedRenderable.where.X = val
    End Sub

    Private Sub pos_YPosChanged(val As Double) Handles pos.YPosChanged
        Form1.selectedRenderable.where.Y = val
    End Sub

    Private Sub btnAddAnimation_Click(sender As Object, e As EventArgs) Handles btnAddAnimation.Click
        If Form1.selectedAnimation Is Nothing Then
            If cbAnimationType.Text = "RotatorAnimation" Then
                Form1.selectedRenderable.animation = New RotatorAnimation
            End If
        Else
            Form1.selectedAnimation.children.Add(New RotatorAnimation)
        End If
        Editor.GameObjectControl1.RenderableControl1.SetValues(Form1.selectedRenderable)
    End Sub

    Private Sub btnRemoveAnimation_Click(sender As Object, e As EventArgs) Handles btnDeleteAnimation.Click
        Dim a As Animation = Form1.selectedAnimation
        Form1.selectedAnimation = Nothing
        If tvAnimations.SelectedNode.Parent Is Nothing Then
            Form1.selectedRenderable.animation = Nothing
            tvAnimations.Nodes.Clear()
        Else
            Form1.SelectAnimation(Guid.Parse(tvAnimations.SelectedNode.Parent.Name))
            For i As Integer = 0 To Form1.selectedAnimation.children.Count - 1
                If Form1.selectedAnimation.children(i).id = a.id Then
                    Form1.selectedAnimation.children.RemoveAt(i)
                    Dim t As TreeNode = tvAnimations.SelectedNode.Parent
                    tvAnimations.Nodes.Remove(tvAnimations.SelectedNode)
                    tvAnimations.SelectedNode = t
                    Return
                End If
            Next
        End If
        Me.SetValues(Form1.selectedRenderable)
    End Sub

    Private Sub cbCentered_CheckedChanged(sender As Object, e As EventArgs) Handles cbCentered.CheckedChanged
        Form1.selectedRenderable.what.centered = cbCentered.Checked
    End Sub
End Class
