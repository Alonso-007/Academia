using Academia.Dados.Interfaces;
using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Academia.Dados.Repositorios
{
    public class CategoriaExercicioRepositorio : RepositorioGenerico<CategoriaExercicio>, ICategoriaExercicioRepositorio
    {
        private readonly Contexto _contexto;

        public CategoriaExercicioRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> CategoriaExiste(string categoria)
        {
            return await _contexto.CategoriaExercicios
                .AnyAsync(ce => ce.Nome == categoria);
        }

        public async Task<bool> CategoriaExiste(string categoria, int categoriaExercicioId)
        {
            return await _contexto.CategoriaExercicios
                .AnyAsync(ce => ce.Nome == categoria && ce.CategoriaExercicioId != categoriaExercicioId);
        }
    }
}