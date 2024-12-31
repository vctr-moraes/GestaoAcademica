using GestaoAcademica.Core.Data;
using GestaoAcademica.Turmas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcademica.Turmas.Data
{
    public class TurmaContext : DbContext, IUnitOfWork
    {
        public TurmaContext(DbContextOptions<TurmaContext> options) : base(options) { }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<AlunoCursante> AlunosCursantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TurmaContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Cascade;

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataInicio") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInicio").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataInicio").IsModified = false;
                }
            }

            var sucesso = await base.SaveChangesAsync() > 0;

            return sucesso;
        }
    }
}
