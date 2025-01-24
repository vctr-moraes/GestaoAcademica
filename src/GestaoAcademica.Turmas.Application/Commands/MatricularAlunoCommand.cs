using FluentValidation;
using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Turmas.Application.Commands
{
    public class MatricularAlunoCommand : Command
    {
        public Guid IdTurma { get; private set; }
        public Guid IdAluno { get; private set; }
        public string NomeAluno { get; private set; }

        public MatricularAlunoCommand(Guid idTurma, Guid idAluno, string nomeAluno)
        {
            IdTurma = idTurma;
            IdAluno = idAluno;
            NomeAluno = nomeAluno;
        }

        public override bool EhValido()
        {
            ValidationResult = new MatricularAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class MatricularAlunoValidation : AbstractValidator<MatricularAlunoCommand>
    {
        public MatricularAlunoValidation()
        {
            RuleFor(t => t.IdTurma)
                .NotEmpty()
                .WithMessage("O id da turma não foi informado.");

            RuleFor(t => t.IdAluno)
                .NotEmpty()
                .WithMessage("O id do aluno não foi informado.");

            RuleFor(t => t.NomeAluno)
                .NotEmpty()
                .WithMessage("O nome do aluno não foi informado.");
        }
    }
}
