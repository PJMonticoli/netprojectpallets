Public Class PalletModel
    Public Property NroOEntrega As Integer
    Public Property Fecha As Date
    Public Property FechaCarga As DateTime
    Public Property CodFletero As Short?
    Public Property CodCliente As Integer?
    Public Property Cantidad As Integer
    Public Property CantidadMalEstado As Integer
    Public Property CantidadVale As Integer
    Public Property EstadoDevolucionId As Integer
    Public Property TipoPallet As Long?
    Public Property TipoMovimientoId As Integer?
    Public Property Observacion As String
    Public Property Retorna As Boolean
End Class
