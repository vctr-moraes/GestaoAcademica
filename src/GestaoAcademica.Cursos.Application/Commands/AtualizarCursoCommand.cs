using FluentValidation;
using GestaoAcademica.Core.Messages;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class AtualizarCursoCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string CargaHoraria { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public int Grau { get; private set; }
        public int Modalidade { get; private set; }

        public AtualizarCursoCommand(
            Guid id,
            string nome,
            string descricao,
            string cargaHoraria,
            DateTime dataCriacao,
            int grau,
            int modalidade)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            DataCriacao = dataCriacao;
            Grau = grau;
            Modalidade = modalidade;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarCursoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarCursoValidation : AbstractValidator<AtualizarCursoCommand>
    {
        public AtualizarCursoValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do curso não foi informado.");

            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("A descrição do curso não foi informada.");

            RuleFor(c => c.CargaHoraria)
                .NotEmpty()
                .WithMessage("A carga horária do curso não foi informada.");

            RuleFor(c => c.DataCriacao)
                .NotNull()
                .WithMessage("A data de criação do curso não foi informada.");

            RuleFor(c => c.Grau)
                .GreaterThan(0)
                .WithMessage("O grau do curso não foi informado.");

            RuleFor(c => c.Modalidade)
                .GreaterThan(0)
                .WithMessage("A modalidade do curso não foi informada.");
        }
    }
}
