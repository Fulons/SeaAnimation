Public Class RenderableControl

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

    Private Sub DeleteSelectedAnimation()
        If tvAnimations.SelectedNode Is Nothing Then Return
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

    Private Sub btnRemoveAnimation_Click(sender As Object, e As EventArgs) Handles btnDeleteAnimation.Click
        DeleteSelectedAnimation()
    End Sub

    Private Sub cbCentered_CheckedChanged(sender As Object, e As EventArgs) Handles cbCentered.CheckedChanged
        Form1.selectedRenderable.what.centered = cbCentered.Checked
    End Sub

    Private Sub tvAnimations_KeyDown(sender As Object, e As KeyEventArgs) Handles tvAnimations.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeleteSelectedAnimation()
        End If
    End Sub

    Private Sub tvAnimations_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles tvAnimations.ItemDrag
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub tvAnimations_DragEnter(sender As Object, e As DragEventArgs) Handles tvAnimations.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub tvAnimations_DragOver(sender As Object, e As DragEventArgs) Handles tvAnimations.DragOver
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub
        Dim selectedTreeView As TreeView = CType(sender, TreeView)
        Dim pt As Point = selectedTreeView.PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = selectedTreeView.GetNodeAt(pt)
        If Not (selectedTreeView.SelectedNode Is targetNode) Then
            selectedTreeView.SelectedNode = targetNode

            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

            Do Until targetNode Is Nothing
                If targetNode Is dropNode Then
                    e.Effect = DragDropEffects.None
                    Exit Sub
                End If
                targetNode = targetNode.Parent
            Loop
        End If
        e.Effect = DragDropEffects.Move
    End Sub


    Private Sub tvAnimations_DragDrop(sender As Object, e As DragEventArgs) Handles tvAnimations.DragDrop
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        Dim selectedTreeView As TreeView = CType(sender, TreeView)

        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        Dim targetNode As TreeNode = selectedTreeView.SelectedNode
        dropNode.Remove()
        Dim a As Animation = Form1.GetAndRemoveAnimation(Guid.Parse(dropNode.Name))

        If targetNode Is Nothing Then
            Form1.selectedRenderable.animation = a
            selectedTreeView.Nodes.Add(dropNode)
        Else
            Form1.selectedAnimation.children.Add(a)
            targetNode.Nodes.Add(dropNode)
        End If

        dropNode.EnsureVisible()
        selectedTreeView.SelectedNode = dropNode
    End Sub

End Class
