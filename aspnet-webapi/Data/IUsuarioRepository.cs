using System.Collections.Generic;
using aspnet_webapi.Data.Models;

namespace aspnet_webapi.Data
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioEntidade> ListarTodos();
        UsuarioEntidade ObterPeloId(int id);
        void Salvar(UsuarioEntidade usuario);
    }
}