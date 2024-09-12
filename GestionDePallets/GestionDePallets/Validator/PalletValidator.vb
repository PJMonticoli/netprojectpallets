﻿Imports FluentValidation

Public Class PalletValidator
    Inherits AbstractValidator(Of PalletModel)

    Public Sub New()
        RuleFor(Function(p) p.Fecha).
            NotEmpty().WithMessage("La fecha es requerida.").
            LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha no puede ser futura.")

        RuleFor(Function(p) p.TipoMovimientoId).
            NotNull().WithMessage("Tipo de Movimiento es requerido, completar campo.").
            GreaterThan(0).WithMessage("Debes seleccionar un tipo de movimiento válido.")


        RuleFor(Function(p) p.TipoPallet).
            NotNull().WithMessage("Tipo de Pallet valido es requerido, completar campo.").
            GreaterThan(0).WithMessage("Debes seleccionar un tipo de pallet valido.")

        RuleFor(Function(p) p.Cantidad).
            GreaterThan(0).WithMessage("La cantidad debe ser mayor que cero.")

        RuleFor(Function(p) p.EstadoDevolucionId).
            InclusiveBetween(1, 3).WithMessage("El estado de devolución es inválido.")

        RuleFor(Function(p) p.Observacion).
            MaximumLength(50).WithMessage("La observación no puede exceder los 50 caracteres.").
            NotEmpty().WithMessage("La observación es requerida, detalle brevemente el motivo del movimiento.")
    End Sub

End Class