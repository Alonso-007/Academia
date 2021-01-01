using Academia.Dados.Interfaces;
using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Academia.Dados.Repositorios
{
    public class ListaExercicioRepositorio : RepositorioGenerico<ListaExercicio>, IListaExercicioRepositorio
    {
        private readonly Contexto _contexto;

        public ListaExercicioRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> ExercicioExisteNaFicha(int exercicioId, int fichaId)
        {
            return await _contexto.ListasExercicios.AnyAsync(e => e.ExercicioId == exercicioId && e.FichaId == fichaId);
        }
    }
}