using System.Collections.Generic;
using System.Linq;
using aspnet_webapi.Data.Models;

namespace aspnet_webapi.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        const int QUANTIDADE_INICIAL_USUARIOS = 100;
        private static List<UsuarioEntidade> usuarios = new List<UsuarioEntidade>();

        public UsuarioRepository(IUsuarioFakeHelper usuarioFakeHelper)
        {
            if(!usuarios.Any())
                usuarios.AddRange(usuarioFakeHelper.CriarUsuariosFake(QUANTIDADE_INICIAL_USUARIOS).ToList());
        }
        
        public IEnumerable<UsuarioEntidade> ListarTodos()
        {
            return usuarios.OrderBy(x => x.Id);
        }

        public UsuarioEntidade ObterPeloId(int id)
        {
            return usuarios.FirstOrDefault(x => x.Id == id);
        }

        public void Salvar(UsuarioEntidade usuario)
        {
            if(usuario.Id != 0)
            {
                var usuarioParaAlterar = usuarios.FirstOrDefault(x => x.Id == usuario.Id);
                usuarios.Remove(usuarioParaAlterar);
            }
            
            usuarios.Add(usuario);
        }
    }
}