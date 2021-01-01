using Academia.Dados.Interfaces;
using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Dados.Repositorios
{
    public class FichaRepositorio : RepositorioGenerico<Ficha>, IFichaRepositorio
    {
        private readonly Contexto _contexto;

        public FichaRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> FichaExiste(string nome)
        {
            return await _contexto.Fichas.AnyAsync(f => f.Nome == nome);
        }

        public async Task<bool> FichaExiste(string nome, int fichaId)
        {
            return await _contexto.Fichas.AnyAsync(f => f.Nome == nome && f.FichaId != fichaId);
        }

        public async Task<Ficha> PegarFichaAlunoPeloId(int id)
        {
            return await _contexto.Fichas.Include(f => f.Aluno).FirstOrDefaultAsync(f => f.FichaId == id);
        }

        public async Task<IEnumerable<Ficha>> PegarTodasFichasPeloAlunoId(int id)
        {
            return await _contexto.Fichas.Include(f => f.Aluno)
                .ThenInclude(f => f.Objetivo).Where(f => f.AlunoId == id).ToListAsync();
                
        }
    }
}