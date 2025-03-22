using FluentValidation;
using GestaoAcademica.Core.Messages;
using GestaoAcademica.Core.ValueObjects;

namespace GestaoAcademica.Alunos.Application.Commands
{
    public class AtualizarAlunoCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string NumeroDocumento { get; private set; }
        public DateOnly DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }
        public string NomePai { get; private set; }
        public string NomeMae { get; private set; }

        public AtualizarAlunoCommand(
            Guid id,
            string nome,
            string numeroDocumento,
            DateOnly dataNascimento,
            Endereco endereco,
            string nomePai,
            string nomeMae)
        {
            Id = id;
            Nome = nome;
            NumeroDocumento = numeroDocumento;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            NomePai = nomePai;
            NomeMae = nomeMae;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarAlunoValidation : AbstractValidator<AtualizarAlunoCommand>
    {
        public AtualizarAlunoValidation()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("O nome do aluno não foi informado.");

            RuleFor(a => a.NumeroDocumento)
                .NotEmpty()
                .WithMessage("O número do documento do aluno não foi informado.");

            RuleFor(a => a.DataNascimento)
                .NotNull()
                .WithMessage("A data de nascimento do aluno não foi informada.");

            RuleFor(a => a.Endereco)
                .NotNull()
                .WithMessage("O endereço do aluno não foi informado.");

            RuleFor(a => a.NomePai)
                .NotEmpty()
                .WithMessage("O nome do pai do aluno não foi informado.");

            RuleFor(a => a.NomeMae)
                .NotEmpty()
                .WithMessage("O nome da mãe do aluno não foi informado.");
        }
    }
}