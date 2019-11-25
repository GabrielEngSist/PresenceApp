using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Presence.API.Domain;

namespace Presence.API.Data
{

    public class DataContext : IdentityDbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AlunoClasse>()
                .HasKey(ac => new { ac.AlunoId, ac.ClasseId });

            modelBuilder.Entity<AlunoClasse>()
                .HasOne(ac => ac.Aluno)
                .WithMany(a => a.AlunoClasse)
                .HasForeignKey(ac => ac.AlunoId);

            modelBuilder.Entity<AlunoClasse>()
                .HasOne(ac => ac.Classe)
                .WithMany(c => c.AlunoClasse)
                .HasForeignKey(sc => sc.ClasseId);
        }

        public DbSet<Presenca> Presencas { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Instituicao> Instituicoes { get; set; }

        public DbSet<Classe> Classes { get; set; }

        public DbSet<AlunoClasse> AlunosClasses { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
