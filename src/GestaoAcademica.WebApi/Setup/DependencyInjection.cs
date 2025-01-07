using GestaoAcademica.Core.Communication.Mediator;
using GestaoAcademica.Cursos.Application.Commands;
using GestaoAcademica.Cursos.Data;
using GestaoAcademica.Cursos.Data.Repository;
using GestaoAcademica.Cursos.Domain.Interfaces;
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
        }
    }
}
