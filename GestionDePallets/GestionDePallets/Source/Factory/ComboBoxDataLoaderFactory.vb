' Clase ComboBoxDataLoaderFactory
' Proporciona métodos para obtener instancias de cargadores de datos y manejadores de ComboBox.
' - GetLoader(comboBoxName As String): Devuelve una instancia de IComboBoxDataLoader según el nombre del ComboBox.
' - GetHandler(comboBoxType As String): Devuelve una instancia de IComboBoxHandler según el tipo del ComboBox.
' Utiliza un patrón de diseño Factory para crear objetos específicos sin exponer la lógica de creación.

Public Class ComboBoxDataLoaderFactory
    Public Shared Function GetLoader(comboBoxName As String) As IComboBoxDataLoader
        Select Case comboBoxName
            Case "cboTipoMovimiento"
                Return New TipoMovPalletAjustes()
            Case "cboTipoMovReporte"
                Return New TipoMovPalletCompleto()
            Case "cboCliente"
                Return New Cliente()
            Case "cboClienteReporte"
                Return New Cliente()
            Case "cboClienteInforme"
                Return New Cliente()
            Case "cboClienteDevolucion"
                Return New Cliente()
            Case "cboTransportista"
                Return New Transportista()
            Case "cboTraReporte"
                Return New Transportista()
            Case "cboTransportistaInforme"
                Return New Transportista()
            Case "cboTransportistaDev"
                Return New Transportista()
            Case "cboTipoPallet"
                Return New TipoPallet()
            Case "cboTipoPalletReporte"
                Return New TipoPallet()
            Case Else
                Throw New ArgumentException("Nombre de ComboBox desconocido")
        End Select
    End Function

    Public Shared Function GetHandler(comboBoxType As String) As IComboBoxHandler
        Select Case comboBoxType
            Case 1
                Return New MaterialSkinComboBoxHandler()
            Case 2
                Return New GunaComboBoxHandler()
            Case Else
                Throw New ArgumentException("Tipo de ComboBox desconocido")
        End Select
    End Function
End Class