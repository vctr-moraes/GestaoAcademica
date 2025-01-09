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

            // Professores
            services.AddScoped<ProfessorContext>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IRequestHandler<CadastrarProfessorCommand, bool>, ProfessorCommandHandler>();
        }
    }
}
