<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscarTransportista
    Inherits MaterialSkin.Controls.MaterialForm

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscarTransportista))
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.MaterialCard1 = New MaterialSkin.Controls.MaterialCard()
        Me.dgvTransportistas = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.txtBuscarTransportistas = New MaterialSkin.Controls.MaterialTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscarTransportista = New Guna.UI2.WinForms.Guna2Button()
        Me.MaterialCard1.SuspendLayout()
        CType(Me.dgvTransportistas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MaterialCard1
        '
        Me.MaterialCard1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MaterialCard1.Controls.Add(Me.dgvTransportistas)
        Me.MaterialCard1.Controls.Add(Me.txtBuscarTransportistas)
        Me.MaterialCard1.Controls.Add(Me.Label1)
        Me.MaterialCard1.Controls.Add(Me.btnBuscarTransportista)
        Me.MaterialCard1.Depth = 0
        Me.MaterialCard1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MaterialCard1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MaterialCard1.Location = New System.Drawing.Point(3, 64)
        Me.MaterialCard1.Margin = New System.Windows.Forms.Padding(14)
        Me.MaterialCard1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialCard1.Name = "MaterialCard1"
        Me.MaterialCard1.Padding = New System.Windows.Forms.Padding(14)
        Me.MaterialCard1.Size = New System.Drawing.Size(516, 402)
        Me.MaterialCard1.TabIndex = 44
        '
        'dgvTransportistas
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvTransportistas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransportistas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTransportistas.ColumnHeadersHeight = 4
        Me.dgvTransportistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTransportistas.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTransportistas.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransportistas.Location = New System.Drawing.Point(7, 98)
        Me.dgvTransportistas.Name = "dgvTransportistas"
        Me.dgvTransportistas.RowHeadersVisible = False
        Me.dgvTransportistas.Size = New System.Drawing.Size(454, 179)
        Me.dgvTransportistas.TabIndex = 43
        Me.dgvTransportistas.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvTransportistas.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvTransportistas.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvTransportistas.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvTransportistas.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvTransportistas.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvTransportistas.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransportistas.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransportistas.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvTransportistas.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTransportistas.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvTransportistas.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvTransportistas.ThemeStyle.HeaderStyle.Height = 4
        Me.dgvTransportistas.ThemeStyle.ReadOnly = False
        Me.dgvTransportistas.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvTransportistas.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvTransportistas.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvTransportistas.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvTransportistas.ThemeStyle.RowsStyle.Height = 22
        Me.dgvTransportistas.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvTransportistas.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'txtBuscarTransportistas
        '
        Me.txtBuscarTransportistas.AnimateReadOnly = False
        Me.txtBuscarTransportistas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBuscarTransportistas.Depth = 0
        Me.txtBuscarTransportistas.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.txtBuscarTransportistas.Hint = "Ingresar CodFletero o Razón Social"
        Me.txtBuscarTransportistas.LeadingIcon = Nothing
        Me.txtBuscarTransportistas.Location = New System.Drawing.Point(8, 42)
        Me.txtBuscarTransportistas.MaxLength = 50
        Me.txtBuscarTransportistas.MouseState = MaterialSkin.MouseState.OUT
        Me.txtBuscarTransportistas.Multiline = False
        Me.txtBuscarTransportistas.Name = "txtBuscarTransportistas"
        Me.txtBuscarTransportistas.Size = New System.Drawing.Size(343, 50)
        Me.txtBuscarTransportistas.TabIndex = 42
        Me.txtBuscarTransportistas.Text = ""
        Me.txtBuscarTransportistas.TrailingIcon = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(250, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filtrar por Código y/o Razón Social"
        '
        'btnBuscarTransportista
        '
        Me.btnBuscarTransportista.Animated = True
        Me.btnBuscarTransportista.AutoRoundedCorners = True
        Me.btnBuscarTransportista.BackColor = System.Drawing.Color.White
        Me.btnBuscarTransportista.BorderRadius = 16
        Me.btnBuscarTransportista.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarTransportista.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnBuscarTransportista.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnBuscarTransportista.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnBuscarTransportista.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnBuscarTransportista.FillColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnBuscarTransportista.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarTransportista.ForeColor = System.Drawing.Color.White
        Me.btnBuscarTransportista.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnBuscarTransportista.Image = CType(resources.GetObject("btnBuscarTransportista.Image"), System.Drawing.Image)
        Me.btnBuscarTransportista.Location = New System.Drawing.Point(356, 58)
        Me.btnBuscarTransportista.Name = "btnBuscarTransportista"
        Me.btnBuscarTransportista.Size = New System.Drawing.Size(105, 34)
        Me.btnBuscarTransportista.TabIndex = 41
        Me.btnBuscarTransportista.Text = "Buscar"
        '
        'FrmBuscarTransportista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 469)
        Me.Controls.Add(Me.MaterialCard1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmBuscarTransportista"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Transportista"
        Me.MaterialCard1.ResumeLayout(False)
        Me.MaterialCard1.PerformLayout()
        CType(Me.dgvTransportistas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents MaterialCard1 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBuscarTransportista As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtBuscarTransportistas As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents dgvTransportistas As Guna.UI2.WinForms.Guna2DataGridView
End Class
