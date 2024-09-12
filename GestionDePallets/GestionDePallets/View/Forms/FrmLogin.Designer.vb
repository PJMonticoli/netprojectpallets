<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.Pnlestado = New System.Windows.Forms.Panel()
        Me.Lblestado = New System.Windows.Forms.Label()
        Me.Btnminizar = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Btncerrar = New System.Windows.Forms.Button()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.BtnIngresar = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.btnCancelar = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Elipse3 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Pnlestado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnlestado
        '
        Me.Pnlestado.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Pnlestado.Controls.Add(Me.Lblestado)
        Me.Pnlestado.Controls.Add(Me.Btnminizar)
        Me.Pnlestado.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnlestado.Location = New System.Drawing.Point(134, 0)
        Me.Pnlestado.Name = "Pnlestado"
        Me.Pnlestado.Size = New System.Drawing.Size(355, 32)
        Me.Pnlestado.TabIndex = 65
        '
        'Lblestado
        '
        Me.Lblestado.AutoSize = True
        Me.Lblestado.BackColor = System.Drawing.Color.Transparent
        Me.Lblestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblestado.Location = New System.Drawing.Point(121, 5)
        Me.Lblestado.Name = "Lblestado"
        Me.Lblestado.Size = New System.Drawing.Size(0, 18)
        Me.Lblestado.TabIndex = 0
        '
        'Btnminizar
        '
        Me.Btnminizar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Btnminizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Btnminizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Btnminizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnminizar.FlatAppearance.BorderSize = 0
        Me.Btnminizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnminizar.Image = CType(resources.GetObject("Btnminizar.Image"), System.Drawing.Image)
        Me.Btnminizar.Location = New System.Drawing.Point(327, 3)
        Me.Btnminizar.Margin = New System.Windows.Forms.Padding(0)
        Me.Btnminizar.Name = "Btnminizar"
        Me.Btnminizar.Size = New System.Drawing.Size(25, 25)
        Me.Btnminizar.TabIndex = 59
        Me.Btnminizar.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.White
        Me.txtPassword.Location = New System.Drawing.Point(156, 139)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(308, 15)
        Me.txtPassword.TabIndex = 64
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.ForeColor = System.Drawing.Color.White
        Me.txtUsername.Location = New System.Drawing.Point(156, 74)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(308, 15)
        Me.txtUsername.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LightGray
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(181, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 19)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Contraseña"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LightGray
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(181, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 19)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Usuario"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Guna2PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(134, 250)
        Me.Panel1.TabIndex = 66
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.FillColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.Guna2PictureBox1.Image = CType(resources.GetObject("Guna2PictureBox1.Image"), System.Drawing.Image)
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(3, 50)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(128, 136)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 0
        Me.Guna2PictureBox1.TabStop = False
        '
        'Btncerrar
        '
        Me.Btncerrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Btncerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Btncerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Btncerrar.FlatAppearance.BorderSize = 0
        Me.Btncerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Btncerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.Btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btncerrar.Location = New System.Drawing.Point(416, -100)
        Me.Btncerrar.Margin = New System.Windows.Forms.Padding(0)
        Me.Btncerrar.Name = "Btncerrar"
        Me.Btncerrar.Size = New System.Drawing.Size(27, 32)
        Me.Btncerrar.TabIndex = 67
        Me.Btncerrar.UseVisualStyleBackColor = False
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.TargetControl = Me.BtnIngresar
        '
        'BtnIngresar
        '
        Me.BtnIngresar.Animated = True
        Me.BtnIngresar.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnIngresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnIngresar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnIngresar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.BtnIngresar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.BtnIngresar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.BtnIngresar.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.BtnIngresar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnIngresar.ForeColor = System.Drawing.Color.White
        Me.BtnIngresar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnIngresar.Image = CType(resources.GetObject("BtnIngresar.Image"), System.Drawing.Image)
        Me.BtnIngresar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.BtnIngresar.Location = New System.Drawing.Point(172, 193)
        Me.BtnIngresar.Name = "BtnIngresar"
        Me.BtnIngresar.Size = New System.Drawing.Size(118, 36)
        Me.BtnIngresar.TabIndex = 68
        Me.BtnIngresar.Text = "       Iniciar Sesión"
        Me.BtnIngresar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Guna2Elipse2
        '
        Me.Guna2Elipse2.TargetControl = Me
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnCancelar.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btnCancelar.ImageSize = New System.Drawing.Size(30, 30)
        Me.btnCancelar.Location = New System.Drawing.Point(314, 193)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(118, 36)
        Me.btnCancelar.TabIndex = 69
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Guna2Elipse3
        '
        Me.Guna2Elipse3.TargetControl = Me.btnCancelar
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(489, 250)
        Me.Controls.Add(Me.Pnlestado)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Btncerrar)
        Me.Controls.Add(Me.BtnIngresar)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmLogin"
        Me.Pnlestado.ResumeLayout(False)
        Me.Pnlestado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pnlestado As Panel
    Friend WithEvents Lblestado As Label
    Friend WithEvents Btnminizar As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Btncerrar As Button
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents BtnIngresar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents btnCancelar As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Elipse3 As Guna.UI2.WinForms.Guna2Elipse
End Class
