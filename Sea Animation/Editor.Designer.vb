<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Editor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tvGameObjects = New System.Windows.Forms.TreeView()
        Me.GameObjectControl1 = New Sea_Animation.GameObjectControl()
        Me.btnAddGameObject = New System.Windows.Forms.Button()
        Me.btnDeleteGameObject = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cbRoot = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'tvGameObjects
        '
        Me.tvGameObjects.Location = New System.Drawing.Point(12, 12)
        Me.tvGameObjects.Name = "tvGameObjects"
        Me.tvGameObjects.Size = New System.Drawing.Size(145, 562)
        Me.tvGameObjects.TabIndex = 3
        '
        'GameObjectControl1
        '
        Me.GameObjectControl1.AllowDrop = True
        Me.GameObjectControl1.AutoSize = True
        Me.GameObjectControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GameObjectControl1.Location = New System.Drawing.Point(163, 12)
        Me.GameObjectControl1.Name = "GameObjectControl1"
        Me.GameObjectControl1.Size = New System.Drawing.Size(203, 641)
        Me.GameObjectControl1.TabIndex = 4
        '
        'btnAddGameObject
        '
        Me.btnAddGameObject.Location = New System.Drawing.Point(12, 603)
        Me.btnAddGameObject.Name = "btnAddGameObject"
        Me.btnAddGameObject.Size = New System.Drawing.Size(71, 23)
        Me.btnAddGameObject.TabIndex = 5
        Me.btnAddGameObject.Text = "Add GameObject"
        Me.btnAddGameObject.UseVisualStyleBackColor = True
        '
        'btnDeleteGameObject
        '
        Me.btnDeleteGameObject.Location = New System.Drawing.Point(85, 603)
        Me.btnDeleteGameObject.Name = "btnDeleteGameObject"
        Me.btnDeleteGameObject.Size = New System.Drawing.Size(71, 23)
        Me.btnDeleteGameObject.TabIndex = 6
        Me.btnDeleteGameObject.Text = "Delete GameObject"
        Me.btnDeleteGameObject.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(12, 633)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(144, 20)
        Me.txtName.TabIndex = 7
        '
        'cbRoot
        '
        Me.cbRoot.AutoSize = True
        Me.cbRoot.Location = New System.Drawing.Point(12, 580)
        Me.cbRoot.Name = "cbRoot"
        Me.cbRoot.Size = New System.Drawing.Size(74, 17)
        Me.cbRoot.TabIndex = 8
        Me.cbRoot.Text = "Make root"
        Me.cbRoot.UseVisualStyleBackColor = True
        '
        'Editor
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 659)
        Me.Controls.Add(Me.cbRoot)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.btnDeleteGameObject)
        Me.Controls.Add(Me.btnAddGameObject)
        Me.Controls.Add(Me.GameObjectControl1)
        Me.Controls.Add(Me.tvGameObjects)
        Me.DoubleBuffered = True
        Me.Name = "Editor"
        Me.Text = "Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvGameObjects As TreeView
    Friend WithEvents GameObjectControl1 As GameObjectControl
    Friend WithEvents btnAddGameObject As Button
    Friend WithEvents btnDeleteGameObject As Button
    Friend WithEvents txtName As TextBox
    Friend WithEvents cbRoot As CheckBox
End Class
