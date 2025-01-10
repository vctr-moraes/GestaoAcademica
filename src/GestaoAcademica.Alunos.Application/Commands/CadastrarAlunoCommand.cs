using FluentValidation;
using GestaoAcademica.Core.Messages;
using GestaoAcademica.Core.ValueObjects;

namespace GestaoAcademica.Alunos.Application.Commands
{
    public class CadastrarAlunoCommand : Command
    {
        public string Nome { get; private set; }
        public string NumeroDocumento { get; private set; }
        public DateOnly DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }
        public string NomePai { get; private set; }
        public string NomeMae { get; private set; }

        public CadastrarAlunoCommand(
            string nome,
            string numeroDocumento,
            DateOnly dataNascimento,
            Endereco endereco,
            string nomePai,
            string nomeMae)
        {
            Nome = nome;
            NumeroDocumento = numeroDocumento;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            NomePai = nomePai;
            NomeMae = nomeMae;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarAlunoValidation : AbstractValidator<CadastrarAlunoCommand>
    {
        public CadastrarAlunoValidation()
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
