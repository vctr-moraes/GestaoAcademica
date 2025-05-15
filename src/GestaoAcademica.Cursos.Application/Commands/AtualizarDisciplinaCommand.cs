using FluentValidation;
using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class AtualizarDisciplinaCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string CargaHoraria { get; private set; }

        public AtualizarDisciplinaCommand(Guid id, string nome, string descricao, string cargaHoraria)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarDisciplinaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarDisciplinaValidation : AbstractValidator<AtualizarDisciplinaCommand>
    {
        public AtualizarDisciplinaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome da disciplina não foi informado.");

            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("A descrição da disciplina não foi informada.");

            RuleFor(c => c.CargaHoraria)
                .NotEmpty()
                .WithMessage("A carga horária da disciplina não foi informada.");
        }
    }
}
