﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnRestartAnimation = New System.Windows.Forms.Button()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvGameObjects
        '
        Me.tvGameObjects.AllowDrop = True
        Me.tvGameObjects.HideSelection = False
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
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(692, 633)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 9
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(611, 633)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(530, 633)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 11
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.InitialDirectory = "/Data"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.InitialDirectory = "/Data"
        '
        'btnRestartAnimation
        '
        Me.btnRestartAnimation.Location = New System.Drawing.Point(418, 633)
        Me.btnRestartAnimation.Name = "btnRestartAnimation"
        Me.btnRestartAnimation.Size = New System.Drawing.Size(106, 23)
        Me.btnRestartAnimation.TabIndex = 12
        Me.btnRestartAnimation.Text = "Restart Animations"
        Me.btnRestartAnimation.UseVisualStyleBackColor = True
        '
        'Editor
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 659)
        Me.Controls.Add(Me.btnRestartAnimation)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.cbRoot)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.btnDeleteGameObject)
        Me.Controls.Add(Me.btnAddGameObject)
        Me.Controls.Add(Me.GameObjectControl1)
        Me.Controls.Add(Me.tvGameObjects)
        Me.DoubleBuffered = True
        Me.Name = "Editor"
        Me.Text = "Editor"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvGameObjects As TreeView
    Friend WithEvents GameObjectControl1 As GameObjectControl
    Friend WithEvents btnAddGameObject As Button
    Friend WithEvents btnDeleteGameObject As Button
    Friend WithEvents txtName As TextBox
    Friend WithEvents cbRoot As CheckBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents btnRestartAnimation As Button
End Class
