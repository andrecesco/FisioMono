using FluentValidation;

namespace Fisioterapia.Domain.Models.Validations
{
    public class CondutaValidation : AbstractValidator<Conduta>
    {
        public CondutaValidation()
        {
            RuleFor(f => f.PacienteId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");        
        }
    }
}
