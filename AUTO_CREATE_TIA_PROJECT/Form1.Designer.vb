<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOpenTia15 = New System.Windows.Forms.Button()
        Me.btnCloseTia15 = New System.Windows.Forms.Button()
        Me.btnOpenTia15Project = New System.Windows.Forms.Button()
        Me.txt_Status = New System.Windows.Forms.TextBox()
        Me.btnIterateDevices = New System.Windows.Forms.Button()
        Me.btnCloseTia15Project = New System.Windows.Forms.Button()
        Me.btnSaveTia15Project = New System.Windows.Forms.Button()
        Me.btnCreateProject = New System.Windows.Forms.Button()
        Me.btnProjectProperties = New System.Windows.Forms.Button()
        Me.btnCompile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOpenTia15
        '
        Me.btnOpenTia15.Location = New System.Drawing.Point(58, 60)
        Me.btnOpenTia15.Name = "btnOpenTia15"
        Me.btnOpenTia15.Size = New System.Drawing.Size(203, 51)
        Me.btnOpenTia15.TabIndex = 0
        Me.btnOpenTia15.Text = "Apri TIA 15"
        Me.btnOpenTia15.UseVisualStyleBackColor = True
        '
        'btnCloseTia15
        '
        Me.btnCloseTia15.Location = New System.Drawing.Point(58, 140)
        Me.btnCloseTia15.Name = "btnCloseTia15"
        Me.btnCloseTia15.Size = New System.Drawing.Size(203, 51)
        Me.btnCloseTia15.TabIndex = 1
        Me.btnCloseTia15.Text = "Chiudi TIA 15"
        Me.btnCloseTia15.UseVisualStyleBackColor = True
        '
        'btnOpenTia15Project
        '
        Me.btnOpenTia15Project.Location = New System.Drawing.Point(482, 60)
        Me.btnOpenTia15Project.Name = "btnOpenTia15Project"
        Me.btnOpenTia15Project.Size = New System.Drawing.Size(196, 60)
        Me.btnOpenTia15Project.TabIndex = 2
        Me.btnOpenTia15Project.Text = "Apri Progetto"
        Me.btnOpenTia15Project.UseVisualStyleBackColor = True
        '
        'txt_Status
        '
        Me.txt_Status.BackColor = System.Drawing.SystemColors.Menu
        Me.txt_Status.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txt_Status.Location = New System.Drawing.Point(0, 547)
        Me.txt_Status.Name = "txt_Status"
        Me.txt_Status.Size = New System.Drawing.Size(1231, 20)
        Me.txt_Status.TabIndex = 20
        '
        'btnIterateDevices
        '
        Me.btnIterateDevices.Location = New System.Drawing.Point(482, 135)
        Me.btnIterateDevices.Name = "btnIterateDevices"
        Me.btnIterateDevices.Size = New System.Drawing.Size(196, 60)
        Me.btnIterateDevices.TabIndex = 21
        Me.btnIterateDevices.Text = "Iterate devices"
        Me.btnIterateDevices.UseVisualStyleBackColor = True
        '
        'btnCloseTia15Project
        '
        Me.btnCloseTia15Project.Location = New System.Drawing.Point(482, 350)
        Me.btnCloseTia15Project.Name = "btnCloseTia15Project"
        Me.btnCloseTia15Project.Size = New System.Drawing.Size(196, 60)
        Me.btnCloseTia15Project.TabIndex = 22
        Me.btnCloseTia15Project.Text = "Chiudi Progetto"
        Me.btnCloseTia15Project.UseVisualStyleBackColor = True
        '
        'btnSaveTia15Project
        '
        Me.btnSaveTia15Project.Location = New System.Drawing.Point(482, 284)
        Me.btnSaveTia15Project.Name = "btnSaveTia15Project"
        Me.btnSaveTia15Project.Size = New System.Drawing.Size(196, 60)
        Me.btnSaveTia15Project.TabIndex = 23
        Me.btnSaveTia15Project.Text = "Salva Progetto"
        Me.btnSaveTia15Project.UseVisualStyleBackColor = True
        '
        'btnCreateProject
        '
        Me.btnCreateProject.Location = New System.Drawing.Point(717, 60)
        Me.btnCreateProject.Name = "btnCreateProject"
        Me.btnCreateProject.Size = New System.Drawing.Size(196, 60)
        Me.btnCreateProject.TabIndex = 24
        Me.btnCreateProject.Text = "Crea Progetto"
        Me.btnCreateProject.UseVisualStyleBackColor = True
        '
        'btnProjectProperties
        '
        Me.btnProjectProperties.Location = New System.Drawing.Point(862, 232)
        Me.btnProjectProperties.Name = "btnProjectProperties"
        Me.btnProjectProperties.Size = New System.Drawing.Size(218, 83)
        Me.btnProjectProperties.TabIndex = 25
        Me.btnProjectProperties.Text = "Proprietà Progetto"
        Me.btnProjectProperties.UseVisualStyleBackColor = True
        '
        'btnCompile
        '
        Me.btnCompile.Location = New System.Drawing.Point(482, 201)
        Me.btnCompile.Name = "btnCompile"
        Me.btnCompile.Size = New System.Drawing.Size(196, 60)
        Me.btnCompile.TabIndex = 26
        Me.btnCompile.Text = "Compila progetto"
        Me.btnCompile.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 567)
        Me.Controls.Add(Me.btnCompile)
        Me.Controls.Add(Me.btnProjectProperties)
        Me.Controls.Add(Me.btnCreateProject)
        Me.Controls.Add(Me.btnSaveTia15Project)
        Me.Controls.Add(Me.btnCloseTia15Project)
        Me.Controls.Add(Me.btnIterateDevices)
        Me.Controls.Add(Me.txt_Status)
        Me.Controls.Add(Me.btnOpenTia15Project)
        Me.Controls.Add(Me.btnCloseTia15)
        Me.Controls.Add(Me.btnOpenTia15)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOpenTia15 As Button
    Friend WithEvents btnCloseTia15 As Button
    Friend WithEvents btnOpenTia15Project As Button
    Private WithEvents txt_Status As TextBox
    Friend WithEvents btnIterateDevices As Button
    Friend WithEvents btnCloseTia15Project As Button
    Friend WithEvents btnSaveTia15Project As Button
    Friend WithEvents btnCreateProject As Button
    Friend WithEvents btnProjectProperties As Button
    Friend WithEvents btnCompile As Button
End Class
