using FluentValidation;
using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Turmas.Application.Commands
{
    public class AbrirTurmaCommand : Command
    {
        public DateTime DataInicio { get; private set; }
        public Guid IdCurso { get; private set; }
        public string NomeCurso { get; private set; }

        public AbrirTurmaCommand(DateTime dataInicio, Guid idCurso, string nomeCurso)
        {
            DataInicio = dataInicio;
            IdCurso = idCurso;
            NomeCurso = nomeCurso;
        }

        public override bool EhValido()
        {
            ValidationResult = new AbrirTurmaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AbrirTurmaValidation : AbstractValidator<AbrirTurmaCommand>
    {
        public AbrirTurmaValidation()
        {
            RuleFor(t => t.DataInicio)
                .NotNull()
                .WithMessage("A data de início da turma não foi informada.");

            RuleFor(t => t.IdCurso)
                .NotEmpty()
                .WithMessage("O id do curso não foi informado.");

            RuleFor(t => t.NomeCurso)
                .NotEmpty()
                .WithMessage("O nome do curso não foi informado.");
        }
    }
}
