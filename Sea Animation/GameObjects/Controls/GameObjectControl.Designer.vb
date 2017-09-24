<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GameObjectControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.pos = New Sea_Animation.PostitionControl()
        Me.tvRenderables = New System.Windows.Forms.TreeView()
        Me.ilRenderableIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.RenderableControl1 = New Sea_Animation.RenderableControl()
        Me.btnAddRenderable = New System.Windows.Forms.Button()
        Me.btnDeleteRenderable = New System.Windows.Forms.Button()
        Me.cbRenderableType = New System.Windows.Forms.ComboBox()
        Me.pbImageRenderObject = New System.Windows.Forms.PictureBox()
        CType(Me.pbImageRenderObject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(44, 3)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(156, 20)
        Me.txtName.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(3, 6)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name"
        '
        'pos
        '
        Me.pos.AutoSize = True
        Me.pos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pos.Location = New System.Drawing.Point(3, 26)
        Me.pos.Margin = New System.Windows.Forms.Padding(0)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(195, 26)
        Me.pos.TabIndex = 2
        '
        'tvRenderables
        '
        Me.tvRenderables.ImageIndex = 0
        Me.tvRenderables.ImageList = Me.ilRenderableIcons
        Me.tvRenderables.Location = New System.Drawing.Point(3, 54)
        Me.tvRenderables.Name = "tvRenderables"
        Me.tvRenderables.SelectedImageIndex = 0
        Me.tvRenderables.Size = New System.Drawing.Size(197, 325)
        Me.tvRenderables.TabIndex = 3
        '
        'ilRenderableIcons
        '
        Me.ilRenderableIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit
        Me.ilRenderableIcons.ImageSize = New System.Drawing.Size(32, 32)
        Me.ilRenderableIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'RenderableControl1
        '
        Me.RenderableControl1.AllowDrop = True
        Me.RenderableControl1.AutoSize = True
        Me.RenderableControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.RenderableControl1.Location = New System.Drawing.Point(204, 0)
        Me.RenderableControl1.Name = "RenderableControl1"
        Me.RenderableControl1.Size = New System.Drawing.Size(355, 275)
        Me.RenderableControl1.TabIndex = 4
        '
        'btnAddRenderable
        '
        Me.btnAddRenderable.Location = New System.Drawing.Point(3, 385)
        Me.btnAddRenderable.Name = "btnAddRenderable"
        Me.btnAddRenderable.Size = New System.Drawing.Size(93, 23)
        Me.btnAddRenderable.TabIndex = 5
        Me.btnAddRenderable.Text = "Add Renderable"
        Me.btnAddRenderable.UseVisualStyleBackColor = True
        '
        'btnDeleteRenderable
        '
        Me.btnDeleteRenderable.Location = New System.Drawing.Point(107, 385)
        Me.btnDeleteRenderable.Name = "btnDeleteRenderable"
        Me.btnDeleteRenderable.Size = New System.Drawing.Size(93, 23)
        Me.btnDeleteRenderable.TabIndex = 6
        Me.btnDeleteRenderable.Text = "Delete Renderable"
        Me.btnDeleteRenderable.UseVisualStyleBackColor = True
        '
        'cbRenderableType
        '
        Me.cbRenderableType.FormattingEnabled = True
        Me.cbRenderableType.Items.AddRange(New Object() {"ImageRenderObject"})
        Me.cbRenderableType.Location = New System.Drawing.Point(3, 414)
        Me.cbRenderableType.Name = "cbRenderableType"
        Me.cbRenderableType.Size = New System.Drawing.Size(197, 21)
        Me.cbRenderableType.TabIndex = 7
        '
        'pbImageRenderObject
        '
        Me.pbImageRenderObject.Location = New System.Drawing.Point(3, 441)
        Me.pbImageRenderObject.Name = "pbImageRenderObject"
        Me.pbImageRenderObject.Size = New System.Drawing.Size(197, 197)
        Me.pbImageRenderObject.TabIndex = 8
        Me.pbImageRenderObject.TabStop = False
        '
        'GameObjectControl
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.pbImageRenderObject)
        Me.Controls.Add(Me.cbRenderableType)
        Me.Controls.Add(Me.btnDeleteRenderable)
        Me.Controls.Add(Me.btnAddRenderable)
        Me.Controls.Add(Me.RenderableControl1)
        Me.Controls.Add(Me.tvRenderables)
        Me.Controls.Add(Me.pos)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtName)
        Me.Name = "GameObjectControl"
        Me.Size = New System.Drawing.Size(562, 641)
        CType(Me.pbImageRenderObject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents lblName As Label
    Friend WithEvents pos As PostitionControl
    Friend WithEvents tvRenderables As TreeView
    Friend WithEvents ilRenderableIcons As ImageList
    Friend WithEvents RenderableControl1 As RenderableControl
    Friend WithEvents btnAddRenderable As Button
    Friend WithEvents btnDeleteRenderable As Button
    Friend WithEvents cbRenderableType As ComboBox
    Friend WithEvents pbImageRenderObject As PictureBox
End Class
