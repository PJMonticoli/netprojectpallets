Public Class FrmBuscarCliente
    Dim controller As New ControllerPallets
    Private frmPrincipal As FrmPrincipal
    Private dgvClientesLoader As DataGridLoader
    Public cargarModo As ClienteCargarModo
    Sub New(principal As FrmPrincipal)
        InitializeComponent()
        frmPrincipal = principal

    End Sub

    Private Sub FrmBuscarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvClientesLoader = New DataGridLoader(dgvClientes)
        dgvClientesLoader.InicializarGrillaClientes(dgvClientes)
    End Sub

    Private Sub txtBuscarCliente_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarCliente.TextChanged
        Dim busqueda As String = txtBuscarCliente.Text

        If String.IsNullOrWhiteSpace(busqueda) Then
            dgvClientes.DataSource = Nothing
        Else
            filtrarCliente()
        End If
    End Sub

    Private Sub filtrarCliente()
        Dim busqueda As String = txtBuscarCliente.Text
        Dim tablaResultados As New DataTable()
        Dim resultado As Long = controller.buscarCliente(busqueda, tablaResultados)

        If resultado = 1 Then
            dgvClientes.DataSource = tablaResultados
            If dgvClientes.Columns.Contains("CodCliente") Then
                dgvClientes.Columns("CodCliente").Visible = False
            End If
        ElseIf resultado = 0 Then
            dgvClientes.DataSource = Nothing
        Else
            dgvClientes.DataSource = Nothing
            MessageBox.Show("Ocurrió un error durante la búsqueda. Por favor, intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        filtrarCliente()
    End Sub

    Private Sub txtBuscarCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            filtrarCliente()
        End If
    End Sub

    Private Sub dgvClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso e.RowIndex < dgvClientes.Rows.Count Then
                Dim row As DataGridViewRow = dgvClientes.Rows(e.RowIndex)
                If row.Cells("CodCliente") IsNot Nothing AndAlso row.Cells("CodCliente").Value IsNot Nothing Then
                    Dim clienteCod As String = row.Cells("CodCliente").Value.ToString()
                    If Not String.IsNullOrEmpty(clienteCod) Then
                        Select Case cargarModo
                            Case ClienteCargarModo.MovPallets
                                frmPrincipal.CargarClienteEnCombo(clienteCod)
                            Case ClienteCargarModo.DevClientes
                                frmPrincipal.CargarClienteEnComboDevolucion(clienteCod)
                            Case ClienteCargarModo.Informes
                                frmPrincipal.CargarClienteInformesCombo(clienteCod)
                            Case ClienteCargarModo.Reportes
                                frmPrincipal.CargarClienteReporteCombo(clienteCod)
                        End Select
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al procesar el doble clic en la celda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgvClientes.SelectedRows.Count > 0 Then
                Dim row As DataGridViewRow = dgvClientes.SelectedRows(0)
                Dim clienteCod As String = row.Cells("CodCliente").Value.ToString()
                If Not String.IsNullOrEmpty(clienteCod) Then
                    Select Case cargarModo
                        Case ClienteCargarModo.MovPallets
                            frmPrincipal.CargarClienteEnCombo(clienteCod)
                        Case ClienteCargarModo.DevClientes
                            frmPrincipal.CargarClienteEnComboDevolucion(clienteCod)
                        Case ClienteCargarModo.Reportes
                            frmPrincipal.CargarClienteReporteCombo(clienteCod)
                        Case ClienteCargarModo.Informes
                            frmPrincipal.CargarClienteInformesCombo(clienteCod)
                    End Select
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub FrmBuscarCliente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscarCliente.Focus()
    End Sub
End Class
