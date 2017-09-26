Imports System.Xml

Public Class Editor
#Region "Form Events"
    'On load, Create GameObject TreeView and initialise Save and Load file Dialogs
    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateGameObjectTree()
        GameObjectControl1.Hide()
        OpenFileDialog1.InitialDirectory = Form1.resourcePath
        SaveFileDialog1.InitialDirectory = Form1.resourcePath
        OpenFileDialog1.Filter = "Xml Files (*.xml)|*.xml"
        SaveFileDialog1.Filter = "Xml Files (*.xml)|*.xml"
        OpenFileDialog1.FilterIndex = 1
        SaveFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        SaveFileDialog1.RestoreDirectory = True

        btnAddGameObject.Enabled = False
    End Sub

    'When name of GameObject is changed in the GameObjectControl1 Control
    Private Sub OnNameChange(name As String) Handles GameObjectControl1.NameChange
        tvGameObjects.SelectedNode.Text = name
    End Sub

    'When btnAddGameObject is pressed
    Private Sub btnAddGameObject_Click(sender As Object, e As EventArgs) Handles btnAddGameObject.Click
        AddGameObject()
    End Sub

    'When btnDeleteGameObject is pressed
    Private Sub btnDeleteGameObject_Click(sender As Object, e As EventArgs) Handles btnDeleteGameObject.Click
        DeleteSelectedObject()
    End Sub

    'Disables or enables add button depending on the validity of the text in txtName control
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If Not String.IsNullOrEmpty(txtName.Text) Then
            btnAddGameObject.Enabled = True
        Else
            btnAddGameObject.Enabled = False
        End If
    End Sub

    'Deletes currently selected objects if tvGameObjects has focus
    Private Sub tvGameObjects_KeyDown(sender As Object, e As KeyEventArgs) Handles tvGameObjects.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeleteSelectedObject()
        End If
    End Sub

    'Add game object if enter is pressed and txtName has focus
    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddGameObject()
        End If
    End Sub
#End Region
#Region "GameObject TreeView"
    'Recursive function used by CreateGameObjectTree to populate the GameObject TreeView
    Private Sub PopulateGameObjectTreeView(ByRef n As TreeNode, ByRef go As GameObject)
        n.Name = go.name
        n.Text = go.name
        For Each child As GameObject In go.children
            Dim node As New TreeNode
            PopulateGameObjectTreeView(node, child)
            n.Nodes.Add(node)
        Next
    End Sub

    'Populates the GameObject TreeView
    Private Sub CreateGameObjectTree()
        GameObjectControl1.Hide()
        tvGameObjects.Nodes.Clear()
        For Each go As GameObject In Form1.gameObjects
            Dim node As New TreeNode
            PopulateGameObjectTreeView(node, go)
            tvGameObjects.Nodes.Add(node)
        Next
    End Sub

    'When a GameObject is selected
    Private Sub tvGameObjects_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvGameObjects.AfterSelect
        Form1.SelectGameObject(tvGameObjects.SelectedNode.Text)
        If Form1.selectedGameObject IsNot Nothing Then
            GameObjectControl1.Show()
            GameObjectControl1.SetValues(Form1.selectedGameObject)
        Else
            GameObjectControl1.Hide()
        End If
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

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Form1.Timer1.Interval = NumericUpDown1.Value
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If SaveFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim doc As New XmlDocument()
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", Nothing))
            Form1.SaveXml(doc)
            doc.Save(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim doc As New XmlDocument()
            Try
                doc.Load(OpenFileDialog1.FileName)
                Form1.LoadXml(doc)
                CreateGameObjectTree()
            Catch ex As Exception
                MessageBox.Show("Cannot read file from disk.... " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnRestartAnimation_Click(sender As Object, e As EventArgs) Handles btnRestartAnimation.Click
        For Each go In Form1.gameObjects
            go.RestartAnimation()
        Next
    End Sub
#End Region
#Region "Add GameObject"
    'Adds a gameObject to selectedGameObject or Form1 if no GameObject is selected and recreates the GameObject TreeView
    Private Sub AddGameObject()
        If Form1.selectedGameObject Is Nothing Or cbRoot.Checked = True Then
            Form1.gameObjects.Add(New GameObject(txtName.Text))
        Else
            Form1.selectedGameObject.children.Add(New GameObject(txtName.Text))
        End If
        CreateGameObjectTree()
    End Sub
#End Region
End Class