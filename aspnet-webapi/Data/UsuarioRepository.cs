using System.Collections.Generic;
using System.Linq;
using aspnet_webapi.Data.Models;

namespace aspnet_webapi.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static List<UsuarioEntidade> usuarios = new List<UsuarioEntidade>(); 
        public UsuarioRepository(IUsuarioFakeHelper usuarioFakeHelper)
        {
            usuarios.AddRange(usuarioFakeHelper.CriarUsuariosFake(3).ToList());
        }
        
        public IEnumerable<UsuarioEntidade> ListarTodos()
        {
            return usuarios;
        }

        public UsuarioEntidade ObterPeloId(int id)
        {
            return usuarios.FirstOrDefault(x => x.Id == id);
        }

        public void Salvar(UsuarioEntidade usuario)
        {
            if (usuario.Id == 0){
                usuario.Id = ObterProximoId();
            }
            else
            {
                var usuarioParaAlterar = usuarios.FirstOrDefault(x => x.Id == usuario.Id);
                usuarios.Remove(usuarioParaAlterar);
            }
            
            usuarios.Add(usuario);
        }

        private int ObterProximoId(){
            return usuarios.Max(x => x.Id) + 1;
        }
    }
}