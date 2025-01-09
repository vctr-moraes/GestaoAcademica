using FluentValidation;
using GestaoAcademica.Core.Messages;
using GestaoAcademica.Core.ValueObjects;

namespace GestaoAcademica.Professores.Application.Commands
{
    public class CadastrarProfessorCommand : Command
    {
        public string Nome { get; private set; }
        public string NumeroDocumento { get; private set; }
        public DateOnly DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }

        public CadastrarProfessorCommand(
            string nome,
            string numeroDocumento,
            DateOnly dataNascimento,
            Endereco endereco)
        {
            Nome = nome;
            NumeroDocumento = numeroDocumento;
            DataNascimento = dataNascimento;
            Endereco = endereco;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarProfessorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarProfessorValidation : AbstractValidator<CadastrarProfessorCommand>
    {
        public CadastrarProfessorValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do professor não foi informado.");

            RuleFor(c => c.NumeroDocumento)
                .NotEmpty()
                .WithMessage("O número do documento do professor não foi informado.");

            RuleFor(c => c.DataNascimento)
                .NotNull()
                .WithMessage("A data de nascimento do professor não foi informada.");

            RuleFor(c => c.Endereco)
                .NotNull()
                .WithMessage("O endereço do professor não foi informado.");
        }
    }
}
