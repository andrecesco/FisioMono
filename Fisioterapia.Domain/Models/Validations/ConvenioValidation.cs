using FluentValidation;

namespace Fisioterapia.Domain.Models.Validations
{
    public class ConvenioValidation : AbstractValidator<Convenio>
    {
        public ConvenioValidation()
        {
            RuleFor(f => f.PacienteId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
