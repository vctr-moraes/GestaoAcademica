using FluentValidation;
using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class CadastrarDisciplinaCommand : Command
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string CargaHoraria { get; private set; }

        public CadastrarDisciplinaCommand(string nome, string descricao, string cargaHoraria)
        {
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
        }

        public override bool EhValido()
        {
            ValidationResult = new CadastrarDisciplinaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarDisciplinaValidation : AbstractValidator<CadastrarDisciplinaCommand>
    {
        public CadastrarDisciplinaValidation()
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
