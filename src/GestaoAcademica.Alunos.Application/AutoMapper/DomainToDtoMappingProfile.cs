using AutoMapper;
using GestaoAcademica.Alunos.Domain.Models;
using GestaoAcademica.WebApi.Dtos;

namespace GestaoAcademica.Alunos.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Aluno, AlunoCreateEditDto>();
        }
    }
}
