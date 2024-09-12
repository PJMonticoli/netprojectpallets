Imports System.Windows.Input
Imports FluentValidation.Results
Imports Guna.UI2.WinForms
Imports MaterialSkin.Controls

Module ModuloFunciones
    Dim controller As New ControllerPallets()

#Region "Funciones Form Carga Movimiento Pallets"
    Public Function RegistrarMovimientoPallet(
    fecha As Date,
    fechaCarga As DateTime,
    retorno As Boolean,
    tipoPallet As Long?,
    tipoMovimientoId As Long?,
    clienteId As Integer?,
    transportistaId As Long?,
    cantidad As Integer,
    observacion As String,
    estadoDevolucionId As Integer
) As Boolean

        ' Crear el objeto PalletModel
        Dim pallet As New PalletModel() With {
        .Fecha = fecha,
        .FechaCarga = fechaCarga,
        .Retorna = retorno,
        .TipoPallet = tipoPallet,
        .CodCliente = clienteId,
        .CodFletero = transportistaId,
        .Cantidad = cantidad,
        .Observacion = observacion,
        .TipoMovimientoId = tipoMovimientoId,
        .EstadoDevolucionId = estadoDevolucionId
    }

        ' Validar el objeto pallet
        Dim validator As New PalletValidator()
        Dim validationResult As ValidationResult = validator.Validate(pallet)

        If Not validationResult.IsValid Then
            For Each validationError As ValidationFailure In validationResult.Errors
                MsgBox($"Error en {validationError.PropertyName}: {validationError.ErrorMessage}", MsgBoxStyle.Exclamation, "Error de Validación")
            Next
            Return False
        End If

        ' Si la validación pasa, se procede a insertar el pallet
        Dim insertarResultado As Boolean = controller.InsertarPallet(pallet)

        If insertarResultado Then
            MsgBox("Movimiento pallet registrado con éxito.", MsgBoxStyle.Information, "Éxito")
            Return True
        Else
            MsgBox("Error al registrar el Movimiento de pallet.", MsgBoxStyle.Critical, "Error")
            Return False
        End If
    End Function


#End Region



#Region "Funciones Pallets Por Cliente"
    Public Function BuscarParteSalida(
     nroParteSalida As Integer,
     ByRef totalPallets As Integer,
     ByRef tabla As DataTable
 ) As Boolean
        ' Obtener los datos de la parte de salida
        tabla = controller.cargarGrillaParteSalida(nroParteSalida)

        If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
            totalPallets = controller.ObtenerTotalPalletsEsperados(nroParteSalida)
            Return True
        Else
            totalPallets = 0
            Return False
        End If
    End Function



    Public Function RegistrarAsignaciones(
    totalPalletsEsperados As Integer,
    dgvParteSalida As DataGridView,
    controller As ControllerPallets ' Reemplaza con el tipo correcto de tu controlador
) As Boolean
        ' Calcular la suma de CantidadPallets en dgvParteSalida
        Dim sumaCantidadPallets As Integer = 0
        For Each row As DataGridViewRow In dgvParteSalida.Rows
            If Not row.IsNewRow Then
                Dim cantidadPallets As Integer
                If Integer.TryParse(Convert.ToString(row.Cells("CantidadPallets").Value), cantidadPallets) Then
                    sumaCantidadPallets += cantidadPallets
                End If
            End If
        Next

        ' Comparar la suma con el total esperado
        If sumaCantidadPallets <> totalPalletsEsperados Then
            MessageBox.Show("La suma de los pallets asignados no coincide con la Cant Total Pallets del Parte Salida. Por favor, verifique y ajuste las asignaciones.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Registrar las asignaciones si todo está correcto
        For Each row As DataGridViewRow In dgvParteSalida.Rows
            If Not row.IsNewRow Then
                Dim asignacionPallet As New PalletCliente() With {
                .NroParteSalida = Convert.ToInt32(row.Cells("NroParteSalida").Value),
                .NroOEntrega = Convert.ToInt32(row.Cells("NroEntrega").Value),
                .CodFletero = Convert.ToInt32(row.Cells("CodFletero").Value),  ' Agregado
                .CodCliente = Convert.ToInt32(row.Cells("CodCliente").Value),  ' Agregado
                .CantidadPallets = Convert.ToInt32(row.Cells("CantidadPallets").Value),
                .PosicionEnCamion = Convert.ToString(row.Cells("PosicionPalletCamion").Value)
            }

                Dim success As Boolean = controller.insertarAsignacion(asignacionPallet)

                If Not success Then
                    MessageBox.Show("Se produjo un error al registrar una de las asignaciones. La operación se ha detenido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If
        Next

        MessageBox.Show("Todas las asignaciones de pallets se han registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
    End Function



    Public Sub InsertarAsignacion(dgvLoader As DataGridLoader, dgvParteSalida As Guna2DataGridView, txtPalletsInsertados As Guna2TextBox)
        ' Llamar al método InsertarAsignacion del DataGridViewLoader
        dgvLoader.InsertarAsignacion()

        ' Actualizar la suma de pallets
        ActualizarSumaPallets(dgvParteSalida, txtPalletsInsertados)
    End Sub


    Private Sub ActualizarSumaPallets(dgvParteSalida As Guna2DataGridView, txtPalletsInsertados As Guna2TextBox)
        Dim sumaCantidadPallets As Integer = 0

        ' Iterar sobre las filas del DataGridView
        For Each row As DataGridViewRow In dgvParteSalida.Rows
            If Not row.IsNewRow Then
                Dim cantidadPallets As Integer
                ' Intentar convertir el valor de la celda a Integer
                If Integer.TryParse(Convert.ToString(row.Cells("CantidadPallets").Value), cantidadPallets) Then
                    sumaCantidadPallets += cantidadPallets
                End If
            End If
        Next

        ' Mostrar la suma en el txtPalletsInsertados
        txtPalletsInsertados.Text = sumaCantidadPallets.ToString()
    End Sub
#End Region



#Region "Funciones Form Carga Dev Cliente"


    Public Function RegistrarDevolucionCliente(
    fecha As DateTime,
    clienteId As Integer,
    transportista As String,
    estadoBueno As Integer,
    estadoMalo As Integer,
    estadoVale As Integer,
    codFletero As Integer,
    observacion As String
) As Boolean
        Dim validator As New DevPalletValidador()

        ' Asegurarse de que las cantidades no sean nulas o vacías y asignar 0 si es necesario
        Dim cantidadBueno As Integer = If(estadoBueno > 0, estadoBueno, 0)
        Dim cantidadMalo As Integer = If(estadoMalo > 0, estadoMalo, 0)
        Dim cantidadVale As Integer = If(estadoVale > 0, estadoVale, 0)

        ' Validar y registrar pallets en buen estado
        If cantidadBueno > 0 Then
            Dim palletBueno As New PalletModel() With {
            .Fecha = fecha,
            .CodFletero = codFletero,
            .CodCliente = clienteId,
            .Cantidad = cantidadBueno,
            .EstadoDevolucionId = 1,
            .TipoPallet = 4010100010001,
            .Observacion = observacion
        }
            Dim validationResult As ValidationResult = validator.Validate(palletBueno)
            If Not validationResult.IsValid Then
                For Each validationError As ValidationFailure In validationResult.Errors
                    MsgBox($"Error en {validationError.PropertyName}: {validationError.ErrorMessage}", MsgBoxStyle.Exclamation, "Error de Validación")
                Next
                Return False
            End If
            controller.InsertarDevolucionPallet(palletBueno)
        End If

        ' Validar y registrar pallets en mal estado
        If cantidadMalo > 0 Then
            Dim palletMalo As New PalletModel() With {
            .Fecha = fecha,
            .CodFletero = codFletero,
            .CodCliente = clienteId,
            .Cantidad = cantidadMalo,
            .EstadoDevolucionId = 2,
            .TipoPallet = 4010100010001,
            .Observacion = observacion
        }
            Dim validationResult As ValidationResult = validator.Validate(palletMalo)
            If Not validationResult.IsValid Then
                For Each validationError As ValidationFailure In validationResult.Errors
                    MsgBox($"Error en {validationError.PropertyName}: {validationError.ErrorMessage}", MsgBoxStyle.Exclamation, "Error de Validación")
                Next
                Return False
            End If
            controller.InsertarDevolucionPallet(palletMalo)
        End If

        ' Validar y registrar pallets con vale
        If cantidadVale > 0 Then
            Dim palletVale As New PalletModel() With {
            .Fecha = fecha,
            .CodFletero = codFletero,
            .CodCliente = clienteId,
            .Cantidad = cantidadVale,
            .EstadoDevolucionId = 3,
            .TipoPallet = 4010100010001,
            .Observacion = observacion
        }
            Dim validationResult As ValidationResult = validator.Validate(palletVale)
            If Not validationResult.IsValid Then
                For Each validationError As ValidationFailure In validationResult.Errors
                    MsgBox($"Error en {validationError.PropertyName}: {validationError.ErrorMessage}", MsgBoxStyle.Exclamation, "Error de Validación")
                Next
                Return False
            End If
            controller.InsertarDevolucionPallet(palletVale)
        End If
        Return True
    End Function

#End Region

End Module
