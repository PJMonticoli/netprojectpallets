' Clase Cliente
' Implementa la interfaz IComboBoxDataLoader para proporcionar datos para un ComboBox específico.
' - GetData: Ejecuta una consulta SQL para obtener una tabla con los clientes activos.
' - GetDisplayMember: Retorna el nombre del campo que se mostrará en el ComboBox (RazonSocial).
' - GetValueMember: Retorna el nombre del campo que se usará como valor en el ComboBox (CodCliente).
' Sigue el Principio de Responsabilidad Única (SPR Solid )al separar la lógica de carga de datos.
Public Class Cliente


    Implements IComboBoxDataLoader

    Public Function GetData() As DataTable Implements IComboBoxDataLoader.GetData
        Dim sql As String = "SELECT CodCliente, CONCAT(CodCliente,'-',RazonSocial) as RazonSocial FROM CtasCtesSQL.dbo.Clientes WHERE CodEstadoCliente = 1 ORDER BY CodCliente ASC"
        Return ServidorSQL.GetTabla(sql)
    End Function

    Public Function GetDisplayMember() As String Implements IComboBoxDataLoader.GetDisplayMember
        Return "RazonSocial"
    End Function

    Public Function GetValueMember() As String Implements IComboBoxDataLoader.GetValueMember
        Return "CodCliente"
    End Function
End Class
