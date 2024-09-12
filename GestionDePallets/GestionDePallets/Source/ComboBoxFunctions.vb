' Clase ComboBoxFunctions
' Proporciona un método estático para cargar datos en un ComboBox de manera generalizada.
' - CargarComboGeneral(paramCombo As Object, comboBoxType As String):
'   - ParamCombo: El control ComboBox que se va a llenar. Debe coincidir con el tipo esperado.
'   - ComboBoxType: Tipo del ComboBox, utilizado para determinar cómo se debe manejar.
'   - Utiliza patron Factory ComboBoxDataLoaderFactory para obtener un cargador de datos (IComboBoxDataLoader) y un manejador de ComboBox (IComboBoxHandler).
'   - Maneja cualquier excepción que pueda ocurrir durante el proceso y muestra un mensaje de error.

Public Class ComboBoxFunctions
    Public Shared Sub CargarComboGeneral(ByRef paramCombo As Object, comboBoxType As String)
        Try
            Dim loader As IComboBoxDataLoader = ComboBoxDataLoaderFactory.GetLoader(paramCombo.Name)
            Dim handler As IComboBoxHandler = ComboBoxDataLoaderFactory.GetHandler(comboBoxType)

            Dim data As DataTable = loader.GetData()
            Dim displayMember As String = loader.GetDisplayMember()
            Dim valueMember As String = loader.GetValueMember()

            handler.SetData(paramCombo, data, displayMember, valueMember)

        Catch ex As Exception
            MsgBox("No se pudo cargar el combo " & paramCombo.ToString() & " " & ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class


'Public Class ComboBoxFunctions
'    Public Shared Sub CargarComboGeneral(ByRef paramCombo As ComboBox)
'        Dim tabla As String = ""
'        Dim campos As String = ""
'        Dim displayMember As String = ""
'        Dim valueMember As String = ""
'        Dim filtro As String = ""
'        Dim orden As String = ""

'        Select Case paramCombo.Name
'            Case "cboTipoMovimiento"
'                tabla = "Almacen.dbo.TipoMovimientoPallets"
'                campos = "id, descripcion"
'                displayMember = "descripcion"
'                valueMember = "id"
'                orden = "id ASC"
'                filtro = "id in (1,2)"

'            Case "cboCliente"
'                tabla = "CtasCtesSQL.dbo.Clientes"
'                campos = "CodCliente, CONCAT(CodCliente,'-',RazonSocial) as RazonSocial"
'                displayMember = "RazonSocial"
'                valueMember = "CodCliente"
'                orden = "CodCliente ASC"
'                filtro = "CodEstadoCliente = 1"
'            Case "cboTransportista"
'                tabla = "CtasCtesSQL.dbo.Fleteros"
'                campos = "CodFletero, CONCAT(CodFletero,'-',RazonSocial) as RazonSocial"
'                displayMember = "RazonSocial"
'                valueMember = "CodFletero"
'                orden = "CodFletero ASC"
'                filtro = "Activo = 'S'"
'            Case "cboTipoPallet"
'                tabla = "Proveedores.dbo.Insumos"
'                campos = "CodInsumo, Descripcion"
'                displayMember = "Descripcion"
'                valueMember = "CodInsumo"
'                filtro = "Participa = 1"

'            Case "cboClienteDevolucion"
'                tabla = "CtasCtesSQL.dbo.Clientes"
'                campos = "CodCliente, CONCAT(CodCliente,'-',RazonSocial) as RazonSocial"
'                displayMember = "RazonSocial"
'                valueMember = "CodCliente"
'                orden = "CodCliente ASC"
'                filtro = "CodEstadoCliente = 1"
'        End Select

'        Try
'            Dim sql As String = "SELECT " & campos & " FROM " & tabla
'            If Not String.IsNullOrEmpty(filtro) Then
'                sql &= " WHERE " & filtro
'            End If
'            If Not String.IsNullOrEmpty(orden) Then
'                sql &= " ORDER BY " & orden
'            End If

'            Dim dt As New DataTable
'            dt = ServidorSQL.GetTabla(sql)

'            paramCombo.DataSource = dt
'            paramCombo.ValueMember = valueMember
'            paramCombo.DisplayMember = displayMember
'            paramCombo.DropDownStyle = ComboBoxStyle.DropDownList

'        Catch ex As Exception
'            MsgBox("No se pudo cargar el combo " & paramCombo.Name & " " & ex.ToString, MsgBoxStyle.Critical, "Error")
'            paramCombo.SelectedIndex = -1
'        End Try
'    End Sub

'    'Public Shared Sub CargarCombo(ByRef paramCombo As ComboBox, ByVal paramTable As String, ByVal paramFields As String, ByVal paramDisplay As String, ByVal paramValue As String, Optional ByVal paramFilter As String = "", Optional ByVal paramOrderBy As String = "")
'    '    Try
'    '        Dim sql As String
'    '        Dim dt As New DataTable
'    '        sql = "SELECT " & paramFields & " FROM " & paramTable
'    '        If Not String.IsNullOrEmpty(paramFilter) Then
'    '            sql &= " WHERE " & paramFilter
'    '        End If
'    '        If Not String.IsNullOrEmpty(paramOrderBy) Then
'    '            sql &= " ORDER BY " & paramOrderBy
'    '        End If
'    '        dt = ServidorSQL.GetTabla(sql)
'    '        paramCombo.DataSource = dt
'    '        paramCombo.ValueMember = paramValue
'    '        paramCombo.DisplayMember = paramDisplay
'    '        paramCombo.DropDownStyle = ComboBoxStyle.DropDownList
'    '    Catch ex As Exception
'    '        MsgBox("No se pudo cargar el combo " & paramCombo.Name & " " & ex.ToString, MsgBoxStyle.Critical, "Error")
'    '        paramCombo.SelectedIndex = -1
'    '    End Try
'    'End Sub

'End Class
' Ubicado en: Source/ComboBoxFunctions.vb