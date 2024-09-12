Imports FluentValidation

Public Class PalletClienteValidador
    Inherits AbstractValidator(Of PalletCliente)

    Public Sub New()
        RuleFor(Function(p) p.CantidadPallets).
        GreaterThan(0).WithMessage("La cantidad debe ser mayor que cero.")
        'NotEmpty().WithMessage("Revise y complete las cantidades de pallets.").
        RuleFor(Function(p) p.PosicionEnCamion).
            NotEmpty().WithMessage("Revise y complete las posiciones de pallets del camión.")
    End Sub
End Class
