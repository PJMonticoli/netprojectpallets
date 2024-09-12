Imports FluentValidation

Public Class DevPalletValidador
    Inherits AbstractValidator(Of PalletModel)

    Public Sub New()
        RuleFor(Function(p) p.Cantidad).
         GreaterThanOrEqualTo(0).WithMessage("La cantidad debe ser mayor o igual a cero.")

        RuleFor(Function(p) p.Fecha).
            NotEmpty().WithMessage("La fecha es requerida.").
            LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha no puede ser futura.")

        RuleFor(Function(p) p.CodCliente).
            NotEmpty().WithMessage("Campo cliente requerido, complete por favor.")
        RuleFor(Function(p) p.Observacion).
        MaximumLength(50).WithMessage("La observación no puede exceder los 50 caracteres.")
    End Sub
End Class
