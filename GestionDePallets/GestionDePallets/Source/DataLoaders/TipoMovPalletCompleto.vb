
' Sigue el Principio de Responsabilidad Única (SPR Solid )al separar la lógica de carga de datos.
Public Class TipoMovPalletCompleto
        Implements IComboBoxDataLoader

        Public Function GetData() As DataTable Implements IComboBoxDataLoader.GetData
        Dim sql As String = "SELECT id, descripcion FROM Almacen.dbo.TipoMovimientoPallets ORDER BY id ASC"
        Return ServidorSQL.GetTabla(sql)
        End Function

        Public Function GetDisplayMember() As String Implements IComboBoxDataLoader.GetDisplayMember
            Return "descripcion"
        End Function

        Public Function GetValueMember() As String Implements IComboBoxDataLoader.GetValueMember
            Return "id"
        End Function
    End Class

