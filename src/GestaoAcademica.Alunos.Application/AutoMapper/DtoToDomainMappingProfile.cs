using AutoMapper;
using GestaoAcademica.Alunos.Domain.Models;
using GestaoAcademica.WebApi.Dtos;

namespace GestaoAcademica.Alunos.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<AlunoCreateEditDto, Aluno>();
        }
    }
}
