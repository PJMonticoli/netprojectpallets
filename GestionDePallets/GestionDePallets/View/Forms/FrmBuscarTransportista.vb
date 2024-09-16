Public Class FrmBuscarTransportista
    Dim controller As New ControllerPallets
    Private frmPrincipal As FrmPrincipal
    Private dgvTransportistaLoader As DataGridLoader
    Public cargarModo As TransportistaCargarModo
    Sub New(principal As FrmPrincipal)
        InitializeComponent()
        frmPrincipal = principal
    End Sub

    Private Sub FrmBuscarTransportistaLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvTransportistaLoader = New DataGridLoader(dgvTransportistas)
        dgvTransportistaLoader.InicializarGrillaTransportistas(dgvTransportistas)
    End Sub

    Private Sub txtBuscarTransportistas_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarTransportistas.TextChanged
        Dim busqueda As String = txtBuscarTransportistas.Text

        If String.IsNullOrWhiteSpace(busqueda) Then
            dgvTransportistas.DataSource = Nothing
        Else
            filtrarTransportista()
        End If
    End Sub

    Private Sub filtrarTransportista()
        Dim busqueda As String = txtBuscarTransportistas.Text
        Dim tablaResultados As New DataTable()
        Dim resultado As Long = controller.buscarTransportistas(busqueda, tablaResultados)

        If resultado = 1 Then
            dgvTransportistas.DataSource = tablaResultados
            ' Ocultar la columna CodFletero
            If dgvTransportistas.Columns.Contains("CodFletero") Then
                dgvTransportistas.Columns("CodFletero").Visible = False
            End If
        ElseIf resultado = 0 Then
            dgvTransportistas.DataSource = Nothing
        Else
            dgvTransportistas.DataSource = Nothing
            MessageBox.Show("Ocurrió un error durante la búsqueda. Por favor, intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnBuscarTransportista_Click(sender As Object, e As EventArgs) Handles btnBuscarTransportista.Click
        filtrarTransportista()
    End Sub

    Private Sub dgvTransportistas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransportistas.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvTransportistas.Rows.Count Then
            Dim row As DataGridViewRow = dgvTransportistas.Rows(e.RowIndex)
            Dim fleteroCod As String = row.Cells("CodFletero").Value.ToString()

            If Not String.IsNullOrEmpty(fleteroCod) Then
                Select Case cargarModo
                    Case TransportistaCargarModo.MovPallets
                        frmPrincipal.CargarTransportistaEnCombo(fleteroCod)
                    Case TransportistaCargarModo.Reportes
                        frmPrincipal.CargarTransportistaReporte(fleteroCod)
                    Case TransportistaCargarModo.Informes
                        frmPrincipal.CargarTransportistaInformes(fleteroCod)
                    Case Else
                        MessageBox.Show("Modo de carga no especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select
                Me.Close()
            End If
        End If
    End Sub

    Private Sub dgvTransportistas_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvTransportistas.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgvTransportistas.SelectedRows.Count > 0 Then
                Dim row As DataGridViewRow = dgvTransportistas.SelectedRows(0)
                Dim fleteroCod As String = row.Cells("CodFletero").Value.ToString()

                If Not String.IsNullOrEmpty(fleteroCod) Then
                    Select Case cargarModo
                        Case TransportistaCargarModo.MovPallets
                            frmPrincipal.CargarTransportistaEnCombo(fleteroCod)
                        Case TransportistaCargarModo.Reportes
                            frmPrincipal.CargarTransportistaReporte(fleteroCod)
                        Case TransportistaCargarModo.Informes
                            frmPrincipal.CargarTransportistaInformes(fleteroCod)
                        Case Else
                            MessageBox.Show("Modo de carga no especificado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Select
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub FrmBuscarTransportista_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtBuscarTransportistas.Focus()
    End Sub

    Private Sub txtBuscarTransportistas_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarTransportistas.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            filtrarTransportista()
            dgvTransportistas.Focus()
        End If
    End Sub
End Class
