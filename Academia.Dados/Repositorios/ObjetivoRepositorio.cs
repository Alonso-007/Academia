using Academia.Dados.Interfaces;
using Academia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Academia.Dados.Repositorios
{
    public class ObjetivoRepositorio : RepositorioGenerico<Objetivo>, IObjetivoRepositorio
    {
        private readonly Contexto _contexto;

        public ObjetivoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> ObjetivoExiste(string nome)
        {
            return await _contexto.Objetivos.AnyAsync(o => o.Nome == nome);
        }

        public async Task<bool> ObjetivoExiste(string nome, int objetivoId)
        {
            return await _contexto.Objetivos.AnyAsync(o => o.Nome == nome && o.ObjetivoId != objetivoId);
        }
    }
}