using System.Collections.Generic;
using aspnet_webapi.Models;

namespace aspnet_webapi.Services
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioListagem> ListarTodos();
        UsuarioListagem ObterPeloId(int id);
        void Salvar(Usuario usuario);
    }
}