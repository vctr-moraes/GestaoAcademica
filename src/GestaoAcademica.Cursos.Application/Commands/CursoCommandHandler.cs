﻿using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Cursos.Domain.Interfaces;
using GestaoAcademica.Cursos.Domain.Models;
using MediatR;

namespace GestaoAcademica.Cursos.Application.Commands
{
    public class CursoCommandHandler : IRequestHandler<CadastrarCursoCommand, bool>,
                                       IRequestHandler<AtualizarCursoCommand, bool>,
                                       IRequestHandler<CadastrarDisciplinaCommand, bool>,
                                       IRequestHandler<AtualizarDisciplinaCommand, bool>,
                                       IRequestHandler<VincularDisciplinaCommand, bool>,
                                       IRequestHandler<DesvincularDisciplinaCommand, bool>,
                                       IRequestHandler<AtribuirProfessorCoordenadorCommand, bool>,
                                       IRequestHandler<DesvincularProfessorCoordenadorCommand, bool>,
                                       IRequestHandler<AtribuirProfessorCommand, bool>,
                                       IRequestHandler<DesvincularProfessorCommand, bool>,
                                       IRequestHandler<ExcluirCursoCommand, bool>,
                                       IRequestHandler<ExcluirDisciplinaCommand, bool>
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public CursoCommandHandler(ICursoRepository cursoRepository, IMediatorHandler mediatorHandler)
        {
            _cursoRepository = cursoRepository;
            _mediatorHandler = mediatorHandler;
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

        public async Task<bool> Handle(AtualizarCursoCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var curso = await _cursoRepository.ObterPorId(message.Id);

            if (curso == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("curso", "Curso não encontrado."));
                return false;
            }

            curso.AtualizarCurso(
                message.Nome,
                message.Descricao,
                message.CargaHoraria,
                message.DataCriacao,
                (Grau)message.Grau,
                (Modalidade)message.Modalidade);

            _cursoRepository.Atualizar(curso);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(ExcluirCursoCommand message, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.ObterPorId(message.CursoId);

            if (curso == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("curso", "Curso não encontrado."));
                return false;
            }

            _cursoRepository.Excluir(curso);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(CadastrarDisciplinaCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var disciplina = new Disciplina(message.Nome, message.Descricao, message.CargaHoraria);

            _cursoRepository.AdicionarDisciplina(disciplina);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AtualizarDisciplinaCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            var disciplina = await _cursoRepository.ObterDisciplinaPorId(message.Id);

            if (disciplina == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("disciplina", "Disciplina não encontrada."));
                return false;
            }

            disciplina.AtualizarDisciplina(message.Nome, message.Descricao, message.CargaHoraria);

            _cursoRepository.AtualizarDisciplina(disciplina);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(ExcluirDisciplinaCommand message, CancellationToken cancellationToken)
        {
            var disciplina = await _cursoRepository.ObterDisciplinaPorId(message.DisciplinaId);

            if (disciplina == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("disciplina", "Disciplina não encontrada."));
                return false;
            }

            if (disciplina.CursosDisciplinas?.DisciplinaId == message.DisciplinaId)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("disciplina", "A disciplina não pode ser excluída, pois está vinculada a um curso."));
                return false;
            }

            _cursoRepository.ExcluirDisciplina(disciplina);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(VincularDisciplinaCommand message, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.ObterPorId(message.CursoId);
            var disciplina = await _cursoRepository.ObterDisciplinaPorId(message.DisciplinaId);

            if (curso == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("curso", "Curso não encontrado."));
                return false;
            }

            if (disciplina == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("disciplina", "Disciplina não encontrada."));
                return false;
            }

            if (curso.CursosDisciplinas.Any(x => x.DisciplinaId == disciplina.Id)) return false;

            var cursoDisciplina = new CursosDisciplinas(curso, disciplina);

            curso.VincularDisciplina(cursoDisciplina);

            _cursoRepository.AdicionarCursoDisciplina(cursoDisciplina);
            _cursoRepository.Atualizar(curso);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(DesvincularDisciplinaCommand message, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.ObterPorId(message.CursoId);
            var cursoDisciplina = await _cursoRepository.ObterCursoDisciplina(message.CursoId, message.DisciplinaId);

            if (curso == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("curso", "Curso não encontrado."));
                return false;
            }

            if (cursoDisciplina == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("disciplina", "Disciplina não encontrada."));
                return false;
            }

            if (!curso.CursosDisciplinas.Any(x => x.DisciplinaId == message.DisciplinaId))
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("disciplina", "Disciplina não possui vínculo com o curso informado."));
                return false;
            }

            curso.DesvincularDisciplina(cursoDisciplina);

            _cursoRepository.RemoverCursoDisciplina(cursoDisciplina);
            _cursoRepository.Atualizar(curso);

            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AtribuirProfessorCoordenadorCommand message, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.ObterPorId(message.IdCurso);

            if (curso == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("curso", "Curso não encontrado."));
                return false;
            }

            if (curso.IdProfessorCoordenador == message.IdProfessor)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("professor", "Professor já é coordenador do curso informado."));
                return false;
            }

            curso.AtribuirProfessorCoordenador(message.IdProfessor, message.NomeProfessor);

            _cursoRepository.Atualizar(curso);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(DesvincularProfessorCoordenadorCommand message, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.ObterPorId(message.IdCurso);

            if (curso == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("curso", "Curso não encontrado."));
                return false;
            }

            if (curso.IdProfessorCoordenador != message.IdProfessor)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("professor", "Professor não é coordenador do curso informado."));
                return false;
            }

            curso.DesvincularProfessorCoordenador(message.IdProfessor);

            _cursoRepository.Atualizar(curso);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AtribuirProfessorCommand message, CancellationToken cancellationToken)
        {
            var disciplina = await _cursoRepository.ObterDisciplinaPorId(message.IdDisciplina);

            if (disciplina == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("disciplina", "Disciplina não encontrada."));
                return false;
            }

            if (disciplina.IdProfessor == message.IdProfessor)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("professor", "Professor já atribuído à disciplina informada."));
                return false;
            }

            disciplina.AtribuirProfessor(message.IdProfessor, message.NomeProfessor);

            _cursoRepository.AtualizarDisciplina(disciplina);
            return await _cursoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(DesvincularProfessorCommand message, CancellationToken cancellationToken)
        {
            var disciplina = await _cursoRepository.ObterDisciplinaPorId(message.IdDisciplina);

            if (disciplina == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("disciplina", "Disciplina não encontrada."));
                return false;
            }

            if (disciplina.IdProfessor != message.IdProfessor)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("professor", "Professor não está atribuído à disciplina informada."));
                return false;
            }

            disciplina.DesvincularProfessor(message.IdProfessor);

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
