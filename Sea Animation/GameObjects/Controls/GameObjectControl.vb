Imports System.Drawing.Drawing2D

Public Class GameObjectControl

    Private Sub CreateChildTreeRecursive(n As TreeNode, r As Renderable)
        Dim Image As New Bitmap(ilRenderableIcons.ImageSize.Width, ilRenderableIcons.ImageSize.Height)
        Dim g As Graphics = Graphics.FromImage(Image)
        r.RenderPreview(g, New Vector2(ilRenderableIcons.ImageSize.Width, ilRenderableIcons.ImageSize.Height))
        ilRenderableIcons.Images.Add(Image)

        n.Name = r.id.ToString()
        n.Text = ""
        n.ImageIndex = ilRenderableIcons.Images.Count - 1
        n.SelectedImageIndex = ilRenderableIcons.Images.Count - 1

        For Each child As Renderable In r.children
            Dim node As New TreeNode()
            CreateChildTreeRecursive(node, child)
            n.Nodes.Add(node)
        Next
    End Sub

    Public Sub CreateChildTree(r As Renderable)

        tvRenderables.Nodes.Clear()
        ilRenderableIcons.Images.Clear()
        If r IsNot Nothing Then
            Dim n As New TreeNode()
            CreateChildTreeRecursive(n, r)
            tvRenderables.Nodes.Add(n)
        End If
    End Sub

    Private Sub GameObjectControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbImageRenderObject.AllowDrop = True
        RenderableControl1.Hide()
        btnAddRenderable.Enabled = False
    End Sub

    Public Sub SetValues(ByRef go As GameObject)
        txtName.Text = go.name
        pos.SetVec(go.pos)
        CreateChildTree(go.renderable)
        RenderableControl1.Hide()
    End Sub

    Private Sub tvRenderables_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvRenderables.AfterSelect
        Form1.SelectRenderable(Guid.Parse(tvRenderables.SelectedNode.Name))
        If Form1.selectedRenderable IsNot Nothing Then
            RenderableControl1.Show()
            RenderableControl1.SetValues(Form1.selectedRenderable)
        Else
            RenderableControl1.Hide()
        End If
    End Sub

    Private Sub pos_XPosChanged(val As Double) Handles pos.XPosChanged
        Form1.selectedGameObject.pos.X = val
    End Sub

    Private Sub pos_YPosChanged(val As Double) Handles pos.YPosChanged
        Form1.selectedGameObject.pos.Y = val
    End Sub

    Public Event NameChange(name As String)

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If Not String.IsNullOrEmpty(txtName.Text) Then
            Form1.selectedGameObject.name = txtName.Text
            RaiseEvent NameChange(txtName.Text)
        End If
    End Sub
    Dim imagePath As String
    Private Sub pbImageRenderObject_DragDrop(sender As Object, e As DragEventArgs) Handles pbImageRenderObject.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            imagePath = path
            pbImageRenderObject.Image = Image.FromFile(path)
        Next
    End Sub

    Private Sub pbImageRenderObject_DragEnter(sender As Object, e As DragEventArgs) Handles pbImageRenderObject.DragEnter
        Dim files As String = e.Data.GetData(DataFormats.FileDrop)(0)
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub btnAddRenderable_Click(sender As Object, e As EventArgs) Handles btnAddRenderable.Click
        Dim r As New Renderable
        If imagePath IsNot Nothing Then
            r.what = New ImageRenderObject(imagePath)
        Else
            r.what = New ImageRenderObject(pbImageRenderObject.Image)
        End If
        r.where = New Vector2(0, 0)
        If Form1.selectedGameObject.renderable Is Nothing Then
            If cbRenderableType.Text = "ImageRenderObject" Then
                Form1.selectedGameObject.renderable = r
            End If
        ElseIf Form1.selectedRenderable Is Nothing Then
            Form1.selectedGameObject.renderable = r
        Else
            Form1.selectedRenderable.children.Add(r)
        End If
        Editor.GameObjectControl1.SetValues(Form1.selectedGameObject)
    End Sub

    Private Sub DeleteSelectedRenderable()
        If tvRenderables.SelectedNode Is Nothing Then Return
        Dim r As Renderable = Form1.selectedRenderable
        Form1.selectedRenderable = Nothing
        If tvRenderables.SelectedNode.Parent Is Nothing Then
            Form1.selectedGameObject.renderable = Nothing
            SetValues(Form1.selectedGameObject)
        Else
            Form1.SelectRenderable(Guid.Parse(tvRenderables.SelectedNode.Parent.Name))
            For i As Integer = 0 To Form1.selectedRenderable.children.Count - 1
                If Form1.selectedRenderable.children(i).id = r.id Then
                    Form1.selectedRenderable.children.RemoveAt(i)
                    Dim t As TreeNode = tvRenderables.SelectedNode.Parent
                    tvRenderables.Nodes.Remove(tvRenderables.SelectedNode)
                    tvRenderables.SelectedNode = t
                    SetValues(Form1.selectedGameObject)
                    Return
                End If
            Next
        End If
    End Sub

    Private Sub btnDeleteRenderable_Click(sender As Object, e As EventArgs) Handles btnDeleteRenderable.Click
        DeleteSelectedRenderable()
    End Sub

    Private Sub tvRenderables_KeyDown(sender As Object, e As KeyEventArgs) Handles tvRenderables.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeleteSelectedRenderable()
        End If
    End Sub

    Private Sub cbRenderableType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRenderableType.SelectedIndexChanged
        If cbRenderableType.Text = "ImageRenderObject" Then
            btnAddRenderable.Enabled = True
            pbImageRenderObject.Image = New Bitmap(pbImageRenderObject.Width, pbImageRenderObject.Width)
            Dim g As Graphics = Graphics.FromImage(pbImageRenderObject.Image)
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim pen As Pen = New Pen(Color.Red, 5)
            g.DrawLine(pen, 0, 0, pbImageRenderObject.Width, pbImageRenderObject.Width)
            g.DrawLine(pen, pbImageRenderObject.Width, 0, 0, pbImageRenderObject.Width)
            pen.Width = 10
            g.DrawRectangle(pen, 0, 0, pbImageRenderObject.Width, pbImageRenderObject.Height)
        End If
    End Sub

    Private Sub tvRenderables_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles tvRenderables.ItemDrag
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub tvRenderables_DragEnter(sender As Object, e As DragEventArgs) Handles tvRenderables.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub tvRenderables_DragOver(sender As Object, e As DragEventArgs) Handles tvRenderables.DragOver
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

    Private Sub tvRenderables_DragDrop(sender As Object, e As DragEventArgs) Handles tvRenderables.DragDrop
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        Dim selectedTreeView As TreeView = CType(sender, TreeView)

        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        Dim targetNode As TreeNode = selectedTreeView.SelectedNode
        dropNode.Remove()
        Dim r As Renderable = Form1.GetAndRemoveRenderable(Guid.Parse(dropNode.Name))

        If targetNode Is Nothing Then
            Form1.selectedGameObject.renderable = r
            selectedTreeView.Nodes.Add(dropNode)
        Else
            Form1.selectedRenderable.children.Add(r)
            targetNode.Nodes.Add(dropNode)
        End If

        dropNode.EnsureVisible()
        selectedTreeView.SelectedNode = dropNode
    End Sub



End Class
