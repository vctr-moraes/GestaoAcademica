using GestaoAcademica.Turmas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoAcademica.Turmas.Data.Mappings
{
    public class AlunoCursanteMapping : IEntityTypeConfiguration<AlunoCursante>
    {
        public void Configure(EntityTypeBuilder<AlunoCursante> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .Property(a => a.IdAluno)
                .IsRequired();

            builder
                .Property(a => a.NomeAluno)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(a => a.DataEntrada)
                .IsRequired()
                .HasColumnType("date");

            builder
                .Property(a => a.DataSaida)
                .HasColumnType("date");

            builder.ToTable("AlunosCursantes");
        }
    }
}
