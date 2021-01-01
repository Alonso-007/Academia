using Academia.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Academia.Dados.Interfaces
{
    public interface IExercicioRepositorio : IRepositorioGenerico<Exercicio>
    {
        new Task<IEnumerable<Exercicio>> PegarTodos();
        Task<bool> ExercicioExiste(string nome);
        Task<bool> ExercicioExiste(string nome, int ExercicioId);
    }
}