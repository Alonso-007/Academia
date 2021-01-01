using Academia.Dominio.Models;

namespace Academia.Dados.Interfaces
{
    public interface IAdministradorRepositorio: IRepositorioGenerico<Administrador>
    {
        bool AdministradorExiste(string email, string senha);
    }
}