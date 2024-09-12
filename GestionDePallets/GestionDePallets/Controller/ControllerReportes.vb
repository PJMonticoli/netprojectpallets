Imports System.Data.SqlClient
Imports System.Windows.Media
Imports System.Windows.Input
Imports System.Text
Public Class ControllerReportes
    Inherits ServidorSQL


    Public Function GenerarConsultaReporte(fechaDesde As DateTime, fechaHasta As DateTime, tipoMov As Integer?, tipoPallet As Long?,
                                       cliente As Integer?, transportista As Short?, estado As Integer?, retorno As Integer) As String
        Dim query As New Text.StringBuilder()

        query.Append("SELECT p.Fecha, ")
        query.Append("tmp.descripcion AS 'Tipo de Movimiento', ")
        query.Append("p.Cantidad, ")
        query.Append("ISNULL(CONCAT(c.CodCliente, '- ', c.RazonSocial), '-') AS 'Cliente', ")
        query.Append("ISNULL(CONCAT(f.CodFletero, '- ', f.RazonSocial), '-') AS 'Transportista', ")
        query.Append("i.Descripcion AS 'Tipo de Pallet', ")
        query.Append("edp.descripcion AS 'Estado' ")
        query.Append("FROM Almacen.dbo.Pallets p ")
        query.Append("LEFT JOIN CtasCtesSQL.dbo.Clientes c ON p.CodCliente = c.CodCliente ")
        query.Append("LEFT JOIN CtasCtesSQL.dbo.Fleteros f ON p.CodFletero = f.CodFletero ")
        query.Append("INNER JOIN Almacen.dbo.TipoMovimientoPallets tmp ON p.TipoMovimientoId = tmp.id ")
        query.Append("INNER JOIN Proveedores.dbo.Insumos i ON i.codInsumo = p.TipoPallet ")
        query.Append("INNER JOIN Almacen.dbo.EstadoDevolucionPallets edp on edp.id = p.EstadoDevolucionId ")
        query.Append("WHERE p.Fecha BETWEEN @FechaDesde AND @FechaHasta ")
        query.Append("AND (@TipoMovimientoId IS NULL OR p.TipoMovimientoId = @TipoMovimientoId) ")
        query.Append("AND (@TipoPallet IS NULL OR p.TipoPallet = @TipoPallet) ")
        query.Append("AND (@CodCliente IS NULL OR p.CodCliente = @CodCliente) ")
        query.Append("AND (@CodFletero IS NULL OR p.CodFletero = @CodFletero) ")


        If estado.HasValue AndAlso estado.Value <> -1 Then
            query.Append("AND p.EstadoDevolucionId = @EstadoDevolucionId ")
        End If

        query.Append("AND p.Retorna = @Retorno ")
        query.Append("ORDER BY p.id DESC")

        Return query.ToString()
    End Function



    Public Function ObtenerDatosReporte(fechaDesde As DateTime, fechaHasta As DateTime, tipoMov As Integer?, tipoPallet As Long?,
                                    cliente As Integer?, transportista As Short?, estado As Integer?, retorno As Integer) As DataTable
        Dim query As String = GenerarConsultaReporte(fechaDesde, fechaHasta, tipoMov, tipoPallet, cliente, transportista, estado, retorno)

        Dim parametros As New List(Of SqlParameter) From {
        New SqlParameter("@FechaDesde", SqlDbType.DateTime) With {.Value = fechaDesde},
        New SqlParameter("@FechaHasta", SqlDbType.DateTime) With {.Value = fechaHasta},
        New SqlParameter("@TipoMovimientoId", SqlDbType.Int) With {.Value = If(tipoMov.HasValue, tipoMov.Value, DBNull.Value)},
        New SqlParameter("@TipoPallet", SqlDbType.BigInt) With {.Value = If(tipoPallet.HasValue, tipoPallet.Value, DBNull.Value)},
        New SqlParameter("@CodCliente", SqlDbType.Int) With {.Value = If(cliente.HasValue, cliente.Value, DBNull.Value)},
        New SqlParameter("@CodFletero", SqlDbType.SmallInt) With {.Value = If(transportista.HasValue, transportista.Value, DBNull.Value)},
        New SqlParameter("@EstadoDevolucionId", SqlDbType.Int) With {.Value = If(estado.HasValue AndAlso estado.Value <> -1, estado.Value, DBNull.Value)},
        New SqlParameter("@Retorno", SqlDbType.Bit) With {.Value = retorno}
    }

        Return ServidorSQL.GetTablaParamReporte(query, parametros.ToArray())
    End Function



    Public Function ObtenerDatosReporteInicial() As DataTable
        Dim query As String = "SELECT p.Fecha, " &
                          "tmp.descripcion AS 'Tipo de Movimiento', " &
                          "p.Cantidad, " &
                          "ISNULL(CONCAT(c.CodCliente, '- ', c.RazonSocial), '-') AS 'Cliente', " &
                          "ISNULL(CONCAT(f.CodFletero, '- ', f.RazonSocial), '-') AS 'Transportista', " &
                          "i.Descripcion AS 'Tipo de Pallet', " &
                          "edp.descripcion AS 'Estado' " &
                          "FROM Almacen.dbo.Pallets p " &
                          "LEFT JOIN CtasCtesSQL.dbo.Clientes c ON p.CodCliente = c.codCliente " &
                          "LEFT JOIN CtasCtesSQL.dbo.Fleteros f ON p.CodFletero = f.CodFletero " &
                          "INNER JOIN Almacen.dbo.TipoMovimientoPallets tmp ON p.TipoMovimientoId = tmp.id " &
                          "INNER JOIN Proveedores.dbo.Insumos i ON i.codInsumo = p.TipoPallet " &
                          "INNER JOIN Almacen.dbo.EstadoDevolucionPallets edp on edp.id = p.EstadoDevolucionId " &
                          "WHERE p.Fecha >= DATEADD(MONTH, -3, GETDATE()) AND p.Retorna = 1" &
                          "GROUP BY p.Fecha, tmp.descripcion, i.Descripcion, c.CodCliente, c.RazonSocial, f.CodFletero, f.RazonSocial,p.Cantidad,edp.descripcion " &
                          "ORDER BY p.Fecha DESC"

        Return ServidorSQL.GetTabla(query)
    End Function


    Public Function filtrarDgvReporte(ByVal busqueda As String, ByRef tabla As DataTable) As Long
        Dim query As String = "SELECT p.Fecha, " &
                              "tmp.descripcion AS 'Tipo de Movimiento', " &
                              "p.Cantidad, " &
                              "ISNULL(CONCAT(c.CodCliente, '- ', c.RazonSocial), '-') AS 'Cliente', " &
                              "ISNULL(CONCAT(f.CodFletero, '- ', f.RazonSocial), '-') AS 'Transportista', " &
                              "i.Descripcion AS 'Tipo de Pallet', " &
                              "edp.descripcion AS 'Estado' " &
                              "FROM Almacen.dbo.Pallets p " &
                              "LEFT JOIN CtasCtesSQL.dbo.Clientes c ON p.CodCliente = c.codCliente " &
                              "LEFT JOIN CtasCtesSQL.dbo.Fleteros f ON p.CodFletero = f.CodFletero " &
                              "INNER JOIN Almacen.dbo.TipoMovimientoPallets tmp ON p.TipoMovimientoId = tmp.id " &
                              "INNER JOIN Almacen.dbo.EstadoDevolucionPallets edp on edp.id = p.EstadoDevolucionId " &
                              "INNER JOIN Proveedores.dbo.Insumos i ON i.codInsumo = p.TipoPallet " &
                              "WHERE p.Fecha >= DATEADD(MONTH, -3, GETDATE()) AND p.Retorna = 1"

        If Not String.IsNullOrEmpty(busqueda) Then
            query &= " AND (ISNULL(CONCAT(c.CodCliente, '- ', c.RazonSocial), '-') LIKE '%' + @Busqueda + '%' " &
                     "OR ISNULL(CONCAT(f.CodFletero, '- ', f.RazonSocial), '-') LIKE '%' + @Busqueda + '%' " &
                     "OR tmp.descripcion LIKE '%' + @Busqueda + '%' " &
                     "OR edp.descripcion LIKE '%' + @Busqueda + '%' " &
                     "OR i.Descripcion LIKE '%' + @Busqueda + '%')"
        End If

        query &= "GROUP BY p.Fecha, tmp.descripcion, i.Descripcion, c.CodCliente, c.RazonSocial, f.CodFletero, f.RazonSocial,p.Cantidad,edp.descripcion " &
                 "ORDER BY p.Fecha DESC"

        Try
            Dim parametros As SqlParameter() = {New SqlParameter("@Busqueda", SqlDbType.VarChar) With {.Value = busqueda}}
            tabla = ServidorSQL.GetTablaParam(query, parametros)
            If tabla Is Nothing OrElse tabla.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            MessageBox.Show($"Ocurrió un error durante la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function
End Class
