' Sigue el Principio de Responsabilidad Única (SPR Solid )al separar la lógica de carga de datos.
Public Class Transportista
    Implements IComboBoxDataLoader

    Public Function GetData() As DataTable Implements IComboBoxDataLoader.GetData
        Dim sql As String = "SELECT CodFletero, CONCAT(CodFletero,'-',RazonSocial) as RazonSocial FROM CtasCtesSQL.dbo.Fleteros WHERE Activo = 'S' ORDER BY CodFletero ASC"
        Return ServidorSQL.GetTabla(sql)
    End Function

    Public Function GetDisplayMember() As String Implements IComboBoxDataLoader.GetDisplayMember
        Return "RazonSocial"
    End Function

    Public Function GetValueMember() As String Implements IComboBoxDataLoader.GetValueMember
        Return "CodFletero"
    End Function
End Class
