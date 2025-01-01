using GestaoAcademica.Cursos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoAcademica.Cursos.Data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(c => c.CargaHoraria)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(c => c.NomeProfessorCoordenador)
                .IsRequired(false)
                .HasColumnType("varchar(100)");

            builder
                .Property(a => a.DataCriacao)
                .IsRequired()
                .HasColumnType("date");

            builder
                .HasMany(c => c.CursosDisciplinas)
                .WithOne(d => d.Curso)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Cursos");
        }
    }
}
