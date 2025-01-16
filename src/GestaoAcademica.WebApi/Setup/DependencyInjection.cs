using GestaoAcademica.Alunos.Application.Commands;
using GestaoAcademica.Alunos.Data;
using GestaoAcademica.Alunos.Data.Repository;
using GestaoAcademica.Alunos.Domain.Interfaces;
using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Cursos.Application.Commands;
using GestaoAcademica.Cursos.Data;
using GestaoAcademica.Cursos.Data.Repository;
using GestaoAcademica.Cursos.Domain.Interfaces;
using GestaoAcademica.Professores.Application.Commands;
using GestaoAcademica.Professores.Data;
using GestaoAcademica.Professores.Data.Repository;
using GestaoAcademica.Professores.Domain.Interfaces;
using MediatR;

namespace GestaoAcademica.WebApi.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediatr
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Cursos
            services.AddScoped<CursoContext>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IRequestHandler<CadastrarCursoCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<CadastrarDisciplinaCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<VincularDisciplinaCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<AtribuirProfessorCoordenadorCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<AtribuirProfessorCommand, bool>, CursoCommandHandler>();

            // Professores
            services.AddScoped<ProfessorContext>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IRequestHandler<CadastrarProfessorCommand, bool>, ProfessorCommandHandler>();

            // Alunos
            services.AddScoped<AlunoContext>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IRequestHandler<CadastrarAlunoCommand, bool>, AlunoCommandHandler>();
        }
    }
}
