using GestaoAcademica.Alunos.Application.Commands;
using GestaoAcademica.Alunos.Application.Interfaces;
using GestaoAcademica.Alunos.Application.Queries;
using GestaoAcademica.Alunos.Application.Services;
using GestaoAcademica.Alunos.Data;
using GestaoAcademica.Alunos.Data.Repository;
using GestaoAcademica.Alunos.Domain.Events;
using GestaoAcademica.Alunos.Domain.Interfaces;
using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Core.Messages.CommonMessages.IntegrationEvents;
using GestaoAcademica.Core.Messages.CommonMessages.Notifications;
using GestaoAcademica.Cursos.Application.Commands;
using GestaoAcademica.Cursos.Application.Queries;
using GestaoAcademica.Cursos.Data;
using GestaoAcademica.Cursos.Data.Repository;
using GestaoAcademica.Cursos.Domain.Interfaces;
using GestaoAcademica.Professores.Application.Commands;
using GestaoAcademica.Professores.Application.Queries;
using GestaoAcademica.Professores.Data;
using GestaoAcademica.Professores.Data.Repository;
using GestaoAcademica.Professores.Domain.Interfaces;
using GestaoAcademica.Turmas.Application.Commands;
using GestaoAcademica.Turmas.Application.Queries;
using GestaoAcademica.Turmas.Data;
using GestaoAcademica.Turmas.Data.Repository;
using GestaoAcademica.Turmas.Domain.Events;
using GestaoAcademica.Turmas.Domain.Interfaces;
using MediatR;

namespace GestaoAcademica.WebApi.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediatr
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Cursos
            services.AddScoped<CursoContext>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IRequestHandler<CadastrarCursoCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarCursoCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirCursoCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<CadastrarDisciplinaCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarDisciplinaCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirDisciplinaCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<VincularDisciplinaCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<DesvincularDisciplinaCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<AtribuirProfessorCoordenadorCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<DesvincularProfessorCoordenadorCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<AtribuirProfessorCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<DesvincularProfessorCommand, bool>, CursoCommandHandler>();
            services.AddScoped<ICursoQueries, CursoQueries>();

            // Professores
            services.AddScoped<ProfessorContext>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IRequestHandler<CadastrarProfessorCommand, bool>, ProfessorCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarProfessorCommand, bool>, ProfessorCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirProfessorCommand, bool>, ProfessorCommandHandler>();
            services.AddScoped<IProfessorQueries, ProfessorQueries>();

            // Alunos
            services.AddScoped<AlunoContext>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoAppService, AlunoAppService>();
            services.AddScoped<IRequestHandler<CadastrarAlunoCommand, bool>, AlunoCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirAlunoCommand, bool>, AlunoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarAlunoCommand, bool>, AlunoCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarStatusNovoAlunoMatriculadoEvent>, AlunoEventHandler>();
            services.AddScoped<IAlunoQueries, AlunoQueries>();

            // Turma
            services.AddScoped<TurmaContext>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IRequestHandler<AbrirTurmaCommand, bool>, TurmaCommandHandler>();
            services.AddScoped<IRequestHandler<MatricularAlunoCommand, bool>, TurmaCommandHandler>();
            services.AddScoped<INotificationHandler<NovoAlunoMatriculadoEvent>, TurmaEventHandler>();
            services.AddScoped<ITurmaQueries, TurmaQueries>();
        }
    }
}
