using FluentValidation;
using GestaoAcademica.Core.Messages;
using GestaoAcademica.Core.ValueObjects;

namespace GestaoAcademica.Professores.Application.Commands
{
    public class AtualizarProfessorCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string NumeroDocumento { get; private set; }
        public DateOnly DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }

        public AtualizarProfessorCommand(
            Guid id,
            string nome,
            string numeroDocumento,
            DateOnly dataNascimento,
            Endereco endereco)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            NumeroDocumento = numeroDocumento;
            DataNascimento = dataNascimento;
            Endereco = endereco;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarProfessorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarProfessorValidation : AbstractValidator<AtualizarProfessorCommand>
    {
        public AtualizarProfessorValidation()
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
