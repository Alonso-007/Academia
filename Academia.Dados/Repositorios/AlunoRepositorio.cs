using Academia.Dados.Interfaces;
using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Dados.Repositorios
{
    public class AlunoRepositorio : RepositorioGenerico<Aluno>, IAlunoRepositorio
    {
        private readonly Contexto _contexto;

        public AlunoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> AlunoExiste(string nomeCompleto)
        {
            return await _contexto.Alunos.AnyAsync(a => a.NomeCompleto == nomeCompleto);
        }

        public async Task<bool> AlunoExiste(string nomeCompleto, int alunoId)
        {
            return await _contexto.Alunos.AnyAsync(a => a.NomeCompleto == nomeCompleto && a.AlunoId != alunoId);
        }

        public string PegarNomeAlunoPeloId(int id)
        {
            return _contexto.Alunos.Where(a => a.AlunoId == id).Select(a => a.NomeCompleto).First();
        }

        public async Task<Aluno> PegrDadosAlunoPeloId(int alunoId)
        {
            return await _contexto.Alunos.Include(a => a.Objetivo).Include(a => a.Professor)
                .Where(a => a.AlunoId == alunoId).FirstAsync();
        }

        public new async Task<IEnumerable<Aluno>> PegarTodos()
        {
            return await _contexto.Alunos.Include(a => a.Objetivo).Include(a => a.Professor).ToListAsync();
        }
    }
}