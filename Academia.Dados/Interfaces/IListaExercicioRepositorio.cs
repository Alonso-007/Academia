using Academia.Dominio.Models;
using System.Threading.Tasks;

namespace Academia.Dados.Interfaces
{
    public interface IListaExercicioRepositorio : IRepositorioGenerico<ListaExercicio>
    {
        Task<bool> ExercicioExisteNaFicha(int exercicioId, int fichaId);
    }
}