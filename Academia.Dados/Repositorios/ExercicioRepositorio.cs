using Academia.Dados.Interfaces;
using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Academia.Dados.Repositorios
{
    public class ExercicioRepositorio : RepositorioGenerico<Exercicio>, IExercicioRepositorio
    {
        private readonly Contexto _contexto;

        public ExercicioRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> ExercicioExiste(string nome)
        {
            return await _contexto.Exercicios.AnyAsync(e => e.Nome == nome);
        }

        public async Task<bool> ExercicioExiste(string nome, int ExercicioId)
        {
            return await _contexto.Exercicios.AnyAsync(e => e.Nome == nome && e.ExercicioId == ExercicioId);
        }

        public new async Task<IEnumerable<Exercicio>> PegarTodos()
        {
            return await _contexto.Exercicios.Include(e => e.CategoriaExercicio).ToListAsync();
        }
    }
}