<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RenderableControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pos = New Sea_Animation.PostitionControl()
        Me.pbRenderObject = New System.Windows.Forms.PictureBox()
        Me.tvAnimations = New System.Windows.Forms.TreeView()
        Me.cbCentered = New System.Windows.Forms.CheckBox()
        Me.AnimationControl1 = New Sea_Animation.AnimationControl()
        Me.btnAddAnimation = New System.Windows.Forms.Button()
        Me.btnDeleteAnimation = New System.Windows.Forms.Button()
        Me.cbAnimationType = New System.Windows.Forms.ComboBox()
        CType(Me.pbRenderObject, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pos
        '
        Me.pos.AutoSize = True
        Me.pos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pos.Location = New System.Drawing.Point(0, 0)
        Me.pos.Margin = New System.Windows.Forms.Padding(0)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(195, 26)
        Me.pos.TabIndex = 0
        '
        'pbRenderObject
        '
        Me.pbRenderObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbRenderObject.Location = New System.Drawing.Point(3, 55)
        Me.pbRenderObject.Name = "pbRenderObject"
        Me.pbRenderObject.Size = New System.Drawing.Size(192, 192)
        Me.pbRenderObject.TabIndex = 1
        Me.pbRenderObject.TabStop = False
        '
        'tvAnimations
        '
        Me.tvAnimations.AllowDrop = True
        Me.tvAnimations.Location = New System.Drawing.Point(201, 3)
        Me.tvAnimations.Name = "tvAnimations"
        Me.tvAnimations.Size = New System.Drawing.Size(151, 213)
        Me.tvAnimations.TabIndex = 2
        '
        'cbCentered
        '
        Me.cbCentered.AutoSize = True
        Me.cbCentered.Location = New System.Drawing.Point(3, 30)
        Me.cbCentered.Name = "cbCentered"
        Me.cbCentered.Size = New System.Drawing.Size(69, 17)
        Me.cbCentered.TabIndex = 5
        Me.cbCentered.Text = "Centered"
        Me.cbCentered.UseVisualStyleBackColor = True
        '
        'AnimationControl1
        '
        Me.AnimationControl1.AutoSize = True
        Me.AnimationControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AnimationControl1.Location = New System.Drawing.Point(358, 3)
        Me.AnimationControl1.Name = "AnimationControl1"
        Me.AnimationControl1.Size = New System.Drawing.Size(0, 0)
        Me.AnimationControl1.TabIndex = 6
        '
        'btnAddAnimation
        '
        Me.btnAddAnimation.Location = New System.Drawing.Point(201, 222)
        Me.btnAddAnimation.Name = "btnAddAnimation"
        Me.btnAddAnimation.Size = New System.Drawing.Size(67, 23)
        Me.btnAddAnimation.TabIndex = 7
        Me.btnAddAnimation.Text = "Add Animation"
        Me.btnAddAnimation.UseVisualStyleBackColor = True
        '
        'btnDeleteAnimation
        '
        Me.btnDeleteAnimation.Location = New System.Drawing.Point(285, 222)
        Me.btnDeleteAnimation.Name = "btnDeleteAnimation"
        Me.btnDeleteAnimation.Size = New System.Drawing.Size(67, 23)
        Me.btnDeleteAnimation.TabIndex = 8
        Me.btnDeleteAnimation.Text = "Delete Animation"
        Me.btnDeleteAnimation.UseVisualStyleBackColor = True
        '
        'cbAnimationType
        '
        Me.cbAnimationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAnimationType.FormattingEnabled = True
        Me.cbAnimationType.Items.AddRange(New Object() {"RotatorAnimation", "LinearMoveAnimation"})
        Me.cbAnimationType.Location = New System.Drawing.Point(201, 251)
        Me.cbAnimationType.Name = "cbAnimationType"
        Me.cbAnimationType.Size = New System.Drawing.Size(151, 21)
        Me.cbAnimationType.TabIndex = 9
        '
        'RenderableControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.cbAnimationType)
        Me.Controls.Add(Me.btnDeleteAnimation)
        Me.Controls.Add(Me.btnAddAnimation)
        Me.Controls.Add(Me.AnimationControl1)
        Me.Controls.Add(Me.cbCentered)
        Me.Controls.Add(Me.tvAnimations)
        Me.Controls.Add(Me.pbRenderObject)
        Me.Controls.Add(Me.pos)
        Me.Name = "RenderableControl"
        Me.Size = New System.Drawing.Size(361, 275)
        CType(Me.pbRenderObject, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pos As PostitionControl
    Friend WithEvents pbRenderObject As PictureBox
    Friend WithEvents tvAnimations As TreeView
    Friend WithEvents cbCentered As CheckBox
    Friend WithEvents AnimationControl1 As AnimationControl
    Friend WithEvents btnAddAnimation As Button
    Friend WithEvents btnDeleteAnimation As Button
    Friend WithEvents cbAnimationType As ComboBox
End Class
