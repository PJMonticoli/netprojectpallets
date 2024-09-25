Imports FluentValidation.Results
Imports Guna.UI2.WinForms
Imports MaterialSkin
Imports MaterialSkin.Controls
Imports System.Globalization
Imports System.Reflection
Imports System.Text.RegularExpressions

Public Class FrmPrincipal
    Private controller As New ControllerPallets()
    Dim controllerReportes As New ControllerReportes()
    Dim controllerInforme As New ControllerInformes()
    Private dashboardMetodos As New DashboardLoader(controller)
    Private dgvParteSalidaLoader As DataGridLoader
    Private dgvMovPalletsLoader As DataGridLoader
    Private dgvDevClienteLoader As DataGridLoader
    Private dgvDevClienteDevLoader As DataGridLoader
    Private dgvReporteLoader As DataGridLoader
    Private selectedRowIndex As Integer = -1
    Public Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String, ByVal cch As Int32) As Int32
    Dim palletDevCliente As New PalletCliente()
    Dim DeDoneVengo As Integer = 0


    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDashboard()
        cargarGrillas()
        cargarCombos()
        cargarDateTimePickers()
        ColoresFrmPrincipal()
        System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("es-ES")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-ES")
        If Environment.GetCommandLineArgs.Length > 1 Then
            If Environment.GetCommandLineArgs(1).Length >= 1 Then
                Dim nroparte As Integer = Environment.GetCommandLineArgs(1)
                Dim formulario As String = Environment.GetCommandLineArgs(2)
                Me.DrawerTabControl = Nothing 'Me oculta el boton de mi tabcontrol para evitar navegacion entre pestañas
                txtNroParteSalidaDev.Enabled = False
                txtNroParteSalida.Enabled = False
                If formulario.ToUpper() = "PalletsCliente".ToUpper Then
                    DeDoneVengo = 1
                    palletDevCliente.NroParteSalida = nroparte
                    tabControl.SelectedIndex = 2
                    txtNroParteSalida.Text = nroparte
                    btnBuscar_Click(sender, e)
                    Me.Text = "Egreso Pallets por Cliente"
                ElseIf formulario.ToUpper() = "DevCliente".ToUpper Then
                    Me.Text = "Regreso Parte Salida"
                    tabControl.SelectedIndex = 3
                    btnLimpiarDevCliente.Visible = False
                    txtNroParteSalidaDev.Enabled = False
                    If nroparte = 0 Then
                        DeDoneVengo = 3
                        dgvClientesDevolucion.Visible = False
                    Else
                        DeDoneVengo = 2
                        palletDevCliente.NroParteSalida = nroparte
                        txtNroParteSalidaDev.Text = nroparte
                        ProcesarParteSalidaDev(nroparte.ToString())
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ColoresFrmPrincipal()
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Primary.BlueGrey500, TextShade.WHITE)
    End Sub
    Private Sub cargarDateTimePickers()
        dtpFechaDev.Value = Now()
        txtFechaCargaDev.Text = Now()
        txtFechaCargaEgreso.Text = Now()
        dtpFecha.Value = Now()
        txtFechaCarga.Text = Now()
        dtpFechaDesde.Value = DateTime.Now.AddDays(-31)
        dtpFechaHasta.Value = DateTime.Now
        dtpFechaDesdeSaldo.Value = DateTime.Now.AddDays(-31)
        dtpFechaHastaSaldo.Value = DateTime.Now
    End Sub


    Private Sub cargarDashboard()
        ' Source - DashboardMetodos esta la logica de carga gráficos
        dashboardMetodos.LoadKPIEstados(lblCantBuenEstado, lblCantMalEstado, cantBuenEstado, cantMalEstado, lblPorcBuenEstado, lblPorcMalEstado)
        dashboardMetodos.LoadKPIRetornos(lblCantRetorno, lblCantSinRetorno)
        dashboardMetodos.LoadKPICantidades(lblCantIngreso, lblCantEgreso)
        dashboardMetodos.LoadBarChart(barChartRanking)
        dashboardMetodos.LoadLineChart(lineChartEstados)
    End Sub

    Private Sub cargarGrillas()
        ' Source - DataGridLoader esta la logica de carga grilla
        dgvParteSalidaLoader = New DataGridLoader(dgvParteSalida, txtCantidadPallets, txtPosicionPalletDesde, txtPosicionPalletHasta, txtOrdenEntrega, txtCodCliente, txtRazonSocial)
        dgvMovPalletsLoader = New DataGridLoader(dgvMovPallets)
        dgvMovPalletsLoader.InicializarGrillaMovimientos(dgvMovPallets)
        dgvMovPalletsLoader.CargarDatosEnGrilla(controller)

        dgvDevClienteLoader = New DataGridLoader(dgvDevCliente)
        dgvDevClienteLoader.InicializarGrillaDevolucionCliente(dgvDevCliente)

        dgvDevClienteDevLoader = New DataGridLoader(dgvClientesDevolucion)
        dgvDevClienteDevLoader.InicializarGrillaClientesDevolucion(dgvClientesDevolucion)

        ' Crear una instancia de DataGridLoader pasando el DataGridView
        Dim dgvLoader As New DataGridLoader(dgvReporte)

        ' Cargar los datos iniciales en la grilla
        dgvLoader.CargarDatosEnGrillaReporteInicial(controllerReportes)


        Dim dgvInformeLoader As New DataGridLoader(dgvInformeSaldos)
        dgvInformeLoader.CargarDatosEnGrillaInformeSaldosInicial(controllerInforme)
    End Sub

    Private Sub cargarCombos()
        ' Configurar ComboBox libreriaMaterialSkin
        ComboBoxFunctions.CargarComboGeneral(cboTipoMovimiento, 1)
        cboTipoMovimiento.SelectedIndex = -1
        ComboBoxFunctions.CargarComboGeneral(cboTipoPallet, 1)
        cboTipoPallet.SelectedIndex = 2

        ' Configurar ComboBox libreriaGuna
        ComboBoxFunctions.CargarComboGeneral(cboCliente, 2)
        cboCliente.SelectedIndex = -1
        ComboBoxFunctions.CargarComboGeneral(cboClienteDevolucion, 2)
        cboClienteDevolucion.SelectedIndex = -1
        ComboBoxFunctions.CargarComboGeneral(cboTransportista, 2)
        cboTransportista.SelectedIndex = -1
        ComboBoxFunctions.CargarComboGeneral(cboTransportistaDev, 2)
        cboTransportistaDev.SelectedIndex = -1

        'REPORTES
        ComboBoxFunctions.CargarComboGeneral(cboClienteReporte, 2)
        cboClienteReporte.SelectedIndex = -1
        ComboBoxFunctions.CargarComboGeneral(cboTraReporte, 2)
        cboTraReporte.SelectedIndex = -1
        ComboBoxFunctions.CargarComboGeneral(cboTipoMovReporte, 2)
        cboTipoMovReporte.SelectedIndex = -1
        ComboBoxFunctions.CargarComboGeneral(cboTipoPalletReporte, 2)
        cboTipoPalletReporte.SelectedIndex = -1

        'INFORMES
        ComboBoxFunctions.CargarComboGeneral(cboClienteInforme, 2)
        cboClienteInforme.SelectedIndex = -1
        ComboBoxFunctions.CargarComboGeneral(cboTransportistaInforme, 2)
        cboTransportistaInforme.SelectedIndex = -1
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea registrar el movimiento del pallet?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Exit Sub
        End If

        ' Module - ModuleFunciones
        Dim exito As Boolean = ModuloFunciones.RegistrarMovimientoPallet(
        dtpFecha.Value.Date,
        DateTime.Now(),
        swtRetorno.Checked,
        If(cboTipoPallet.SelectedValue IsNot Nothing, CLng(cboTipoPallet.SelectedValue), CType(Nothing, Long?)),
        If(cboTipoMovimiento.SelectedValue IsNot Nothing AndAlso Long.TryParse(cboTipoMovimiento.SelectedValue.ToString(), Nothing), CLng(cboTipoMovimiento.SelectedValue), CType(Nothing, Long?)),
        If(cboCliente.SelectedValue IsNot Nothing, CInt(cboCliente.SelectedValue), CType(Nothing, Integer?)),
        If(cboTransportista.SelectedValue IsNot Nothing, CLng(cboTransportista.SelectedValue), CType(Nothing, Long?)),
        If(Integer.TryParse(txtCantidad.Text, Nothing), Integer.Parse(txtCantidad.Text), 0),
        If(String.IsNullOrEmpty(txtObservacion.Text), "Sin observación", txtObservacion.Text),
        If(rbtBuenEstado.Checked, 1, If(rbtMalEstado.Checked, 2, If(rbtVale.Checked, 3, 0))))

        If exito Then
            dgvMovPalletsLoader.CargarDatosEnGrilla(controller)
            LimpiarCampos()
            ' Fuerzo limpiar los cbo aca en vez de mi control 
            cboCliente.SelectedIndex = -1
            cboTransportista.SelectedIndex = -1
        End If
    End Sub



    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim nroParteSalida As Integer

        If String.IsNullOrWhiteSpace(txtNroParteSalida.Text) Then
            MsgBox("Por favor, ingrese un número de parte de salida.", MsgBoxStyle.Exclamation, "Advertencia")
            Return
        End If

        If Integer.TryParse(txtNroParteSalida.Text, nroParteSalida) Then
            Dim tabla As DataTable
            Dim totalPallets As Integer

            ' Module - ModuleFunciones
            Dim exito As Boolean = ModuloFunciones.BuscarParteSalida(nroParteSalida, totalPallets, tabla)

            If exito Then
                dgvParteSalidaLoader.ConfigurarDataGridView(tabla)
                txtCantTotalPallets.Text = totalPallets.ToString()
                dgvParteSalida.Visible = True
                lblTotalPallets.Visible = True
                groupTotales.Visible = True
                txtCantTotalPallets.Visible = True
                txtPalletsInsertados.Visible = True
                lblPalletsInsertados.Visible = True
                btnRegistrarAsignacion.Visible = True

                ' Mover el foco a la primera fila de la grilla
                If dgvParteSalida.Rows.Count > 0 Then
                    dgvParteSalida.CurrentCell = dgvParteSalida.Rows(0).Cells(0)
                    dgvParteSalida.Focus()
                End If
            Else
                MsgBox("Ingrese un NroParteSalida válido. Por favor, verifique el número y vuelva a intentarlo.", MsgBoxStyle.Information, "Sin Resultados")
            End If
        Else
            MsgBox("Por favor, ingrese un número de parte de salida válido.", MsgBoxStyle.Exclamation, "Advertencia")
        End If
    End Sub





    Private Sub dgvParteSalida_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParteSalida.CellDoubleClick
        ProcessSelectedRow(e.RowIndex)
    End Sub

    Private Sub dgvParteSalida_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvParteSalida.KeyDown
        If e.KeyCode = Keys.Enter AndAlso dgvParteSalida.SelectedCells.Count > 0 Then
            Dim selectedCell As DataGridViewCell = dgvParteSalida.SelectedCells(0)
            ProcessSelectedRow(selectedCell.RowIndex)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ProcessSelectedRow(rowIndex As Integer)
        If rowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvParteSalida.Rows(rowIndex)
            txtOrdenEntrega.Text = selectedRow.Cells("NroEntrega").Value.ToString()
            txtCodCliente.Text = selectedRow.Cells("CodCliente").Value.ToString()
            txtRazonSocial.Text = selectedRow.Cells("Cliente").Value.ToString()
            Dim clienteCompleto As String = selectedRow.Cells("Cliente").Value.ToString()
            Dim indexGuion As Integer = clienteCompleto.IndexOf("-"c)


            If indexGuion >= 0 Then
                txtRazonSocial.Text = clienteCompleto.Substring(indexGuion + 1).Trim()
            End If

            Dim cantidadPallets As Object = selectedRow.Cells("CantidadPallets").Value
            If cantidadPallets IsNot Nothing AndAlso Not IsDBNull(cantidadPallets) Then
                txtCantidadPallets.Text = cantidadPallets.ToString()
            Else
                txtCantidadPallets.Clear()
            End If

            Dim posicionPallet As Object = selectedRow.Cells("PosicionPalletCamion").Value
            If posicionPallet IsNot Nothing AndAlso Not IsDBNull(posicionPallet) Then
                Dim posiciones() As String = posicionPallet.ToString().Split(New String() {" a "}, StringSplitOptions.None)
                If posiciones.Length = 2 Then
                    txtPosicionPalletDesde.Text = posiciones(0).Trim()
                    txtPosicionPalletHasta.Text = posiciones(1).Trim()
                Else
                    txtPosicionPalletDesde.Text = posiciones(0).Trim()
                    txtPosicionPalletHasta.Clear()
                End If
            Else
                txtPosicionPalletDesde.Clear()
                txtPosicionPalletHasta.Clear()
            End If

            Me.BeginInvoke(Sub() txtCantidadPallets.Focus())
            txtCantidadPallets.SelectAll()
        End If
    End Sub

    Private Sub txtCantidadPallets_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadPallets.KeyDown
        If txtCantidadPallets.Text <> "" AndAlso e.KeyCode = Keys.Enter Then
            ' Evitar el sonido del sistema
            e.Handled = True
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
            txtPosicionPalletDesde.SelectAll()
        End If
    End Sub


    Private Sub txtPosicionPalletDesde_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPosicionPalletDesde.KeyDown
        If txtPosicionPalletDesde.Text <> "" AndAlso e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            SendKeys.Send("{TAB}")
            txtPosicionPalletHasta.SelectAll()
        End If
    End Sub
    Private Sub txtPosicionPalletHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPosicionPalletHasta.KeyDown
        If txtCantidadPallets.Text <> "" AndAlso txtPosicionPalletDesde.Text <> "" AndAlso txtPosicionPalletHasta.Text <> "" AndAlso e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            ModuloFunciones.InsertarAsignacion(dgvParteSalidaLoader, dgvParteSalida, txtPalletsInsertados)
        End If
    End Sub

    Private Sub btnInsertarAsignacion_Click(sender As Object, e As EventArgs) Handles btnInsertarAsignacion.Click
        ModuloFunciones.InsertarAsignacion(dgvParteSalidaLoader, dgvParteSalida, txtPalletsInsertados)
    End Sub
    Private Sub btnRegistrarAsignacion_Click(sender As Object, e As EventArgs) Handles btnRegistrarAsignacion.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea registrar la asignación de pallets?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Exit Sub
        End If

        ' Obtener el total esperado de pallets desde el txtCantTotalPallets
        Dim totalPalletsEsperados As Integer
        If Not Integer.TryParse(txtCantTotalPallets.Text, totalPalletsEsperados) Then
            MessageBox.Show("El total de pallets esperados no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Module - ModuloFunciones
        Dim exito As Boolean = ModuloFunciones.RegistrarAsignaciones(totalPalletsEsperados, dgvParteSalida, controller)

        If exito Then
            limpiarDgvParteSalida()
            If DeDoneVengo = 1 Then
                txtNroParteSalida.Enabled = True
                FrmLogin.Close()
                Me.Close()
                Application.Exit()
            End If
        End If
    End Sub


    Private Sub txtNroParteSalida_TextChanged(sender As Object, e As EventArgs) Handles txtNroParteSalida.TextChanged
        If String.IsNullOrWhiteSpace(txtNroParteSalida.Text) Then
            limpiarDgvParteSalida()
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        cboCliente.SelectedIndex = -1
        Dim frmBuscarCliente As New FrmBuscarCliente(Me)
        frmBuscarCliente.cargarModo = ClienteCargarModo.MovPallets
        frmBuscarCliente.ShowDialog(Me)
    End Sub

    Public Sub CargarClienteEnCombo(clienteCod As String)
        For Each item As DataRowView In cboCliente.Items
            If item.Row("CodCliente").ToString() = clienteCod Then
                cboCliente.SelectedItem = item
                Exit For
            End If
        Next
    End Sub

    Public Sub CargarClienteEnComboDevolucion(clienteCod As String)
        For Each item As DataRowView In cboClienteDevolucion.Items
            If item.Row("CodCliente").ToString() = clienteCod Then
                cboClienteDevolucion.SelectedItem = item
                Exit For
            End If
        Next
    End Sub

    Public Sub CargarTransportistaReporte(fleteroCod As String)
        If cboTraReporte.Items.Count > 0 Then
            For Each item As DataRowView In cboTraReporte.Items
                If item("CodFletero").ToString() = fleteroCod Then
                    cboTraReporte.SelectedItem = item
                    Exit For
                End If
            Next
        End If
    End Sub
    Public Sub CargarTransportistaInformes(fleteroCod As String)
        If cboTransportistaInforme.Items.Count > 0 Then
            For Each item As DataRowView In cboTransportistaInforme.Items
                If item("CodFletero").ToString() = fleteroCod Then
                    cboTransportistaInforme.SelectedItem = item
                    Exit For
                End If
            Next
        End If
    End Sub

    Public Sub CargarTransportistaEnCombo(fleteroCod As String)
        If cboTransportista.Items.Count > 0 Then
            For Each item As DataRowView In cboTransportista.Items
                If item("CodFletero").ToString() = fleteroCod Then
                    cboTransportista.SelectedItem = item
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnBuscarTransportista_Click(sender As Object, e As EventArgs) Handles btnBuscarTransportista.Click
        cboTransportista.SelectedIndex = -1
        Dim frmBuscarTransportista As New FrmBuscarTransportista(Me)
        frmBuscarTransportista.cargarModo = TransportistaCargarModo.MovPallets
        frmBuscarTransportista.ShowDialog(Me)
    End Sub


    Private Sub ProcesarParteSalidaDev(nroParteSalida As String)
        If Not String.IsNullOrEmpty(nroParteSalida) Then
            Dim transportistaId As Integer = controller.ObtenerTransportista(nroParteSalida)
            Dim clientes As DataTable = controller.ObtenerClientes(nroParteSalida)
            dgvDevClienteDevLoader.CargarClientesEnGrilla(clientes)

            If transportistaId <> 0 Then
                cboTransportistaDev.SelectedValue = transportistaId
                cboTransportistaDev.Enabled = False
            Else
                MsgBox("Transportista no encontrado en la lista.", MsgBoxStyle.Information, "Aviso")
            End If

            dgvClientesDevolucion.Focus()
        End If
    End Sub


    Private Sub txtNroParteSalidaDev_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroParteSalidaDev.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim nroParteSalida As String = txtNroParteSalidaDev.Text
            e.Handled = True
            e.SuppressKeyPress = True
            ProcesarParteSalidaDev(nroParteSalida)
        End If
    End Sub




    Private Sub btnSigCliente_Click(sender As Object, e As EventArgs) Handles btnSigCliente.Click
        Dim codFleteroNum As Integer

        If cboTransportistaDev.SelectedValue Is Nothing OrElse Not Integer.TryParse(cboTransportistaDev.SelectedValue.ToString(), codFleteroNum) Then
            MessageBox.Show("Debe seleccionar un transportista válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cantidad As Integer = 0
        Dim cantidadMalEstado As Integer = 0
        Dim cantidadVale As Integer = 0

        ' Validar cantidad en buen estado
        If Not String.IsNullOrEmpty(txtCantBuenEstado.Text) AndAlso Not Integer.TryParse(txtCantBuenEstado.Text, cantidad) Then
            MessageBox.Show("Cantidad en buen estado no es válida. Ingrese valores numéricos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validar cantidad en mal estado
        If Not String.IsNullOrEmpty(txtCantMalEstado.Text) AndAlso Not Integer.TryParse(txtCantMalEstado.Text, cantidadMalEstado) Then
            MessageBox.Show("Cantidad en mal estado no es válida. Ingrese valores numéricos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validar cantidad vale
        If Not String.IsNullOrEmpty(txtCantVale.Text) AndAlso Not Integer.TryParse(txtCantVale.Text, cantidadVale) Then
            MessageBox.Show("Cantidad vale no es válida. Ingrese valores numéricos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim razonSocialCliente As String = cboClienteDevolucion.Text
        Dim Observacion As String = txtObservacionDev.Text

        ' Verificar si se ha seleccionado un cliente
        If cboClienteDevolucion.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(cboClienteDevolucion.SelectedValue.ToString()) Then
            MessageBox.Show("Debe seleccionar un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' asigno NroParteSalida 999 si viene vacio
        If String.IsNullOrEmpty(txtNroParteSalidaDev.Text) OrElse txtNroParteSalidaDev.Text = 0 Then
            txtNroParteSalidaDev.Text = "999"
        End If

        ' Crear una instancia del modelo de datos
        Dim pallet As New PalletModel() With {
        .Fecha = dtpFecha.Value,
        .FechaCarga = DateTime.Now,
        .CodCliente = If(Integer.TryParse(cboClienteDevolucion.SelectedValue.ToString(), Nothing), CInt(cboClienteDevolucion.SelectedValue), 0),
        .CodFletero = codFleteroNum,
        .Cantidad = cantidad,
        .CantidadMalEstado = cantidadMalEstado,
        .CantidadVale = cantidadVale,
        .Observacion = Observacion,
        .NroParteSalida = txtNroParteSalidaDev.Text
    }

        Dim validador As New DevPalletValidador()
        Dim resultado As ValidationResult = validador.Validate(pallet)

        If resultado.IsValid Then
            Dim row As String() = {
            pallet.Fecha.ToString("dd-MM-yyyy"),
            pallet.FechaCarga.ToString("dd-MM-yyyy HH:mm"),
            cboTransportistaDev.Text,
            razonSocialCliente,
            pallet.Cantidad.ToString(),
            pallet.CantidadMalEstado.ToString(),
            pallet.CantidadVale.ToString(),
            If(String.IsNullOrEmpty(Observacion), "Sin observación", Observacion),
            pallet.NroParteSalida
        }


            If selectedRowIndex >= 0 AndAlso selectedRowIndex < dgvDevCliente.Rows.Count Then
                ' Actualizar la fila existente
                For i As Integer = 0 To row.Length - 1
                    dgvDevCliente.Rows(selectedRowIndex).Cells(i).Value = row(i)
                Next
                selectedRowIndex = -1
            Else
                dgvDevCliente.Rows.Add(row)
            End If


            Dim rowsToRemove As New List(Of DataGridViewRow)()
            For Each rowc As DataGridViewRow In dgvClientesDevolucion.SelectedRows

                If Not rowc.IsNewRow Then
                    rowsToRemove.Add(rowc)
                End If
            Next

            For Each rowc As DataGridViewRow In rowsToRemove
                dgvClientesDevolucion.Rows.Remove(rowc)
            Next

            limpiarControlesCargaDev()
            cboClienteDevolucion.SelectedIndex = -1
            dgvClientesDevolucion.Focus()
        Else
            Dim errores As String = String.Join(Environment.NewLine, resultado.Errors.Select(Function(validationError) validationError.ErrorMessage))
            MessageBox.Show(errores, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub









    Private Sub BuscarClienteDev(sender As Object, e As EventArgs) Handles btnBuscarClienteDev.Click
        cboClienteDevolucion.SelectedIndex = -1
        Dim frmClienteDev As New FrmBuscarCliente(Me)
        frmClienteDev.cargarModo = ClienteCargarModo.DevClientes
        frmClienteDev.ShowDialog(Me)
    End Sub

    Private Sub btnClienteReporte_Click(sender As Object, e As EventArgs) Handles btnClienteReporte.Click
        cboClienteReporte.SelectedIndex = -1
        Dim frmBuscarCliente As New FrmBuscarCliente(Me)
        frmBuscarCliente.cargarModo = ClienteCargarModo.Reportes
        frmBuscarCliente.ShowDialog(Me)
    End Sub

    Public Sub CargarClienteReporteCombo(clienteCod As String)
        For Each item As DataRowView In cboClienteReporte.Items
            If item.Row("CodCliente").ToString() = clienteCod Then
                cboClienteReporte.SelectedItem = item
                Exit For
            End If
        Next
    End Sub

    Public Sub CargarClienteInformesCombo(clienteCod As String)
        For Each item As DataRowView In cboClienteInforme.Items
            If item.Row("CodCliente").ToString() = clienteCod Then
                cboClienteInforme.SelectedItem = item
                Exit For
            End If
        Next
    End Sub



    Private Sub btnRegistrarDevolucion_Click(sender As Object, e As EventArgs) Handles btnRegistrarDevolucion.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea registrar el Regreso por Parte Salida?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Exit Sub
        End If

        ' Obtener el código del fletero desde el ComboBox
        Dim codFletero As Integer

        ' Verificar si se ha seleccionado un valor en el ComboBox
        If cboTransportistaDev.SelectedValue Is Nothing OrElse Not Integer.TryParse(cboTransportistaDev.SelectedValue.ToString(), codFletero) Then
            MessageBox.Show("Debe seleccionar un transportista válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim exitoTotal As Boolean = True

        For Each row As DataGridViewRow In dgvDevCliente.Rows
            If Not row.IsNewRow Then
                Dim fechaSeleccionada As DateTime = dtpFechaDev.Value
                Dim clienteTexto As String = row.Cells("Cliente").Value.ToString()
                Dim clienteCod As Integer

                ' Usa una expresión regular para extraer el código del cliente del texto
                Dim clienteRegex As New Regex("^\d+")
                Dim clienteMatch As Match = clienteRegex.Match(clienteTexto)
                If clienteMatch.Success Then
                    Integer.TryParse(clienteMatch.Value, clienteCod)
                Else
                    MessageBox.Show("El código de cliente en la fila es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    exitoTotal = False
                    Exit For
                End If

                ' Obtener el transportista desde la fila del DataGridView
                Dim transportista As String = row.Cells("Transportista").Value.ToString()
                Dim estadoBueno As Integer = If(String.IsNullOrEmpty(row.Cells("CantBuenEstado").Value.ToString()), 0, CInt(row.Cells("CantBuenEstado").Value))
                Dim estadoMalo As Integer = If(String.IsNullOrEmpty(row.Cells("CantMalEstado").Value.ToString()), 0, CInt(row.Cells("CantMalEstado").Value))
                Dim estadoVale As Integer = If(String.IsNullOrEmpty(row.Cells("CantVale").Value.ToString()), 0, CInt(row.Cells("CantVale").Value))
                Dim observacion As String = row.Cells("Observación").Value.ToString()
                Dim nroParteSalida As Integer = row.Cells("NroParteSalida").Value
                Dim exito As Boolean = ModuloFunciones.RegistrarDevolucionCliente(fechaSeleccionada, clienteCod, transportista, estadoBueno, estadoMalo, estadoVale, codFletero, observacion, nroParteSalida)

                If Not exito Then
                    exitoTotal = False
                    Exit For
                End If
            End If
        Next

        ' Mostrar el mensaje de éxito solo si todas las filas fueron procesadas exitosamente
        If exitoTotal Then
            MsgBox("Regreso por Parte Salida registrado con éxito.", MsgBoxStyle.Information, "Éxito")
            If DeDoneVengo = 2 Or DeDoneVengo = 3 Then
                txtNroParteSalidaDev.Enabled = True
                FrmLogin.Close()
                Me.Close()
                Application.Exit()
            End If
        End If

        limpiarControlesDevolucion()
    End Sub



    Private Sub dgvDevCliente_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDevCliente.CellDoubleClick
        ' Asegurarse de que se haya hecho clic en una celda válida
        If e.RowIndex >= 0 Then
            ' Obtener la fila seleccionada
            selectedRowIndex = e.RowIndex
            Dim selectedRow As DataGridViewRow = dgvDevCliente.Rows(e.RowIndex)

            ' Cargar los datos de la fila en los controles correspondientes
            cboClienteDevolucion.Text = selectedRow.Cells("Cliente").Value.ToString()
            txtCantBuenEstado.Text = selectedRow.Cells("CantBuenEstado").Value.ToString()
            txtCantMalEstado.Text = selectedRow.Cells("CantMalEstado").Value.ToString()
            txtCantVale.Text = selectedRow.Cells("CantVale").Value.ToString()
            txtObservacionDev.Text = selectedRow.Cells("Observación").Value.ToString()
        End If
        txtCantBuenEstado.SelectAll()
    End Sub



    Private Sub txtCantBuenEstado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantBuenEstado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            txtCantMalEstado.Focus()
            txtCantMalEstado.SelectAll()
        End If
    End Sub

    Private Sub txtCantMalEstado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantMalEstado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            txtCantVale.Focus()
            txtCantVale.SelectAll()
        End If
    End Sub


    Private Sub cboClienteDevolucion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboClienteDevolucion.SelectedValueChanged
        If cboClienteDevolucion.SelectedValue IsNot Nothing Then
            txtCantBuenEstado.Focus()
        End If
    End Sub


    Private Sub txtCantVale_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantVale.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtObservacionDev.Focus()
            txtObservacionDev.SelectAll()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub txtObservacionDev_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacionDev.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSigCliente_Click(sender, e)
            dgvClientesDevolucion.Focus()
            txtObservacionDev.Clear()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            txtObservacion.Focus()
        End If
    End Sub
#Region "LOGICA LIMPIEZA CONTROLES"
    Private Sub LimpiarCampos()
        ModuloControles.LimpiarCamposMovPallets(New Control() {cboCliente, cboTransportista, cboTipoPallet, cboTipoMovimiento, swtRetorno, txtCantidad, rbtBuenEstado, txtObservacion})
    End Sub
    Private Sub limpiarDgvParteSalida()
        ModuloControles.LimpiarControles(New Control() {txtOrdenEntrega, txtCodCliente, txtRazonSocial, txtCantidadPallets, txtPosicionPalletDesde,
                                         txtPosicionPalletHasta, txtPalletsInsertados, txtNroParteSalida, dgvParteSalida, lblTotalPallets, txtCantTotalPallets,
                                         lblPalletsInsertados, groupTotales, btnRegistrarAsignacion, txtRazonSocial, txtOrdenEntrega, txtCodCliente})
    End Sub

    'LIMPIEZA PARCIAL AL REGISTRAR UN CLIENTE EN GRILLA DE DEV CLIENTE
    Private Sub limpiarControlesCargaDev()
        ModuloControles.LimpiarControlesCargaDev(New Control() {txtCantBuenEstado, txtCantMalEstado, txtCantVale, cboClienteDevolucion, txtObservacionDev})
    End Sub

    'LIMPIEZA COMPLETA AL REGISTRAR DEV CLIENTE
    Private Sub limpiarControlesDevolucion()
        ModuloControles.LimpiarControlesDevCliente(New Control() {txtNroParteSalidaDev, txtCantBuenEstado, txtCantMalEstado, txtCantVale, cboClienteDevolucion, dgvDevCliente, dgvClientesDevolucion, cboTransportistaDev, cboTransportistaDev, txtObservacionDev})
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea limpiar los campos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            LimpiarCampos()
            cboCliente.SelectedIndex = -1
            cboTransportista.SelectedIndex = -1
            cboTipoPallet.SelectedIndex = 2
        End If
    End Sub

    Private Sub btnLimpiarDevCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarDevCliente.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea limpiar los campos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            limpiarControlesDevolucion()
        End If
    End Sub

    Private Sub btnLimpiarSeleccion_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarSeleccion.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea limpiar las selecciones ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            LimpiarRecargarGrillaReporte()
        End If
    End Sub

    Private Sub LimpiarRecargarGrillaReporte()
        ' Crear una lista de los controles a limpiar
        Dim controles As New List(Of Control) From {
            cboTipoMovReporte,
            cboTipoPalletReporte,
            cboClienteReporte,
            cboTraReporte,
            rbtBuenoRep,
            rbtMaloRep,
            rbtValeRep,
            swtRetornoRep
        }
        lblDescripcion.Visible = True
        ModuloControles.LimpiarSeleccion(controles, dgvReporte)
    End Sub

    Private Sub LimpiarRecargarGrillaInforme()
        ' Crear una lista de los controles a limpiar
        Dim controles As New List(Of Control) From {
            cboClienteInforme,
            cboTransportistaInforme
        }
        lblDescripcionInforme.Visible = True
        ModuloControles.LimpiarSeleccionInforme(controles, dgvInformeSaldos)
    End Sub
#End Region


#Region "TAB CONTROL"

    Private Sub tabControlInicio(sender As Object, e As TabControlCancelEventArgs) Handles tabControl.Selecting
        If (tabControl.SelectedIndex = 0) Then
            Me.BeginInvoke(Sub() dtpFecha.Focus())
            Me.Text = "Gestión de Pallets"
        End If
    End Sub

    Private Sub tabControlMovimiento(sender As Object, e As TabControlCancelEventArgs) Handles tabControl.Selecting
        If (tabControl.SelectedIndex = 1) Then
            Me.BeginInvoke(Sub() dtpFecha.Focus())
            Me.Text = "Carga de Movimientos Pallets"
        End If
    End Sub

    Private Sub tabControlAsignacion(sender As Object, e As TabControlCancelEventArgs) Handles tabControl.Selecting
        If (tabControl.SelectedIndex = 2) Then
            Me.BeginInvoke(Sub() txtNroParteSalida.Focus())
            Me.Text = "Egreso Pallets por Cliente"
        End If
    End Sub

    Private Sub tabControlDevCliente(sender As Object, e As TabControlCancelEventArgs) Handles tabControl.Selecting
        If (tabControl.SelectedIndex = 3) Then
            Me.BeginInvoke(Sub() txtNroParteSalidaDev.Focus())
            Me.Text = "Regreso Parte Salida"
        End If
    End Sub

    Private Sub tabControlRepMov(sender As Object, e As TabControlCancelEventArgs) Handles tabControl.Selecting
        If (tabControl.SelectedIndex = 4) Then
            Me.BeginInvoke(Sub() txtNroParteSalidaDev.Focus())
            Me.Text = "Reporte Movimientos Pallets"
        End If
    End Sub

    Private Sub tabControlInfSaldos(sender As Object, e As TabControlCancelEventArgs) Handles tabControl.Selecting
        If (tabControl.SelectedIndex = 5) Then
            Me.BeginInvoke(Sub() txtNroParteSalidaDev.Focus())
            Me.Text = "Informe Saldos Pallets"
        End If
    End Sub
    Private Sub tabControlSalir(sender As Object, e As TabControlCancelEventArgs) Handles tabControl.Selecting
        If (tabControl.SelectedIndex = 6) Then
            Application.Exit()
        End If
    End Sub


    Private Sub tabControl_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabControl.Selecting
        If DeDoneVengo = 1 And e.TabPageIndex <> 2 Then
            e.Cancel = True ' Cancela el cambio de pestaña para evitar que el usuario navegue por los tabs cuando viene de vb6
        ElseIf DeDoneVengo = 2 Or DeDoneVengo = 3 And e.TabPageIndex <> 3 Then
            e.Cancel = True
        End If
    End Sub
#End Region

    Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnRegistrar_Click(sender, e)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtNroParteSalida_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroParteSalida.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBuscar_Click(sender, e)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnTraReporte_Click(sender As Object, e As EventArgs) Handles btnTraReporte.Click
        cboTraReporte.SelectedIndex = -1
        Dim frmBuscarTraReporte As New FrmBuscarTransportista(Me)
        frmBuscarTraReporte.cargarModo = TransportistaCargarModo.Reportes
        frmBuscarTraReporte.ShowDialog(Me)
    End Sub


    ' Método para obtener el estado seleccionado de los radio buttons
    Private Function GetSelectedRadioButton() As String
        If rbtBuenoRep.Checked Then
            Return "Buen Estado"
        ElseIf rbtMaloRep.Checked Then
            Return "Mal Estado"
        ElseIf rbtValeRep.Checked Then
            Return "Vale"
        Else
            Return String.Empty
        End If
    End Function

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        ' Obtener los valores seleccionados de los filtros
        Dim fechaDesde As Date = dtpFechaDesde.Value.Date
        Dim fechaHasta As Date = dtpFechaHasta.Value.Date
        Dim tipoMov As Integer? = If(cboTipoMovReporte.SelectedValue Is Nothing, CType(Nothing, Integer?), cboTipoMovReporte.SelectedValue)
        Dim tipoPallet As Long? = If(cboTipoPalletReporte.SelectedValue Is Nothing, CType(Nothing, Long?), cboTipoPalletReporte.SelectedValue)
        Dim cliente As Integer? = If(cboClienteReporte.SelectedValue Is Nothing, CType(Nothing, Integer?), cboClienteReporte.SelectedValue)
        Dim transportista As Short? = If(cboTraReporte.SelectedValue Is Nothing, CType(Nothing, Short?), cboTraReporte.SelectedValue)

        ' Asignar estado según el radio button seleccionado o Nothing si ninguno está seleccionado
        Dim estado As Integer? = If(rbtBuenoRep.Checked, 1, If(rbtMaloRep.Checked, 2, If(rbtValeRep.Checked, 3, CType(Nothing, Integer?))))

        ' Si estado es Nothing, usar una lista de todos los estados (1, 2, 3)
        If estado Is Nothing Then
            estado = -1
        End If

        Dim retorno As Integer = If(swtRetornoRep.Checked, 1, 0)

        lblDescripcion.Visible = False

        Dim dgvLoader As New DataGridLoader(dgvReporte)
        dgvLoader.CargarDatosEnGrillaReporte(controllerReportes, fechaDesde, fechaHasta, tipoMov, tipoPallet, cliente, transportista, estado, retorno)
    End Sub





    Private Sub txtFiltroReporte_TextChanged(sender As Object, e As EventArgs) Handles txtFiltroReporte.TextChanged
        Dim busqueda As String = txtFiltroReporte.Text
        controllerReportes.filtrarDgvReporte(busqueda, dgvReporte.DataSource)
    End Sub

    Private Sub btnBuscarCliInforme_Click(sender As Object, e As EventArgs) Handles btnBuscarCliInforme.Click
        cboClienteInforme.SelectedIndex = -1
        Dim frmBuscarCliInforme As New FrmBuscarCliente(Me)
        frmBuscarCliInforme.cargarModo = ClienteCargarModo.Informes
        frmBuscarCliInforme.ShowDialog(Me)
    End Sub

    Private Sub btnTraInforme_Click(sender As Object, e As EventArgs) Handles btnTraInforme.Click
        cboTransportistaInforme.SelectedIndex = -1
        Dim frmBuscarTraInforme As New FrmBuscarTransportista(Me)
        frmBuscarTraInforme.cargarModo = TransportistaCargarModo.Informes
        frmBuscarTraInforme.ShowDialog(Me)
    End Sub

    Private Sub btnLimpiarInforme_Click(sender As Object, e As EventArgs) Handles btnLimpiarInforme.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea limpiar las selecciones ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            LimpiarRecargarGrillaInforme()
        End If

    End Sub

    Private Sub txtBuscarInforme_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrarInforme.TextChanged
        Dim busqueda As String = txtFiltrarInforme.Text

        If String.IsNullOrEmpty(busqueda) Then
            dgvInformeSaldos.DataSource = controllerInforme.ObtenerDatosInformeSaldosInicial()
        Else
            controllerInforme.filtrarDgvInforme(busqueda, dgvInformeSaldos.DataSource)
        End If
    End Sub

    Private Sub btnBuscarInforme_Click(sender As Object, e As EventArgs) Handles btnBuscarInforme.Click
        ' Obtener los valores seleccionados de los filtros
        Dim fechaDesde As Date = dtpFechaDesdeSaldo.Value.Date
        Dim fechaHasta As Date = dtpFechaHastaSaldo.Value.Date
        Dim cliente As Integer? = If(cboClienteInforme.SelectedValue Is Nothing, CType(Nothing, Integer?), cboClienteInforme.SelectedValue)
        Dim transportista As Short? = If(cboTransportistaInforme.SelectedValue Is Nothing, CType(Nothing, Short?), cboTransportistaInforme.SelectedValue)



        lblDescripcionInforme.Visible = False

        Dim dgvLoader As New DataGridLoader(dgvInformeSaldos)
        dgvLoader.CargarDatosEnGrillaInforme(controllerInforme, fechaDesde, fechaHasta, cliente, transportista)
    End Sub

    Private Sub dgvClientesDevolucion_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvClientesDevolucion.KeyDown
        ' Verificar si la tecla Enter fue presionada
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True

            ' Verificar si hay una fila seleccionada
            If dgvClientesDevolucion.CurrentRow IsNot Nothing AndAlso dgvClientesDevolucion.CurrentRow.Cells("Cliente").Value IsNot Nothing Then
                Try
                    Dim selectedRow As DataGridViewRow = dgvClientesDevolucion.CurrentRow
                    Dim cliente As String = selectedRow.Cells("Cliente").Value.ToString()
                    Dim codCliente As String = cliente.Split("-"c)(0).Trim()
                    cboClienteDevolucion.SelectedValue = codCliente
                Catch ex As Exception
                    MessageBox.Show("Error al procesar la fila seleccionada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub dgvClientesDevolucion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientesDevolucion.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso dgvClientesDevolucion.Rows(e.RowIndex).Cells("Cliente").Value IsNot Nothing Then
            Try
                Dim selectedRow As DataGridViewRow = dgvClientesDevolucion.Rows(e.RowIndex)
                Dim cliente As String = selectedRow.Cells("Cliente").Value.ToString()
                Dim codCliente As String = cliente.Split("-"c)(0).Trim()
                cboClienteDevolucion.SelectedValue = codCliente
            Catch ex As Exception
                MessageBox.Show("Error al procesar la celda seleccionada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub FrmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If DeDoneVengo > 0 Then
            FrmLogin.Close()
            Application.Exit()
        End If
    End Sub

End Class
