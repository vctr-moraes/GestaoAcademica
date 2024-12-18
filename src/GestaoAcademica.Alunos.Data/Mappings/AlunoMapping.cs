using GestaoAcademica.Alunos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoAcademica.Alunos.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(a => a.NumeroDocumento)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(a => a.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder
                .Property(a => a.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder
                .Property(a => a.NomePai)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .Property(a => a.NomeMae)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder
                .OwnsOne(a => a.Endereco, endereco =>
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

            builder.ToTable("Alunos");
        }
    }
}
