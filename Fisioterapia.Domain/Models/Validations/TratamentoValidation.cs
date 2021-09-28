using FluentValidation;

namespace Fisioterapia.Domain.Models.Validations
{
    public class TratamentoValidation : AbstractValidator<Tratamento>
    {
        public TratamentoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 250)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
