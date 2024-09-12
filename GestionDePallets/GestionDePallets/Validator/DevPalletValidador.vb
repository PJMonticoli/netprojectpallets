Imports FluentValidation

Public Class DevPalletValidador
    Inherits AbstractValidator(Of PalletModel)

    Public Sub New()
        RuleFor(Function(p) p.Cantidad).
            NotEmpty().WithMessage("Revise y complete las cantidades de pallets.").
            GreaterThan(0).WithMessage("La cantidad debe ser mayor que cero.")

        RuleFor(Function(p) p.Fecha).
            NotEmpty().WithMessage("La fecha es requerida.").
            LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha no puede ser futura.")

        RuleFor(Function(p) p.CodCliente).
            NotEmpty().WithMessage("Campo cliente requerido, complete por favor.")

        RuleFor(Function(p) p.Observacion).
            NotEmpty().WithMessage("Observación es requerida, complete por favor.")
    End Sub
End Class
