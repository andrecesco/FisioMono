using FluentValidation;

namespace Fisioterapia.Domain.Models.Validations
{
    public class AnamneseValidation : AbstractValidator<Anamnese>
    {
        public AnamneseValidation()
        {
            RuleFor(f => f.PacienteId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
