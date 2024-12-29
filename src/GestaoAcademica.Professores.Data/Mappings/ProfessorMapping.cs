using GestaoAcademica.Professores.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoAcademica.Professores.Data.Mappings
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(p => p.NumeroDocumento)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(p => p.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder
                .Property(p => p.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder
                .OwnsOne(p => p.Endereco, endereco =>
                {
                    endereco
                        .Property(e => e.Logradouro)
                        .HasColumnName("Logradouro")
                        .HasColumnType("varchar(100)");

                    endereco
                        .Property(e => e.Bairro)
                        .HasColumnName("Bairro")
                        .HasColumnType("varchar(100)");

                    endereco
                        .Property(e => e.Cidade)
                        .HasColumnName("Cidade")
                        .HasColumnType("varchar(100)");

                    endereco
                        .Property(e => e.Pais)
                        .HasColumnName("Pais")
                        .HasColumnType("varchar(100)");

                    endereco
                        .Property(e => e.Cep)
                        .HasColumnName("Cep")
                        .HasColumnType("varchar(100)");

                    endereco
                        .Property(e => e.Referencia)
                        .HasColumnName("Referencia")
                        .HasColumnType("varchar(100)");
                });

            builder.ToTable("Professores");
        }
    }
}
