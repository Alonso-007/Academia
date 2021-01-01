using Academia.Dados.Interfaces;
using Academia.Dominio.Models;
using System.Linq;

namespace Academia.Dados.Repositorios
{
    public class AdministradorRepositorio : RepositorioGenerico<Administrador>, IAdministradorRepositorio
    {
        private readonly Contexto _contexto;

        public AdministradorRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public bool AdministradorExiste(string email, string senha)
        {
            return _contexto.Administradores.Any(a => a.Email == email && a.Senha == senha);
        }
    }
}