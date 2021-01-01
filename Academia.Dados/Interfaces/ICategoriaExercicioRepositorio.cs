using Academia.Dominio.Models;
using System.Threading.Tasks;

namespace Academia.Dados.Interfaces
{
    public interface ICategoriaExercicioRepositorio : IRepositorioGenerico<CategoriaExercicio>
    {
        Task<bool> CategoriaExiste(string categoria);
        Task<bool> CategoriaExiste(string categoria, int categoriaExercicioId);
    }
}