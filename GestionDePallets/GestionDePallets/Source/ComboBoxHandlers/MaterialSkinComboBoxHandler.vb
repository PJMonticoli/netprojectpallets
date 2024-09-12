' Clase MaterialSkinComboBoxHandler
' Implementa la interfaz IComboBoxHandler para configurar un ComboBox del tipo MaterialSkin.
' - SetData: Configura el MaterialSkin con los datos proporcionados.
'   - comboBox: El control MaterialSkin a configurar.
'   - dataSource: DataTable que contiene los datos para el ComboBox.
'   - displayMember: Nombre del campo que se mostrará en el ComboBox.
'   - valueMember: Nombre del campo que se usará como valor asociado a cada ítem en el ComboBox.
'   - DropDownStyle: Se establece en ComboBoxStyle.DropDownList para evitar edición manual.
Public Class MaterialSkinComboBoxHandler
    Implements IComboBoxHandler

    Public Sub SetData(comboBox As Object, dataSource As DataTable, displayMember As String, valueMember As String) Implements IComboBoxHandler.SetData
        Dim materialComboBox As MaterialSkin.Controls.MaterialComboBox = CType(comboBox, MaterialSkin.Controls.MaterialComboBox)
        materialComboBox.DataSource = dataSource
        materialComboBox.DisplayMember = displayMember
        materialComboBox.ValueMember = valueMember
        materialComboBox.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
End Class
