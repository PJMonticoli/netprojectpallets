Imports System.Data.SqlClient
Imports LiveCharts
Imports LiveCharts.Wpf
Imports FluentValidation.Results
Imports System.Windows.Input

Public Class ControllerPallets
    Inherits ServidorSQL

    Public Function CargarGraficoBarras() As SeriesCollection
        Dim series As New SeriesCollection()

        Try
            Dim tabla As DataTable
            Dim cadenasql = "SELECT TOP 5 
                c.RazonSocial,
                SUM(CASE WHEN TipoMovimientoId = 4 THEN Cantidad ELSE 0 END) AS CantidadIngreso
             FROM Almacen.dbo.Pallets p
             INNER JOIN CtasCtesSQL.dbo.Clientes c ON p.CodCliente = c.CodCliente
             WHERE MONTH(fecha) = MONTH(GETDATE()) 
             AND YEAR(fecha) = YEAR(GETDATE()) AND Retorna = 1 AND EstadoDevolucionId = 3
             GROUP BY c.RazonSocial
             ORDER BY CantidadIngreso DESC"

            tabla = ServidorSQL.GetTabla(cadenasql)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Dim ingresoSeries As New ColumnSeries() With {
                .Title = "Ingresos",
                .Values = New ChartValues(Of Integer)
            }

                ' Inicializar lista para almacenar valores
                Dim nombresClientes As New List(Of String)
                Dim valoresIngreso As New List(Of Integer)

                ' Llenar las listas con datos
                For Each row As DataRow In tabla.Rows
                    nombresClientes.Add(row("RazonSocial").ToString())
                    valoresIngreso.Add(Convert.ToInt32(row("CantidadIngreso")))
                Next

                ' Asignar los valores a la serie
                ingresoSeries.Values = New ChartValues(Of Integer)(valoresIngreso)

                ' Configurar tooltips
                ingresoSeries.LabelPoint = Function(x) $"{nombresClientes(CInt(x.X))} - Ingresos: {x.Y}"

                series.Add(ingresoSeries)
            End If

        Catch ex As Exception
            MsgBox("Error al cargar el gráfico de barras: " & ex.Message)
        End Try

        Return series
    End Function



    Public Function ObtenerEstadoPalletsMesActual() As (SumaBuenEstado As Integer, SumaMalEstado As Integer)
        Dim sumaBuenEstado As Integer = 0
        Dim sumaMalEstado As Integer = 0

        Try
            Dim tabla As DataTable
            Dim cadenasql = "SELECT 
                            ISNULL(SUM(CASE WHEN edp.descripcion = 'Buen Estado' AND p.TipoMovimientoId IN (1,2,3,4) THEN p.Cantidad ELSE 0 END), 0) AS SumaBuenEstado,
                            ISNULL(SUM(CASE WHEN edp.descripcion = 'Mal Estado' AND p.TipoMovimientoId IN (1,2,3,4) THEN p.Cantidad ELSE 0 END), 0) AS SumaMalEstado
                            FROM Almacen.dbo.Pallets p
                            INNER JOIN Almacen.dbo.EstadoDevolucionPallets edp ON p.EstadoDevolucionId = edp.id
                            WHERE MONTH(p.Fecha) = MONTH(GETDATE()) AND YEAR(p.Fecha) = YEAR(GETDATE());"

            tabla = ServidorSQL.GetTabla(cadenasql)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                sumaBuenEstado = Convert.ToInt32(tabla.Rows(0)("SumaBuenEstado"))
                sumaMalEstado = Convert.ToInt32(tabla.Rows(0)("SumaMalEstado"))
            End If

        Catch ex As Exception
            MsgBox("Error al obtener el estado de los pallets: " & ex.Message)
        End Try

        Return (sumaBuenEstado, sumaMalEstado)
    End Function


    Public Function GetSafeInteger(value As Object) As Integer
        If IsDBNull(value) OrElse value Is Nothing Then
            Return 0
        Else
            Return Convert.ToInt32(value)
        End If
    End Function

    Public Function ObtenerCantidadPalletsMesActual() As (sumaIngreso As Integer, sumaEgreso As Integer)
        Dim sumaIngreso As Integer = 0
        Dim sumaEgreso As Integer = 0

        Try
            Dim tabla As DataTable
            Dim cadenasql = "SELECT 
                        SUM(CASE WHEN TipoMovimientoId = 4 THEN Cantidad ELSE 0 END) AS CantidadIngreso, 
                        SUM(CASE WHEN TipoMovimientoId = 3 THEN Cantidad ELSE 0 END) AS CantidadEgreso
                        FROM Almacen.dbo.Pallets p 
                        WHERE MONTH(p.Fecha) = MONTH(GETDATE()) AND YEAR(p.Fecha) = YEAR(GETDATE());"

            tabla = ServidorSQL.GetTabla(cadenasql)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                sumaIngreso = GetSafeInteger(tabla.Rows(0)("CantidadIngreso"))
                sumaEgreso = GetSafeInteger(tabla.Rows(0)("CantidadEgreso"))
            End If

        Catch ex As Exception
            MsgBox("Error al obtener las cantidades de pallets: " & ex.Message)
        End Try

        Return (sumaIngreso, sumaEgreso)
    End Function




    Public Function ObtenerCantidadRetornadosMesActual() As Integer
        Dim cantidadRetornada As Integer = 0

        Try
            Dim tabla As DataTable
            Dim cadenasql = "SELECT 
                             SUM(Cantidad) as CantidadRetornados
                             FROM Almacen.dbo.Pallets p 
                             WHERE Retorna = 1 and TipoMovimientoId = 4 and MONTH(p.Fecha) = MONTH(GETDATE()) AND YEAR(p.Fecha) = YEAR(GETDATE());"

            tabla = ServidorSQL.GetTabla(cadenasql)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                cantidadRetornada = GetSafeInteger(tabla.Rows(0)("CantidadRetornados"))
            End If

        Catch ex As Exception
            MsgBox("Error al obtener la cantidad de pallets retornados: " & ex.Message)
        End Try

        Return cantidadRetornada
    End Function

    Public Function ObtenerCantidadNoRetornadosMesActual() As Integer
        Dim cantidadNoRetornada As Integer = 0

        Try
            Dim tabla As DataTable
            Dim cadenasql = "SELECT 
                             SUM(Cantidad) as CantidadNoRetornados
                             FROM Almacen.dbo.Pallets p
                             WHERE Retorna = 0 and TipoMovimientoId = 3 and MONTH(p.Fecha) = MONTH(GETDATE()) AND YEAR(p.Fecha) = YEAR(GETDATE());"

            tabla = ServidorSQL.GetTabla(cadenasql)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                cantidadNoRetornada = GetSafeInteger(tabla.Rows(0)("CantidadNoRetornados"))
            End If

        Catch ex As Exception
            MsgBox("Error al obtener la cantidad de pallets no retornados: " & ex.Message)
        End Try

        Return cantidadNoRetornada
    End Function



    Public Function CargarGraficoLineasEstado() As SeriesCollection
        Dim series As New SeriesCollection()

        Try
            Dim tabla As DataTable
            Dim cadenasql = "SELECT 
                            MONTH(fecha) AS Mes, 
                            SUM(CASE WHEN TipoMovimientoId = 4 THEN Cantidad ELSE 0 END) AS IngresosDevCliente, 
                            SUM(CASE WHEN TipoMovimientoId = 3 THEN Cantidad ELSE 0 END) AS EgresosParteSalida 
                            FROM Almacen.dbo.Pallets 
                            WHERE YEAR(fecha) = YEAR(GETDATE()) and Retorna = 1
                            GROUP BY MONTH(fecha);
                            "

            tabla = ServidorSQL.GetTabla(cadenasql)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Dim ingresosSeries As New LineSeries() With {
                .Title = "Ingresos Dev Cliente",
                .Values = New ChartValues(Of Integer)
            }

                Dim egresosSeries As New LineSeries() With {
                .Title = "Egresos Parte Salida",
                .Values = New ChartValues(Of Integer)
            }

                ' Inicializar una lista para almacenar los ingresos y egresos por mes
                Dim ingresosPorMes(11) As Integer
                Dim egresosPorMes(11) As Integer

                ' Llenar los arrays con valores por mes
                For Each row As DataRow In tabla.Rows
                    Dim mes As Integer = Convert.ToInt32(row("Mes")) - 1
                    ingresosPorMes(mes) = Convert.ToInt32(row("IngresosDevCliente"))
                    egresosPorMes(mes) = Convert.ToInt32(row("EgresosParteSalida"))
                Next

                ' Asignar los valores al gráfico
                ingresosSeries.Values = New ChartValues(Of Integer)(ingresosPorMes)
                egresosSeries.Values = New ChartValues(Of Integer)(egresosPorMes)

                series.Add(ingresosSeries)
                series.Add(egresosSeries)
            End If

        Catch ex As Exception
            MsgBox("Error al cargar el gráfico de líneas: " & ex.Message)
        End Try

        Return series
    End Function



    Public Function InsertarPallet(ByVal pallet As PalletModel) As Boolean
        Dim validator As New PalletValidator()
        Dim result As ValidationResult = validator.Validate(pallet)

        If Not result.IsValid Then
            For Each validationError As ValidationFailure In result.Errors
                MsgBox($"Error en {validationError.PropertyName}: {validationError.ErrorMessage}")
            Next
            Return False
        End If

        Dim query As String = "INSERT INTO Almacen.dbo.Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoPallet, TipoMovimientoId, Observacion, Retorna,NroParteSalida) " &
                       "VALUES (@Fecha, SYSDATETIME(), @CodFletero, @CodCliente, @Cantidad, @EstadoDevolucionId, @TipoPallet, @TipoMovimientoId, @Observacion, @Retorna,@NroParteSalida)"

        Dim parametros As SqlParameter() = {
        New SqlParameter("@Fecha", SqlDbType.Date) With {.Value = pallet.Fecha},
        New SqlParameter("@CodFletero", SqlDbType.SmallInt) With {.Value = Convert.ToInt16(pallet.CodFletero)},
        New SqlParameter("@CodCliente", SqlDbType.Int) With {.Value = Convert.ToInt32(pallet.CodCliente)},
        New SqlParameter("@Cantidad", SqlDbType.Int) With {.Value = pallet.Cantidad},
        New SqlParameter("@EstadoDevolucionId", SqlDbType.Int) With {.Value = pallet.EstadoDevolucionId},
        New SqlParameter("@TipoPallet", SqlDbType.BigInt) With {.Value = pallet.TipoPallet},
        New SqlParameter("@TipoMovimientoId", SqlDbType.Int) With {.Value = pallet.TipoMovimientoId},
        New SqlParameter("@Observacion", SqlDbType.NVarChar, 50) With {.Value = pallet.Observacion},
        New SqlParameter("@Retorna", SqlDbType.Bit) With {.Value = pallet.Retorna},
        New SqlParameter("@NroParteSalida", SqlDbType.Bit) With {.Value = 999}
    }

        Try
            Dim filasAfectadas As Integer = ServidorSQL.InsertTablaParam(query, parametros)

            If filasAfectadas > 0 Then
                Return True
            Else
                MsgBox("Error al intentar registrar el movimiento del pallet.")
                Return False
            End If

        Catch ex As Exception
            MsgBox("Error al registrar el pallet: " & ex.Message)
            Return False
        End Try
    End Function





    Public Function cargarGrillaMovimientosPallets() As DataTable
        Try
            Dim cadenasql = "SELECT TOP 5 p.id, CONVERT(VARCHAR(19), p.FechaCarga, 120) AS 'FechaCarga', 
                            tmp.descripcion AS 'Tipo de Movimiento',
                            p.Cantidad,
							ISNULL(CONCAT(c.CodCliente, '- ', c.RazonSocial), '-') AS 'Cliente',
							ISNULL(CONCAT(f.CodFletero, '- ', f.RazonSocial), '-') AS 'Transportista',
                            observacion
                            FROM Almacen.dbo.Pallets p 
                            LEFT JOIN CtasCtesSQL.dbo.Clientes c ON p.CodCliente = c.codCliente
                            LEFT JOIN CtasCtesSQL.dbo.Fleteros f ON p.CodFletero = f.CodFletero
                            INNER JOIN Almacen.dbo.TipoMovimientoPallets tmp ON p.TipoMovimientoId = tmp.id
                            WHERE tmp.id in (1,2)
                            ORDER BY p.id DESC"

            Dim result As DataTable = GetTabla(cadenasql)

            If result IsNot Nothing AndAlso result.Rows.Count = 0 Then
                result = New DataTable()
            End If

            Return result
        Catch ex As Exception
            MsgBox("Error al obtener datos de la base. " & ex.ToString)
            Return Nothing
        End Try
    End Function



    Public Function cargarGrillaParteSalida(ByVal NroParteSalida As Integer) As DataTable
        Try
            Dim parametros As SqlParameter() = {New SqlParameter("@NroParteSalida", NroParteSalida)}
            Dim cadenasql = "SELECT ps.NroParteSalida, oe.nroOEntrega as NroEntrega, f.CodFletero, c.CodCliente,CONCAT(c.CodCliente, '- ', c.RazonSocial) AS 'Cliente'
                          FROM Almacen.dbo.ParteSalida ps 
                          INNER JOIN Almacen.dbo.oenOEntrega oe ON ps.nroParteSalida = oe.ParteSalida
                          INNER JOIN CtasCtesSQL.dbo.Fleteros f ON f.CodFletero = ps.CodFletero
                          INNER JOIN Almacen.dbo.oenOCarga oc ON oe.nroOEntrega = oc.NroOEntrega
                          INNER JOIN Ventas.dbo.DetalleOCarga doc ON doc.NroOCarga = oc.OCarga
                          INNER JOIN Ventas.dbo.Pedidos p ON p.NroPedido = doc.NroPedido
                          INNER JOIN CtasCtesSQL.dbo.Clientes c ON c.CodCliente = p.NroCliente
                          WHERE ps.NroParteSalida = @NroParteSalida
                          ORDER BY c.CodCliente"

            Dim result As DataTable = GetTablaParam(cadenasql, parametros)

            If result IsNot Nothing AndAlso result.Rows.Count = 0 Then
                result = New DataTable()
            End If

            Return result
        Catch ex As Exception
            MsgBox("Error al obtener datos de la base. " & ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function insertarAsignacion(ByVal asignacion As PalletCliente) As Boolean
        Dim validator As New PalletClienteValidador()
        Dim result As ValidationResult = validator.Validate(asignacion)

        If Not result.IsValid Then
            For Each validationError As ValidationFailure In result.Errors
                MsgBox($"Error en {validationError.PropertyName}: {validationError.ErrorMessage}")
            Next
            Return False
        End If

        ' Consulta SQL para insertar en AsignacionPalletsOEntrega y obtener el ID generado
        Dim queryAsignacion As String = "INSERT INTO Almacen.dbo.AsignacionPalletsOEntrega (NroParteSalida, FechaCarga, NroOEntrega, CantidadPallets, PosicionEnCamion, TipoMovimientoId) " &
                                    "VALUES (@NroParteSalida, CONVERT(DATETIME, SYSDATETIMEOFFSET()), @NroOEntrega, @CantidadPallets, @PosicionEnCamion, @TipoMovimientoId); " &
                                    "SELECT SCOPE_IDENTITY();"

        Dim parametrosAsignacion As SqlParameter() = {
        New SqlParameter("@NroParteSalida", SqlDbType.Int) With {.Value = Convert.ToInt32(asignacion.NroParteSalida)},
        New SqlParameter("@NroOEntrega", SqlDbType.Int) With {.Value = asignacion.NroOEntrega},
        New SqlParameter("@CantidadPallets", SqlDbType.SmallInt) With {.Value = asignacion.CantidadPallets},
        New SqlParameter("@PosicionEnCamion", SqlDbType.VarChar) With {.Value = asignacion.PosicionEnCamion},
        New SqlParameter("@TipoMovimientoId", SqlDbType.Int) With {.Value = 3}
    }

        Try
            ' Aquí obtnego el ID generado por SCOPE_IDENTITY() para cada inserción
            Dim idAsignacion As Integer = CInt(ServidorSQL.GetTablaParam(queryAsignacion, parametrosAsignacion).Rows(0)(0))

            ' Si la inserción fue exitosa, registro en la tabla Pallets con el ID de Asignación generado
            Dim successPallet As Boolean = InsertarPallet(asignacion, idAsignacion)
            If successPallet Then
                Return True
            Else
                MsgBox("Error al registrar el movimiento de pallet.")
                Return False
            End If

        Catch ex As Exception
            MsgBox("Error al registrar asignación de pallets: " & ex.Message)
            Return False
        End Try
    End Function




    Public Function InsertarPallet(ByVal asignacion As PalletCliente, ByVal idAsignacion As Integer) As Boolean
        Dim queryPallet As String = "INSERT INTO Almacen.dbo.Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoMovimientoId, Observacion, Retorna, TipoPallet, AsignacionPalletId,NroParteSalida) " &
                                "VALUES (CONVERT(DATE, SYSDATETIMEOFFSET()), CONVERT(DATETIME, SYSDATETIMEOFFSET()), @CodFletero, @CodCliente, @Cantidad, @EstadoDevolucionId, @TipoMovimientoId, @Observacion, @Retorna, @TipoPallet, @AsignacionPalletId,@NroParteSalida)"

        Dim parametrosPallet As SqlParameter() = {
        New SqlParameter("@CodFletero", SqlDbType.SmallInt) With {.Value = asignacion.CodFletero},
        New SqlParameter("@CodCliente", SqlDbType.Int) With {.Value = asignacion.CodCliente},
        New SqlParameter("@Cantidad", SqlDbType.Int) With {.Value = asignacion.CantidadPallets},
        New SqlParameter("@EstadoDevolucionId", SqlDbType.Int) With {.Value = 1}, ' BuenEstado
        New SqlParameter("@TipoMovimientoId", SqlDbType.Int) With {.Value = 3}, 'EgresoPorParteSalida
        New SqlParameter("@Observacion", SqlDbType.NVarChar) With {.Value = "Egreso Parte Salida,Cant Pallets por Cliente"},
        New SqlParameter("@Retorna", SqlDbType.Bit) With {.Value = True},
        New SqlParameter("@TipoPallet", SqlDbType.BigInt) With {.Value = 4010100010001}, 'Dejo por defecto CodInsumo TARIMAS TIPO ARLOG 1x1,20 mts.
        New SqlParameter("@AsignacionPalletId", SqlDbType.Int) With {.Value = idAsignacion},
        New SqlParameter("@NroParteSalida", SqlDbType.Int) With {.Value = asignacion.NroParteSalida}
    }

        Try
            Dim filasAfectadas As Integer = ServidorSQL.InsertTablaParam(queryPallet, parametrosPallet)
            Return filasAfectadas > 0
        Catch ex As Exception
            MsgBox("Error al registrar el pallet: " & ex.Message)
            Return False
        End Try
    End Function




    Public Function ObtenerTotalPalletsEsperados(nroParteSalida As Integer) As Integer
        Dim query As String = "SELECT Pallets FROM [Almacen].[dbo].[ParteSalida] WHERE NroParteSalida = @NroParteSalida"
        Dim parametros As SqlParameter() = {New SqlParameter("@NroParteSalida", SqlDbType.Int) With {.Value = nroParteSalida}}

        Try
            Dim tabla As DataTable = ServidorSQL.GetTablaParam(query, parametros)
            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Dim resultado As Object = tabla.Rows(0)("Pallets")
                If resultado IsNot Nothing AndAlso IsNumeric(resultado) Then
                    Return Convert.ToInt32(resultado)
                End If
            End If
            Return -1
        Catch ex As Exception
            MsgBox("Error al obtener el total de pallets esperados: " & ex.Message)
            Return -1
        End Try
    End Function


    Public Function buscarCliente(RazonSocial As String, ByRef tabla As DataTable) As Long
        Dim query As String = ""
        Try
            If Not String.IsNullOrEmpty(RazonSocial) Then
                If IsNumeric(RazonSocial) Then
                    query = "SELECT CodCliente, CONCAT(CodCliente, ' - ', RazonSocial) AS RazonSocial FROM CtasCtesSQL.dbo.Clientes WHERE CodCliente = " & RazonSocial & " AND CodEstadoCliente = 1 ORDER BY CodCliente"
                Else
                    query = "SELECT CodCliente, CONCAT(CodCliente, ' - ', RazonSocial) AS RazonSocial FROM CtasCtesSQL.dbo.Clientes WHERE RazonSocial LIKE '%" & Trim(RazonSocial) & "%' AND CodEstadoCliente = 1 ORDER BY CodCliente"
                End If

                tabla = ServidorSQL.GetTabla(query)
                If tabla Is Nothing OrElse tabla.Rows.Count = 0 Then
                    buscarCliente = 0
                Else
                    buscarCliente = 1
                End If
            Else
                buscarCliente = -1 '
            End If

        Catch ex As Exception
            buscarCliente = -1
        End Try
    End Function

    Public Function buscarTransportistas(RazonSocial As String, ByRef tabla As DataTable) As Long
        Dim query As String = ""
        Try
            If Not String.IsNullOrEmpty(RazonSocial) Then
                If IsNumeric(RazonSocial) Then
                    query = "SELECT CodFletero, CONCAT(CodFletero, ' - ', RazonSocial) AS RazonSocial FROM CtasCtesSQL.dbo.Fleteros WHERE CodFletero = " & RazonSocial & " AND Activo = 'S' ORDER BY CodFletero"
                Else
                    query = "SELECT CodFletero, CONCAT(CodFletero, ' - ', RazonSocial) AS RazonSocial FROM CtasCtesSQL.dbo.Fleteros WHERE RazonSocial LIKE '%" & Trim(RazonSocial) & "%' AND Activo = 'S' ORDER BY CodFletero"
                End If

                tabla = ServidorSQL.GetTabla(query)
                If tabla Is Nothing OrElse tabla.Rows.Count = 0 Then
                    buscarTransportistas = 0
                Else
                    buscarTransportistas = 1
                End If
            Else
                buscarTransportistas = -1 '
            End If

        Catch ex As Exception
            buscarTransportistas = -1
        End Try
    End Function


    Public Function ObtenerTransportista(nroParteSalida As String) As Integer
        Dim sql As String = "SELECT ps.CodFletero
                         FROM Almacen.dbo.ParteSalida ps 
                         INNER JOIN Almacen.dbo.oenOEntrega oe ON ps.nroParteSalida = oe.ParteSalida
                         INNER JOIN Almacen.dbo.oenOCarga oc ON oe.nroOEntrega = oc.NroOEntrega
                         INNER JOIN Ventas.dbo.DetalleOCarga doc ON doc.NroOCarga = oc.OCarga
                         INNER JOIN Ventas.dbo.Pedidos p ON p.NroPedido = doc.NroPedido
                         INNER JOIN CtasCtesSQL.dbo.Clientes c ON c.CodCliente = p.NroCliente
                         INNER JOIN CtasCtesSQL.dbo.Fleteros f ON f.CodFletero = ps.CodFletero  
                         WHERE ps.NroParteSalida = @NroParteSalida"
        Dim parametros As SqlParameter() = {New SqlParameter("@NroParteSalida", SqlDbType.Int) With {.Value = nroParteSalida}}
        Dim dt As DataTable = ServidorSQL.GetTablaParam(sql, parametros)
        If dt.Rows.Count > 0 Then
            Return Convert.ToInt32(dt.Rows(0)("CodFletero"))
        Else
            Return 0
        End If
    End Function



    Public Function ObtenerClientes(nroParteSalida As String) As DataTable
        Dim sql As String = "SELECT DISTINCT c.CodCliente,CONCAT(c.CodCliente, ' - ', c.RazonSocial) AS Cliente
                             FROM Almacen.dbo.ParteSalida ps 
                             INNER JOIN Almacen.dbo.oenOEntrega oe ON ps.nroParteSalida = oe.ParteSalida
                             INNER JOIN Almacen.dbo.oenOCarga oc ON oe.nroOEntrega = oc.NroOEntrega
                             INNER JOIN Ventas.dbo.DetalleOCarga doc ON doc.NroOCarga = oc.OCarga
                             INNER JOIN Ventas.dbo.Pedidos p ON p.NroPedido = doc.NroPedido
                             INNER JOIN CtasCtesSQL.dbo.Clientes c ON c.CodCliente = p.NroCliente
                             WHERE ps.NroParteSalida = @NroParteSalida
							 ORDER BY c.CodCliente"
        Dim parametros As SqlParameter() = {New SqlParameter("@NroParteSalida", SqlDbType.Int) With {.Value = nroParteSalida}}
        Return ServidorSQL.GetTablaParam(sql, parametros)
    End Function


    Public Function InsertarDevolucionPallet(ByVal pallet As PalletModel) As Integer
        Dim sql As String = "INSERT INTO Almacen.dbo.Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoMovimientoId, Observacion, Retorna, TipoPallet, NroParteSalida) " &
                        "VALUES (@Fecha, CONVERT(DATETIME, SYSDATETIMEOFFSET()), @CodFletero, @CodCliente, @Cantidad, @EstadoDevolucionId, @TipoMovimientoId, @Observacion, @Retorna, @TipoPallet, @NroParteSalida)"

        Dim parametros() As SqlParameter = {
            New SqlParameter("@Fecha", SqlDbType.Date) With {.Value = pallet.Fecha},
            New SqlParameter("@CodFletero", SqlDbType.SmallInt) With {.Value = pallet.CodFletero},
            New SqlParameter("@CodCliente", SqlDbType.Int) With {.Value = pallet.CodCliente},
            New SqlParameter("@Cantidad", SqlDbType.Int) With {.Value = pallet.Cantidad},
            New SqlParameter("@EstadoDevolucionId", SqlDbType.Int) With {.Value = pallet.EstadoDevolucionId},
            New SqlParameter("@TipoMovimientoId", SqlDbType.Int) With {.Value = 4},
            New SqlParameter("@Observacion", SqlDbType.VarChar) With {.Value = pallet.Observacion},
            New SqlParameter("@Retorna", SqlDbType.Bit) With {.Value = True},
            New SqlParameter("@TipoPallet", SqlDbType.BigInt) With {.Value = pallet.TipoPallet},
            New SqlParameter("@NroParteSalida", SqlDbType.Int) With {.Value = pallet.NroParteSalida}
        }

        Try
            Dim filasAfectadas As Integer = ServidorSQL.InsertTablaParam(sql, parametros)
            Return filasAfectadas
        Catch ex As Exception
            MsgBox("Error al registrar la devolución de pallets: " & ex.Message)
            Return 0
        End Try
    End Function


End Class



