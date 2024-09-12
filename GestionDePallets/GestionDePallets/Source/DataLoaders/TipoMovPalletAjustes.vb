' Sigue el Principio de Responsabilidad Única (SPR Solid )al separar la lógica de carga de datos.
Public Class TipoMovPalletAjustes
    Implements IComboBoxDataLoader

    Public Function GetData() As DataTable Implements IComboBoxDataLoader.GetData
        Dim sql As String = "SELECT id, descripcion FROM Almacen.dbo.TipoMovimientoPallets WHERE id IN (1,2) ORDER BY id ASC"
        Return ServidorSQL.GetTabla(sql)
    End Function

    Public Function GetDisplayMember() As String Implements IComboBoxDataLoader.GetDisplayMember
        Return "descripcion"
    End Function

    Public Function GetValueMember() As String Implements IComboBoxDataLoader.GetValueMember
        Return "id"
    End Function
End Class
