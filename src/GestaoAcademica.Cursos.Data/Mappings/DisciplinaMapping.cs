using GestaoAcademica.Cursos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoAcademica.Cursos.Data.Mappings
{
    public class DisciplinaMapping : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .Property(d => d.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(d => d.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(d => d.CargaHoraria)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(d => d.Professor)
                .IsRequired(false)
                .HasColumnType("varchar(100)");

            builder.ToTable("Disciplinas");
        }
    }
}
