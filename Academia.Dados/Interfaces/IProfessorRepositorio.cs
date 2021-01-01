using Academia.Dominio.Models;
using System.Threading.Tasks;

namespace Academia.Dados.Interfaces
{
    public interface IProfessorRepositorio : IRepositorioGenerico<Professor>
    {
        Task<bool> ProfessorExiste(string nome);
        Task<bool> ProfessorExiste(string nome, int professorId);
    }
}