using Academia.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Academia.Dados.Interfaces
{
    public interface IFichaRepositorio : IRepositorioGenerico<Ficha>
    {
        Task<IEnumerable<Ficha>> PegarTodasFichasPeloAlunoId(int id);
        Task<Ficha> PegarFichaAlunoPeloId(int id);
        Task<bool> FichaExiste(string nome);
        Task<bool> FichaExiste(string nome, int fichaId);
    }
}