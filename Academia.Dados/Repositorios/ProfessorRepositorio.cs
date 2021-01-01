using Academia.Dados.Interfaces;
using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Academia.Dados.Repositorios
{
    public class ProfessorRepositorio : RepositorioGenerico<Professor>, IProfessorRepositorio
    {
        private readonly Contexto _contexto;

        public ProfessorRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> ProfessorExiste(string nome)
        {
            return await _contexto.Professores.AnyAsync(p => p.Nome == nome);
        }

        public async Task<bool> ProfessorExiste(string nome, int professorId)
        {
            return await _contexto.Professores.AnyAsync(p => p.Nome == nome && p.ProfessorId != professorId);
        }
    }
}