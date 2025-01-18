using GestaoAcademica.Turmas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoAcademica.Turmas.Data.Mappings
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.DataInicio)
                .IsRequired()
                .HasColumnType("date");

            builder
                .Property(t => t.DataEncerramento)
                .IsRequired()
                .HasColumnType("date");

            builder
                .Property(t => t.NomeCurso)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .HasMany(t => t.Alunos)
                .WithOne(a => a.Turma)
                .HasForeignKey(a => a.IdTurma);

            builder.ToTable("Turmas");
        }
    }
}
