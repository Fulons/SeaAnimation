
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

    Private Sub btnAddGameObject_Click(sender As Object, e As EventArgs) Handles btnAddGameObject.Click
        If Form1.selectedGameObject Is Nothing Then
            Form1.gameObjects.Add(New GameObject(txtName.Text))
        Else
            Form1.selectedGameObject.children.Add(New GameObject(txtName.Text))
        End If
        CreateGameObjectTree()
    End Sub

    'Private Sub btnDeleteRenderable_Click(sender As Object, e As EventArgs) Handles btnDeleteRenderable.Click
    '    Dim r As Renderable = Form1.selectedRenderable
    '    Form1.selectedRenderable = Nothing
    '    If tvRenderables.SelectedNode.Parent Is Nothing Then
    '        Form1.selectedGameObject.renderable = Nothing
    '        SetValues(Form1.selectedGameObject)
    '    Else
    '        Form1.SelectRenderable(Guid.Parse(tvRenderables.SelectedNode.Parent.Name))
    '        For i As Integer = 0 To Form1.selectedRenderable.children.Count - 1
    '            If Form1.selectedRenderable.children(i).id = r.id Then
    '                Form1.selectedRenderable.children.RemoveAt(i)
    '                Dim t As TreeNode = tvRenderables.SelectedNode.Parent
    '                tvRenderables.Nodes.Remove(tvRenderables.SelectedNode)
    '                tvRenderables.SelectedNode = t
    '                SetValues(Form1.selectedGameObject)
    '                Return
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub btnDeleteGameObject_Click(sender As Object, e As EventArgs) Handles btnDeleteGameObject.Click
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
End Class