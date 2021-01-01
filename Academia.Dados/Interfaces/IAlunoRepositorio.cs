using Academia.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Academia.Dados.Interfaces
{
    public interface IAlunoRepositorio : IRepositorioGenerico<Aluno>
    {
        new Task<IEnumerable<Aluno>> PegarTodos();
        string PegarNomeAlunoPeloId(int id);
        Task<Aluno> PegrDadosAlunoPeloId(int alunoId);
        Task<bool> AlunoExiste(string nomeCompleto);
        Task<bool> AlunoExiste(string nomeCompleto, int alunoId);
    }
}