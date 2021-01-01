using Academia.Dados.Mapeamentos;
using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia.Dados
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<CategoriaExercicio> CategoriaExercicios { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<ListaExercicio> ListasExercicios { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdministradoresMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new CategoriaExercicioMap());
            modelBuilder.ApplyConfiguration(new ExercicioMap());
            modelBuilder.ApplyConfiguration(new FichaMap());
            modelBuilder.ApplyConfiguration(new ObjetivoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
        }
    }
}