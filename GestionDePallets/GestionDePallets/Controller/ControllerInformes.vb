Imports System.Data.SqlClient

Public Class ControllerInformes
    Inherits ServidorSQL

    Private Function GenerarConsulta(Optional ByVal busqueda As String = "") As String
        Dim query As String = "SELECT p.fecha as Fecha, 
                                ISNULL(CONCAT(c.CodCliente, '- ', c.RazonSocial), '-') AS 'Cliente',
                                ISNULL(CONCAT(f.CodFletero, '- ', f.RazonSocial), '-') AS 'Transportista',
                                i.Descripcion AS 'Tipo de Pallet',

                                -- Total de pallets devueltos en buen estado (EstadoDevolucionId = 1)
                                SUM(CASE 
                                    WHEN p.TipoMovimientoId = 4 AND p.EstadoDevolucionId = 1 THEN p.Cantidad 
                                    ELSE 0 
                                END) AS 'T.Ing Bueno',

                                -- Total de pallets devueltos en mal estado (EstadoDevolucionId = 2)
                                SUM(CASE 
                                    WHEN p.TipoMovimientoId = 4 AND p.EstadoDevolucionId = 2 THEN p.Cantidad 
                                    ELSE 0 
                                END) AS 'T.Ing Malo',

                                -- Total de pallets devueltos como vale (EstadoDevolucionId = 3)
                                SUM(CASE 
                                    WHEN p.TipoMovimientoId = 4 AND p.EstadoDevolucionId = 3 THEN p.Cantidad 
                                    ELSE 0 
                                END) AS 'T.Ing Vale',

                                -- Total Egresos (TipoMovimientoId = 3)
                                SUM(CASE 
                                    WHEN p.TipoMovimientoId = 3 THEN p.Cantidad 
                                    ELSE 0 
                                END) AS 'T.Egresos PS',

                                -- Total Ingresos (TipoMovimientoId = 4)
                                SUM(CASE 
                                    WHEN p.TipoMovimientoId = 4 THEN p.Cantidad 
                                    ELSE 0 
                                END) AS 'T.Ing Dev Cte',

                                -- Saldo general de pallets (Total Egresos - Total Ingresos)
                                SUM(CASE 
                                    WHEN p.TipoMovimientoId = 3 THEN p.Cantidad 
                                    ELSE 0 
                                END) - 
                                SUM(CASE 
                                    WHEN p.TipoMovimientoId = 4 THEN p.Cantidad 
                                    ELSE 0 
                                END) AS 'Saldo Pallets'
                            FROM Almacen.dbo.Pallets p
                            LEFT JOIN CtasCtesSQL.dbo.Clientes c ON p.CodCliente = c.CodCliente
                            LEFT JOIN CtasCtesSQL.dbo.Fleteros f ON p.CodFletero = f.CodFletero
                            INNER JOIN Almacen.dbo.TipoMovimientoPallets tmp ON p.TipoMovimientoId = tmp.id
                            INNER JOIN Proveedores.dbo.Insumos i ON i.codInsumo = p.TipoPallet
                            INNER JOIN Almacen.dbo.EstadoDevolucionPallets edp ON edp.id = p.EstadoDevolucionId
                            WHERE p.Fecha >= DATEADD(DAY, -30, GETDATE()) AND p.TipoMovimientoId IN (3,4) "

        ' filtro de búsqueda si se proporciona
        If Not String.IsNullOrEmpty(busqueda) Then
            query &= " AND (ISNULL(CONCAT(c.CodCliente, '- ', c.RazonSocial), '-') LIKE '%' + @Busqueda + '%' " &
                     "OR ISNULL(CONCAT(f.CodFletero, '- ', f.RazonSocial), '-') LIKE '%' + @Busqueda + '%' " &
                     "OR i.Descripcion LIKE '%' + @Busqueda + '%')"
        End If


        query &= "GROUP BY p.fecha,c.CodCliente, c.RazonSocial, f.CodFletero, f.RazonSocial, i.Descripcion " &
                 "ORDER BY 'Saldo Pallets' DESC"

        Return query
    End Function

    ' Método para obtener los datos iniciales sin filtro
    Public Function ObtenerDatosInformeSaldosInicial() As DataTable
        Dim query As String = GenerarConsulta()
        Return ServidorSQL.GetTabla(query)
    End Function

    ' Método para filtrar datos
    Public Function filtrarDgvInforme(ByVal busqueda As String, ByRef tabla As DataTable) As Long
        Dim query As String = GenerarConsulta(busqueda)

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


    Public Function GenerarConsultaInforme(fechaDesde As DateTime, fechaHasta As DateTime,
                                       cliente As Integer?, transportista As Short?) As String
        Dim query As New Text.StringBuilder()

        query.Append("SELECT p.fecha as Fecha, ")
        query.Append("ISNULL(CONCAT(c.CodCliente, '- ', c.RazonSocial), '-') AS 'Cliente', ")
        query.Append("ISNULL(CONCAT(f.CodFletero, '- ', f.RazonSocial), '-') AS 'Transportista', ")
        query.Append("i.Descripcion AS 'Tipo de Pallet', ")

        query.Append("SUM(CASE WHEN p.TipoMovimientoId = 3 THEN p.Cantidad ELSE 0 END) AS 'T.Egresos PS', ")
        query.Append("SUM(CASE WHEN p.TipoMovimientoId = 4 THEN p.Cantidad ELSE 0 END) AS 'T.Ing Dev Cte', ")
        query.Append("SUM(CASE WHEN p.TipoMovimientoId = 3 THEN p.Cantidad ELSE 0 END) - ")
        query.Append("SUM(CASE WHEN p.TipoMovimientoId = 4 THEN p.Cantidad ELSE 0 END) AS 'Saldo Pallets', ")
        query.Append("SUM(CASE WHEN p.TipoMovimientoId = 4 AND p.EstadoDevolucionId = 1 THEN p.Cantidad ELSE 0 END) AS 'T.Ing Bueno', ")
        query.Append("SUM(CASE WHEN p.TipoMovimientoId = 4 AND p.EstadoDevolucionId = 2 THEN p.Cantidad ELSE 0 END) AS 'T.Ing Malo', ")
        query.Append("SUM(CASE WHEN p.TipoMovimientoId = 4 AND p.EstadoDevolucionId = 3 THEN p.Cantidad ELSE 0 END) AS 'T.Ing Vale' ")

        ' De las tablas involucradas
        query.Append("FROM Almacen.dbo.Pallets p ")
        query.Append("LEFT JOIN CtasCtesSQL.dbo.Clientes c ON p.CodCliente = c.CodCliente ")
        query.Append("LEFT JOIN CtasCtesSQL.dbo.Fleteros f ON p.CodFletero = f.CodFletero ")
        query.Append("INNER JOIN Almacen.dbo.TipoMovimientoPallets tmp ON p.TipoMovimientoId = tmp.id ")
        query.Append("INNER JOIN Proveedores.dbo.Insumos i ON i.codInsumo = p.TipoPallet ")
        query.Append("INNER JOIN Almacen.dbo.EstadoDevolucionPallets edp ON edp.id = p.EstadoDevolucionId ")
        query.Append("WHERE p.Fecha BETWEEN @FechaDesde AND @FechaHasta AND p.TipoMovimientoId IN (3,4) ")

        ' Filtro para cliente
        If cliente.HasValue Then
            query.Append("AND p.CodCliente = @CodCliente ")
        End If

        ' Filtro para transportista
        If transportista.HasValue Then
            query.Append("AND p.CodFletero = @CodFletero ")
        End If

        ' Agrupación de las columnas correctas
        query.Append("GROUP BY p.fecha, c.CodCliente, c.RazonSocial, f.CodFletero, f.RazonSocial, i.Descripcion ")
        query.Append("ORDER BY 'Saldo Pallets' DESC")

        Return query.ToString()
    End Function





    Public Function ObtenerDatosInforme(fechaDesde As DateTime, fechaHasta As DateTime,
                                     cliente As Integer?, transportista As Short?) As DataTable
        Dim query As String = GenerarConsultaInforme(fechaDesde, fechaHasta, cliente, transportista)

        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@FechaDesde", SqlDbType.DateTime) With {.Value = fechaDesde},
            New SqlParameter("@FechaHasta", SqlDbType.DateTime) With {.Value = fechaHasta}
        }

        If cliente.HasValue Then
            parametros.Add(New SqlParameter("@CodCliente", SqlDbType.Int) With {.Value = cliente.Value})
        End If

        If transportista.HasValue Then
            parametros.Add(New SqlParameter("@CodFletero", SqlDbType.SmallInt) With {.Value = transportista.Value})
        End If



        Return ServidorSQL.GetTablaParamReporte(query, parametros.ToArray())
    End Function


End Class
