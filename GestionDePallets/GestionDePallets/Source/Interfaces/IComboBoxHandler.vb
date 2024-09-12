' Interface IComboBoxHandler
' Define el método que debe implementar cualquier clase encargada de configurar un ComboBox.
' - SetData: Configura el ComboBox con los datos proporcionados.
'   - comboBox: El control ComboBox a configurar.
'   - dataSource: DataTable que contiene los datos para el ComboBox.
'   - displayMember: Nombre del campo que se mostrará en el ComboBox.
'   - valueMember: Nombre del campo que se usará como valor asociado a cada ítem en el ComboBox.
Public Interface IComboBoxHandler
    Sub SetData(comboBox As Object, dataSource As DataTable, displayMember As String, valueMember As String)
End Interface