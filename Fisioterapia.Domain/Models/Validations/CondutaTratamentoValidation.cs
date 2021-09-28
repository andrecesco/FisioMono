using FluentValidation;

namespace Fisioterapia.Domain.Models.Validations
{
    public class CondutaTratamentoValidation : AbstractValidator<CondutaTratamento>
    {
        public CondutaTratamentoValidation()
        {
            RuleFor(f => f.CondutaId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.TratamentoId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");        
        }
    }
}
