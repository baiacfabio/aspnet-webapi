using System.Collections.Generic;
using aspnet_webapi.Data.Models;

namespace aspnet_webapi.Data
{
    public interface IUsuarioFakeHelper
    {
        IEnumerable<UsuarioEntidade> CriarUsuariosFake(int quantidade);
    }
}