using FluentValidation;
using TechMed.Application.InputModels;

namespace TechMed.Application.Validators;
public class NewPacienteValidator : AbstractValidator<NewPacienteInputModel>
{
    public NewPacienteValidator()
    {
        RuleFor(p => p.Nome)
        .NotEmpty().WithMessage("Nome é obrigatório")
        .MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caracteres");

        RuleFor(p => p.Cpf)
        .NotEmpty().WithMessage("CPF é obrigatório")
        .Length(14).WithMessage("CPF deve ter 11 caracteres")
        .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("CPF deve estar no formato 000.000.000-00");       
    
        RuleFor(p => p.Email)
        .NotEmpty().WithMessage("Email é obrigatório")
        .EmailAddress().WithMessage("Email inválido");
    
    }


}
