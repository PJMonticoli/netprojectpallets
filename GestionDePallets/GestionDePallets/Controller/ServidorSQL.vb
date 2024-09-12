Imports System
Imports System.Data.SqlClient

Public Class ServidorSQL
    Public conn As SqlConnection
    Public Shared conexion As New SqlConnection
    Public Shared transaccion As SqlTransaction
    Public Shared cadena As String = "SERVER=localhost;Database=Master;Trusted_Connection=True;"
    Private Const campoCodGestion As Long = 114

    Public Sub New()
        Me.conn = New SqlConnection(cadena)
    End Sub
    Public Shared Sub Conectar()
        Try
            Using conexion As New SqlConnection(cadena)
                conexion.Open()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Shared Function GetTabla(ByVal paramQuery As String) As DataTable
        Dim tabla As New DataTable

        Try
            Using conexion As New SqlConnection(cadena)
                conexion.Open()
                Using comando As New SqlCommand(paramQuery, conexion)
                    comando.CommandType = CommandType.Text
                    Using resultado As SqlDataReader = comando.ExecuteReader()
                        tabla.Load(resultado)
                    End Using
                End Using
            End Using

            Return tabla
        Catch ex As Exception
            MsgBox("Error al obtener datos de la base. " & ex.ToString)
            Return Nothing
        Finally
            tabla.Dispose()
        End Try
    End Function

    Public Shared Function GetTablaParam(ByVal paramQuery As String, ByVal parametros() As SqlParameter) As DataTable
        Dim tabla As New DataTable

        Try
            Using conexion As New SqlConnection(cadena)
                conexion.Open()
                Using comando As New SqlCommand(paramQuery, conexion)
                    comando.CommandType = CommandType.Text

                    If parametros IsNot Nothing AndAlso parametros.Length > 0 Then
                        comando.Parameters.AddRange(parametros)
                    End If

                    Using resultado As SqlDataReader = comando.ExecuteReader()
                        tabla.Load(resultado)
                    End Using
                End Using
            End Using

            Return tabla
        Catch ex As Exception
            MsgBox("Error al obtener datos de la base. " & ex.ToString)
            Return Nothing
        Finally
            tabla.Dispose()
        End Try
    End Function



    Public Shared Function InsertTabla(ByVal paramQuery As String) As Integer
        Dim resultado As Integer = -1

        Using conn As New SqlConnection(cadena)
            conn.Open()
            Using transaccion As SqlTransaction = conn.BeginTransaction()
                Try
                    Using comando As New SqlCommand(paramQuery, conn, transaccion)
                        comando.CommandType = CommandType.Text
                        resultado = comando.ExecuteNonQuery()
                        transaccion.Commit()
                    End Using
                Catch ex As Exception
                    transaccion.Rollback()
                    MsgBox("Error al insertar datos en la base. " & ex.ToString)
                End Try
            End Using
        End Using

        Return resultado
    End Function

    Public Shared Function InsertTablaParam(ByVal paramQuery As String, ByVal parametros() As SqlParameter) As Integer
        Dim resultado As Integer = -1

        Using conn As New SqlConnection(cadena)
            conn.Open()
            Using transaccion As SqlTransaction = conn.BeginTransaction()
                Try
                    Using comando As New SqlCommand(paramQuery, conn, transaccion)
                        comando.CommandType = CommandType.Text

                        If parametros IsNot Nothing AndAlso parametros.Length > 0 Then
                            comando.Parameters.AddRange(parametros)
                        End If

                        resultado = comando.ExecuteNonQuery()
                        transaccion.Commit()
                    End Using
                Catch ex As SqlException
                    transaccion.Rollback()
                    MsgBox("Error al ejecutar la consulta en la base de datos. " & ex.ToString)
                End Try
            End Using
        End Using

        Return resultado
    End Function

    Public Shared Function GetTablaParamReporte(ByVal paramQuery As String, ByVal parametros() As SqlParameter) As DataTable
        Dim tabla As New DataTable()

        Try
            Using conexion As New SqlConnection(cadena)
                conexion.Open()
                Using comando As New SqlCommand(paramQuery, conexion)
                    comando.CommandType = CommandType.Text

                    If parametros IsNot Nothing AndAlso parametros.Length > 0 Then
                        comando.Parameters.AddRange(parametros)
                    End If

                    Using resultado As SqlDataReader = comando.ExecuteReader()
                        tabla.Load(resultado)
                    End Using
                End Using
            End Using

            Return tabla
        Catch ex As Exception
            MsgBox("Error al obtener datos de la base. " & ex.ToString)
            Return Nothing
        Finally
            tabla.Dispose()
        End Try
    End Function




    Public Shared ReadOnly Property CodGestion() As Long
        Get
            Return campoCodGestion
        End Get
    End Property



End Class
