' Interface IComboBoxDataLoader
' Define los métodos que deben implementar las clases encargadas de proporcionar datos a un ComboBox.
' - GetData: Obtiene un DataTable con los datos que se mostrarán en el ComboBox.
' - GetDisplayMember: Retorna el nombre del campo que se usará para mostrar los datos en el ComboBox.
' - GetValueMember: Retorna el nombre del campo que se usará como valor asociado a cada ítem en el ComboBox.

Public Interface IComboBoxDataLoader
    Function GetData() As DataTable
    Function GetDisplayMember() As String
    Function GetValueMember() As String
End Interface