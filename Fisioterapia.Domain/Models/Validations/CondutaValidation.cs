using FluentValidation;
using System;

namespace Fisioterapia.Domain.Models.Validations
{
    public class CondutaValidation : AbstractValidator<Conduta>
    {
        public CondutaValidation()
        {
            RuleFor(f => f.PacienteId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.DataConduta)
                .NotEmpty()
                .GreaterThan(DateTime.MinValue)
                .WithMessage("O campo {PropertyName} precisa ser fornecido");   
        }
    }
}
