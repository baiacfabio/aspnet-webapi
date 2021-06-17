using System.Collections.Generic;
using aspnet_webapi.Models;

namespace aspnet_webapi.Services
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioListagem> ListarTodos();
        void Salvar(Usuario usuario);
    }
}