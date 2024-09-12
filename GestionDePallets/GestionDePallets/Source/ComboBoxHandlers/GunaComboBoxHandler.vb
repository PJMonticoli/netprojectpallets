' Clase GunaComboBoxHandler
' Implementa la interfaz IComboBoxHandler para configurar un ComboBox del tipo Guna.UI2.WinForms.Guna2ComboBox.
' - SetData: Configura el Guna2ComboBox con los datos proporcionados.
'   - comboBox: El control Guna2ComboBox a configurar.
'   - dataSource: DataTable que contiene los datos para el ComboBox.
'   - displayMember: Nombre del campo que se mostrará en el ComboBox.
'   - valueMember: Nombre del campo que se usará como valor asociado a cada ítem en el ComboBox.
'   - DropDownStyle: Se establece en ComboBoxStyle.DropDownList para evitar edición manual.
Public Class GunaComboBoxHandler
    Implements IComboBoxHandler
    Public Sub SetData(comboBox As Object, dataSource As DataTable, displayMember As String, valueMember As String) Implements IComboBoxHandler.SetData
        Dim gunaComboBox As Guna.UI2.WinForms.Guna2ComboBox = CType(comboBox, Guna.UI2.WinForms.Guna2ComboBox)
        gunaComboBox.DataSource = dataSource
        gunaComboBox.DisplayMember = displayMember
        gunaComboBox.ValueMember = valueMember
        gunaComboBox.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
End Class
