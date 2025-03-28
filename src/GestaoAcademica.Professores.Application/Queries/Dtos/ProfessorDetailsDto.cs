﻿namespace GestaoAcademica.Professores.Application.Queries.Dtos
{
    public class ProfessorDetailsDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
