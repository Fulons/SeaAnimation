
Public Class Editor
    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateGameObjectTree()
        GameObjectControl1.Hide()
        btnAddGameObject.Enabled = False
    End Sub

    Private Sub CreateGameObjectTree()
        GameObjectControl1.Hide()
        tvGameObjects.Nodes.Clear()
        For Each go As GameObject In Form1.gameObjects
            Dim node As New TreeNode
            PopulateGameObjectTreeView(node, go)
            tvGameObjects.Nodes.Add(node)
        Next
    End Sub

    Private Sub PopulateGameObjectTreeView(ByRef n As TreeNode, ByRef go As GameObject)
        n.Name = go.name
        n.Text = go.name
        For Each child As GameObject In go.children
            Dim node As New TreeNode
            PopulateGameObjectTreeView(node, child)
            n.Nodes.Add(node)
        Next
    End Sub

    Private Sub tvGameObjects_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvGameObjects.AfterSelect
        Form1.SelectGameObject(tvGameObjects.SelectedNode.Text)
        If Form1.selectedGameObject IsNot Nothing Then
            GameObjectControl1.Show()
            GameObjectControl1.SetValues(Form1.selectedGameObject)
        Else
            GameObjectControl1.Hide()
        End If
    End Sub

    Private Sub OnNameChange(name As String) Handles GameObjectControl1.NameChange
        tvGameObjects.SelectedNode.Text = name
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If Not String.IsNullOrEmpty(txtName.Text) Then
            btnAddGameObject.Enabled = True
        Else
            btnAddGameObject.Enabled = False
        End If
    End Sub

    Private Sub AddGameObject()
        If Form1.selectedGameObject Is Nothing Or cbRoot.Checked = True Then
            Form1.gameObjects.Add(New GameObject(txtName.Text))
        Else
            Form1.selectedGameObject.children.Add(New GameObject(txtName.Text))
        End If
        CreateGameObjectTree()
    End Sub

    Private Sub btnAddGameObject_Click(sender As Object, e As EventArgs) Handles btnAddGameObject.Click
        AddGameObject()
    End Sub

    Private Sub DeleteSelectedObject()
        If tvGameObjects.SelectedNode Is Nothing Then Return
        Dim go As GameObject = Form1.selectedGameObject
        Form1.selectedGameObject = Nothing
        If tvGameObjects.SelectedNode.Parent Is Nothing Then
            Form1.gameObjects.Remove(go)
            CreateGameObjectTree()
        Else
            Form1.SelectGameObject(tvGameObjects.SelectedNode.Parent.Name)
            For i As Integer = 0 To Form1.selectedGameObject.children.Count - 1
                If Form1.selectedGameObject.children(i).name = go.name Then
                    Form1.selectedGameObject.children.RemoveAt(i)
                    Dim t As TreeNode = tvGameObjects.SelectedNode.Parent
                    tvGameObjects.Nodes.Remove(tvGameObjects.SelectedNode)
                    tvGameObjects.SelectedNode = t
                    CreateGameObjectTree()
                    Return
                End If
            Next
        End If
    End Sub

    Private Sub btnDeleteGameObject_Click(sender As Object, e As EventArgs) Handles btnDeleteGameObject.Click
        DeleteSelectedObject()
    End Sub

    Private Sub tvGameObjects_KeyDown(sender As Object, e As KeyEventArgs) Handles tvGameObjects.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeleteSelectedObject()
        End If
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddGameObject()
        End If
    End Sub

    Private Sub tvGameObjects_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles tvGameObjects.ItemDrag
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub tvGameObjects_DragEnter(sender As Object, e As DragEventArgs) Handles tvGameObjects.DragEnter
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub tvGameObjects_DragOver(sender As Object, e As DragEventArgs) Handles tvGameObjects.DragOver
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

    Private Sub tvGameObjects_DragDrop(sender As Object, e As DragEventArgs) Handles tvGameObjects.DragDrop
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        Dim selectedTreeView As TreeView = CType(sender, TreeView)

        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
        Dim targetNode As TreeNode = selectedTreeView.SelectedNode
        dropNode.Remove()
        Dim go As GameObject = Form1.GetAndRemoveGameObject(dropNode.Name)

        If targetNode Is Nothing Then
            selectedTreeView.Nodes.Add(dropNode)
            Form1.gameObjects.Add(go)
        Else
            targetNode.Nodes.Add(dropNode)
            Form1.selectedGameObject.children.Add(go)
        End If

        dropNode.EnsureVisible()
        selectedTreeView.SelectedNode = dropNode
    End Sub
End Class