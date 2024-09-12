' Sigue el Principio de Responsabilidad Única (SPR Solid )al separar la lógica de carga de datos.
Public Class TipoPallet
    Implements IComboBoxDataLoader

    Public Function GetData() As DataTable Implements IComboBoxDataLoader.GetData
        Dim sql As String = "SELECT CodInsumo, Descripcion FROM Proveedores.dbo.Insumos WHERE Participa = 1 ORDER BY CodInsumo ASC"
        Return ServidorSQL.GetTabla(sql)
    End Function

    Public Function GetDisplayMember() As String Implements IComboBoxDataLoader.GetDisplayMember
        Return "Descripcion"
    End Function

    Public Function GetValueMember() As String Implements IComboBoxDataLoader.GetValueMember
        Return "CodInsumo"
    End Function
End Class
