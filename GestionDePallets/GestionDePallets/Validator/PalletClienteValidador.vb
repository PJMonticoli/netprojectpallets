Imports FluentValidation

Public Class PalletClienteValidador
    Inherits AbstractValidator(Of PalletCliente)

    Public Sub New()
        RuleFor(Function(p) p.CantidadPallets).
            NotEmpty().WithMessage("Revise y complete las cantidades de pallets.").
            GreaterThan(0).WithMessage("La cantidad debe ser mayor que cero.")

        RuleFor(Function(p) p.PosicionEnCamion).
            NotEmpty().WithMessage("Revise y complete las posiciones de pallets del camión.")
    End Sub
End Class
