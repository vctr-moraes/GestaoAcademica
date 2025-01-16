using GestaoAcademica.Core.Messages;
using GestaoAcademica.Cursos.Domain.Interfaces;
using GestaoAcademica.Cursos.Domain.Models;
using MediatR;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class CursoCommandHandler : IRequestHandler<CadastrarCursoCommand, bool>,
                                       IRequestHandler<CadastrarDisciplinaCommand, bool>,
                                       IRequestHandler<VincularDisciplinaCommand, bool>,
                                       IRequestHandler<AtribuirProfessorCoordenadorCommand, bool>,
                                       IRequestHandler<AtribuirProfessorCommand, bool>
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoCommandHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<bool> Handle(CadastrarCursoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var curso = new Curso(
                message.Nome,
                message.Descricao,
                message.CargaHoraria,
                message.DataCriacao,
                (Grau)message.Grau,
                (Modalidade)message.Modalidade);

            _cursoRepository.Adicionar(curso);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(CadastrarDisciplinaCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var disciplina = new Disciplina(message.Nome, message.Descricao, message.CargaHoraria);

            _cursoRepository.AdicionarDisciplina(disciplina);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(VincularDisciplinaCommand message, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.ObterPorId(message.CursoId);
            var disciplina = await _cursoRepository.ObterDisciplinaPorId(message.DisciplinaId);

            if (curso == null || disciplina == null) return false;
            if (curso.CursosDisciplinas.Any(x => x.DisciplinaId == disciplina.Id)) return false;

            var cursoDisciplina = new CursosDisciplinas(curso, disciplina);

            curso.VincularDisciplina(cursoDisciplina);

            _cursoRepository.AdicionarCursoDisciplina(cursoDisciplina);
            _cursoRepository.Atualizar(curso);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AtribuirProfessorCoordenadorCommand message, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.ObterPorId(message.IdCurso);

            if (curso == null) return false;
            if (curso.IdProfessorCoordenador == message.IdProfessor) return false;

            curso.AtribuirProfessorCoordenador(message.IdProfessor, message.NomeProfessor);

            _cursoRepository.Atualizar(curso);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AtribuirProfessorCommand message, CancellationToken cancellationToken)
        {
            var disciplina = await _cursoRepository.ObterDisciplinaPorId(message.IdDisciplina);

            if (disciplina == null) return false;
            if (disciplina.IdProfessor == message.IdProfessor) return false;

            disciplina.AtribuirProfessor(message.IdProfessor, message.NomeProfessor);

            _cursoRepository.AtualizarDisciplina(disciplina);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            return false;
        }
    }
}
