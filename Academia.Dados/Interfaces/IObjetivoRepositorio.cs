using Academia.Dominio.Models;
using System.Threading.Tasks;

namespace Academia.Dados.Interfaces
{
    public interface IObjetivoRepositorio : IRepositorioGenerico<Objetivo>
    {
        Task<bool> ObjetivoExiste(string nome);
        Task<bool> ObjetivoExiste(string nome, int objetivoId);
    }
}