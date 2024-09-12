Imports Guna.UI2.WinForms
Imports MaterialSkin.Controls

Public Class DataGridLoader
    Private _dgv As DataGridView
    Private _txtCantidadPallets As MaterialTextBox
    Private _txtPosicionPalletDesde As MaterialTextBox
    Private _txtPosicionPalletHasta As MaterialTextBox
    Private _txtOrdenEntrega As MaterialTextBox2
    Private _txtCodCliente As MaterialTextBox2
    Private _txtRazonSocial As MaterialTextBox2
    Private _txtNroParteSalida As MaterialTextBox
    Private _txtPalletsInsertados As MaterialTextBox
    Private _lblTotalPallets As Label
    Private _txtCantTotalPallets As MaterialTextBox
    Private _lblPalletsInsertados As Label
    Private _groupTotales As Guna2GroupBox
    Public Sub New(dgv As DataGridView, Optional txtCantidadPallets As MaterialTextBox = Nothing,
                   Optional txtPosicionPalletDesde As MaterialTextBox = Nothing, Optional txtPosicionPalletHasta As MaterialTextBox = Nothing,
                   Optional txtOrdenEntrega As MaterialTextBox2 = Nothing, Optional txtCodCliente As MaterialTextBox2 = Nothing,
                   Optional txtRazonSocial As MaterialTextBox2 = Nothing, Optional txtNroParteSalida As MaterialTextBox = Nothing,
                   Optional txtPalletsInsertados As MaterialTextBox = Nothing, Optional lblTotalPallets As Label = Nothing,
                   Optional txtCantTotalPallets As MaterialTextBox = Nothing, Optional lblPalletsInsertados As Label = Nothing,
                   Optional groupTotales As Guna2GroupBox = Nothing)
        _dgv = dgv
        _txtCantidadPallets = txtCantidadPallets
        _txtPosicionPalletDesde = txtPosicionPalletDesde
        _txtPosicionPalletHasta = txtPosicionPalletHasta
        _txtOrdenEntrega = txtOrdenEntrega
        _txtCodCliente = txtCodCliente
        _txtRazonSocial = txtRazonSocial
        _txtNroParteSalida = txtNroParteSalida
        _txtPalletsInsertados = txtPalletsInsertados
        _lblTotalPallets = lblTotalPallets
        _txtCantTotalPallets = txtCantTotalPallets
        _lblPalletsInsertados = lblPalletsInsertados
        _groupTotales = groupTotales
    End Sub
    Public Sub ConfigurarDataGridView(tabla As DataTable)
        If tabla IsNot Nothing Then
            _dgv.DataSource = tabla
            _dgv.ReadOnly = True
            _dgv.AllowUserToResizeRows = False
            _dgv.ColumnHeadersHeight = 30
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            ' Ocultar la columna NroParteSalida
            If _dgv.Columns.Contains("NroParteSalida") Then
                _dgv.Columns("NroParteSalida").Visible = False
            End If

            ' Ocultar la columna CodFletero
            If _dgv.Columns.Contains("CodFletero") Then
                _dgv.Columns("CodFletero").Visible = False
            End If

            ' Establecer el ancho de la columna NroEntrega
            If _dgv.Columns.Contains("NroEntrega") Then
                _dgv.Columns("NroEntrega").Width = 60
                _dgv.Columns("NroEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            ' Establecer el ancho de la columna CodCliente
            If _dgv.Columns.Contains("CodCliente") Then
                _dgv.Columns("CodCliente").Visible = False
            End If

            ' Establecer el ancho de la columna RazonSocial
            If _dgv.Columns.Contains("Cliente") Then
                _dgv.Columns("Cliente").Width = 180
            End If

            ' Agregar columna CantidadPallets si no existe
            If Not _dgv.Columns.Contains("CantidadPallets") Then
                Dim colCantidadPallets As New DataGridViewTextBoxColumn
                colCantidadPallets.Name = "CantidadPallets"
                colCantidadPallets.HeaderText = "Cantidad de Pallets"
                colCantidadPallets.Width = 80
                _dgv.Columns.Add(colCantidadPallets)
            Else
                _dgv.Columns("CantidadPallets").Width = 80
            End If

            ' Agregar columna PosicionPalletCamion si no existe
            If Not _dgv.Columns.Contains("PosicionPalletCamion") Then
                Dim posicionPallet As New DataGridViewTextBoxColumn
                posicionPallet.Name = "PosicionPalletCamion"
                posicionPallet.HeaderText = "Ubicación Pallet en Camión"
                posicionPallet.Width = 100
                _dgv.Columns.Add(posicionPallet)
            Else
                _dgv.Columns("PosicionPalletCamion").Width = 80
            End If

            ' Agregar columna CodFletero si no existe (pero la ocultamos)
            If Not _dgv.Columns.Contains("CodFletero") Then
                Dim codFleteroCol As New DataGridViewTextBoxColumn
                codFleteroCol.Name = "CodFletero"
                codFleteroCol.HeaderText = "CodFletero"
                codFleteroCol.Visible = False ' Columna oculta
                _dgv.Columns.Add(codFleteroCol)
            End If

        Else
            _dgv.DataSource = Nothing
        End If
    End Sub



    Public Function ValidarPosiciones(posicionDesde As Integer, posicionHasta As Integer, Optional filaEditar As DataGridViewRow = Nothing) As Boolean
        ' Validar que las posiciones estén dentro del rango permitido
        If posicionDesde < 1 OrElse posicionHasta > 30 OrElse posicionDesde > posicionHasta Then
            Return False
        End If

        ' Iterar sobre el rango solicitado
        For i As Integer = posicionDesde To posicionHasta
            ' Verificar si alguna fila del DataGridView contiene el rango de posiciones que se solapan con el solicitado
            For Each row As DataGridViewRow In _dgv.Rows
                ' Ignorar la fila que se está editando
                If row IsNot filaEditar AndAlso Not row.IsNewRow Then
                    Dim posicionPallet As Object = row.Cells("PosicionPalletCamion").Value
                    If posicionPallet IsNot Nothing AndAlso Not IsDBNull(posicionPallet) Then
                        Dim partes() As String = posicionPallet.ToString().Split(New String() {" a "}, StringSplitOptions.None)
                        If partes.Length = 2 Then
                            Dim rangoDesde As Integer
                            Dim rangoHasta As Integer
                            If Integer.TryParse(partes(0).Trim(), rangoDesde) AndAlso Integer.TryParse(partes(1).Trim(), rangoHasta) Then
                                ' Verificar si el rango solicitado se solapa con el rango ya existente
                                If (posicionDesde <= rangoHasta AndAlso posicionHasta >= rangoDesde) Then
                                    Return False
                                End If
                            End If
                        Else
                            ' Verificar si la posición solicitada se encuentra en un rango individual
                            Dim posiciones() As String = posicionPallet.ToString().Split(","c)
                            For Each pos In posiciones
                                If CInt(pos.Trim()) = i Then
                                    Return False
                                End If
                            Next
                        End If
                    End If
                End If
            Next
        Next

        Return True
    End Function


    Public Sub InsertarAsignacion()
        Dim posicionDesde As Integer
        Dim posicionHasta As Integer

        ' Valida las posiciones de pallet
        Dim posicionValidaDesde As Boolean = Integer.TryParse(_txtPosicionPalletDesde.Text, posicionDesde)
        Dim posicionValidaHasta As Boolean = Integer.TryParse(_txtPosicionPalletHasta.Text, posicionHasta)

        If Not posicionValidaDesde OrElse Not posicionValidaHasta OrElse Not ValidarPosiciones(posicionDesde, posicionHasta, _dgv.CurrentRow) Then
            MsgBox("Verifique el rango de posiciones (1-30) y asegúrese de que no estén en uso.", MsgBoxStyle.Exclamation, "Advertencia")
            _txtPosicionPalletDesde.Focus()
            _txtPosicionPalletDesde.SelectAll()
            Return
        End If

        ' Calcula la cantidad de posiciones seleccionadas
        Dim cantidadPosiciones As Integer = posicionHasta - posicionDesde + 1

        ' Verifica que la cantidad de pallets sea suficiente
        Dim cantidadPallets As Integer
        If Not Integer.TryParse(_txtCantidadPallets.Text, cantidadPallets) OrElse cantidadPallets < cantidadPosiciones Then
            MsgBox($"La cantidad de pallets ({cantidadPallets}) no puede ser menor que la cantidad de posiciones ({cantidadPosiciones}).", MsgBoxStyle.Exclamation, "Advertencia")
            _txtCantidadPallets.Focus()
            _txtCantidadPallets.SelectAll()
            Return
        End If

        ' Inserta la asignación en la grilla
        If _dgv.CurrentRow IsNot Nothing Then
            Dim posiciones As String = $"{posicionDesde} a {posicionHasta}"
            _dgv.CurrentRow.Cells("CantidadPallets").Value = _txtCantidadPallets.Text
            _dgv.CurrentRow.Cells("PosicionPalletCamion").Value = posiciones

            ' Limpia los campos de entrada
            _txtCantidadPallets.Clear()
            _txtOrdenEntrega.Clear()
            _txtCodCliente.Clear()
            _txtRazonSocial.Clear()
            _txtPosicionPalletDesde.Clear()
            _txtPosicionPalletHasta.Clear()
        End If

        ' Mueve el foco a la grilla y luego a la siguiente fila
        _dgv.Focus()
        MoverFocoASiguienteFila(_dgv)
    End Sub




    Private Sub MoverFocoASiguienteFila(dgv As DataGridView)
        Dim currentIndex As Integer = dgv.CurrentCell.RowIndex
        Dim nextIndex As Integer = currentIndex + 1

        If nextIndex < dgv.Rows.Count Then
            dgv.CurrentCell = dgv.Rows(nextIndex).Cells(0)
            dgv.BeginEdit(True)
        End If
    End Sub

    Public Sub InicializarGrillaClientes(ByRef dgvClientes As DataGridView)
        With dgvClientes
            .ColumnHeadersHeight = 25
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
        End With
    End Sub
    Public Sub InicializarGrillaTransportistas(ByRef dgvTransportistas As DataGridView)
        With dgvTransportistas
            .ColumnHeadersHeight = 25
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
        End With
    End Sub


    Public Sub InicializarGrillaMovimientos(ByRef dgvMovPallets As DataGridView)
        With dgvMovPallets
            .ColumnHeadersHeight = 28
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            .DefaultCellStyle.Font = New Font("Arial", 8)
            .Columns.Clear()
        End With
    End Sub



    Public Sub CargarDatosEnGrilla(controller As ControllerPallets)
        Dim dtMovimientos As DataTable = controller.cargarGrillaMovimientosPallets()

        If dtMovimientos IsNot Nothing AndAlso dtMovimientos.Rows.Count > 0 Then
            _dgv.DataSource = dtMovimientos

            With _dgv
                .Columns("id").Width = 60
                .Columns("FechaCarga").Width = 128
                .Columns("Tipo de Movimiento").Width = 110
                .Columns("Transportista").Width = 200
                .Columns("Cantidad").Width = 87
                .Columns("Cliente").Width = 200
                .Columns("Observacion").Width = 110
                .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Transportista").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Cliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With
        Else
            'MessageBox.Show("No se encontraron datos para mostrar.")
            _dgv.DataSource = Nothing
        End If
    End Sub
    Public Sub InicializarGrillaDevolucionCliente(ByRef dgv As DataGridView)
        With dgv
            .ColumnHeadersHeight = 30
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()

            Dim colFechaDev As New DataGridViewTextBoxColumn() With {
                .Name = "Fecha Devolución",
                .HeaderText = "Fecha Devolución",
                .Width = 80
            }
            Dim colFechaCargaDev As New DataGridViewTextBoxColumn() With {
                .Name = "Fecha de Carga",
                .HeaderText = "Fecha Carga",
                .Width = 80
            }

            Dim colTransportista As New DataGridViewTextBoxColumn() With {
                .Name = "Transportista",
                .HeaderText = "Transportista",
                .Width = 120
            }

            Dim colCliente As New DataGridViewTextBoxColumn() With {
                .Name = "Cliente",
                .HeaderText = "Cliente",
                .Width = 100
            }
            Dim colCantBuenEstado As New DataGridViewTextBoxColumn() With {
                .Name = "CantBuenEstado",
                .HeaderText = "Cant.BuenEstado",
                .Width = 40
            }
            colCantBuenEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim colCantMalEstado As New DataGridViewTextBoxColumn() With {
                .Name = "CantMalEstado",
                .HeaderText = "Cant.MalEstado",
                .Width = 40
            }
            colCantMalEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim colCantVale As New DataGridViewTextBoxColumn() With {
                .Name = "CantVale",
                .HeaderText = "Cant.Vale",
                .Width = 40
            }
            colCantVale.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim colObservacion As New DataGridViewTextBoxColumn() With {
                .Name = "Observación",
                .HeaderText = "Observación",
                .Width = 40
            }

            .Columns.AddRange(New DataGridViewColumn() {colFechaDev, colFechaCargaDev, colTransportista, colCliente, colCantBuenEstado, colCantMalEstado, colCantVale, colObservacion})
        End With
    End Sub

    Private Sub ConfigurarColumnasDataGridViewReporte(dgv As DataGridView)
        With dgv
            .ColumnHeadersHeight = 30
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None

            .Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Fecha").Width = 70

            .Columns("Tipo de Movimiento").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Tipo de Movimiento").Width = 120

            .Columns("Cliente").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Cliente").Width = 200
            .Columns("Cliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            .Columns("Transportista").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Transportista").Width = 200
            .Columns("Transportista").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            .Columns("Tipo de Pallet").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Tipo de Pallet").Width = 200

            .Columns("Estado").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Estado").Width = 100

            .Columns("Cantidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Cantidad").Width = 60
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    Public Sub CargarDatosEnGrillaReporte(controller As ControllerReportes, fechaDesde As DateTime, fechaHasta As DateTime, tipoMov As Integer?, tipoPallet As Long?, cliente As Integer?, transportista As Short?, estado As Integer, retorno As Integer)
        Dim dtReporte As DataTable = controller.ObtenerDatosReporte(fechaDesde, fechaHasta, tipoMov, tipoPallet, cliente, transportista, estado, retorno)

        If dtReporte IsNot Nothing AndAlso dtReporte.Rows.Count > 0 Then
            _dgv.DataSource = dtReporte
            ConfigurarColumnasDataGridViewReporte(_dgv)
        Else
            _dgv.DataSource = Nothing
        End If
    End Sub

    Public Sub CargarDatosEnGrillaReporteInicial(controller As ControllerReportes)
        Dim dtReporteInicial As DataTable = controller.ObtenerDatosReporteInicial()

        If dtReporteInicial IsNot Nothing AndAlso dtReporteInicial.Rows.Count > 0 Then
            _dgv.DataSource = dtReporteInicial
            ConfigurarColumnasDataGridViewReporte(_dgv)
        Else
            _dgv.DataSource = Nothing
        End If
    End Sub

    Private Sub ConfigurarColumnasDataGridView(dgv As DataGridView)
        With dgv
            .ColumnHeadersHeight = 30
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Bold)
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None

            .Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Fecha").Width = 70

            .Columns("Cliente").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Cliente").Width = 200
            .Columns("Cliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            .Columns("Transportista").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Transportista").Width = 200
            .Columns("Transportista").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            .Columns("Tipo de Pallet").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Tipo de Pallet").Width = 70
            .Columns("Tipo de Pallet").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("T.Ing Bueno").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("T.Ing Bueno").Width = 70
            .Columns("T.Ing Bueno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("T.Ing Malo").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("T.Ing Malo").Width = 70
            .Columns("T.Ing Malo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("T.Ing Vale").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("T.Ing Vale").Width = 70
            .Columns("T.Ing Vale").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("T.Egresos PS").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("T.Egresos PS").Width = 70
            .Columns("T.Egresos PS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("T.Ing Dev Cte").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("T.Ing Dev Cte").Width = 70
            .Columns("T.Ing Dev Cte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Saldo Pallets").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns("Saldo Pallets").Width = 70
            .Columns("Saldo Pallets").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    Public Sub CargarDatosEnGrillaInformeSaldosInicial(controller As ControllerInformes)
        Dim dtInformeInicial As DataTable = controller.ObtenerDatosInformeSaldosInicial()

        If dtInformeInicial IsNot Nothing AndAlso dtInformeInicial.Rows.Count > 0 Then
            _dgv.DataSource = dtInformeInicial
            ConfigurarColumnasDataGridView(_dgv)
        Else
            _dgv.DataSource = Nothing
        End If
    End Sub

    Public Sub CargarDatosEnGrillaInforme(controller As ControllerInformes, fechaDesde As DateTime, fechaHasta As DateTime, cliente As Integer?, transportista As Short?)
        Dim dtInformeInicial As DataTable = controller.ObtenerDatosInforme(fechaDesde, fechaHasta, cliente, transportista)

        If dtInformeInicial IsNot Nothing AndAlso dtInformeInicial.Rows.Count > 0 Then
            _dgv.DataSource = dtInformeInicial
            ConfigurarColumnasDataGridView(_dgv)
        Else

            _dgv.DataSource = Nothing
        End If
    End Sub
    Public Sub InicializarGrillaClientesDevolucion(ByRef dgvClientesDevolucion As DataGridView)
        With dgvClientesDevolucion
            .ColumnHeadersHeight = 25
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()
            ' Definir las columnas que se mostrarán en la grilla
            .Columns.Add("Cliente", "Clientes")
        End With
    End Sub


    Public Sub CargarClientesEnGrilla(clientes As DataTable)
        _dgv.Rows.Clear()

        For Each row As DataRow In clientes.Rows
            _dgv.Rows.Add(row("Cliente"))
        Next
    End Sub

End Class
