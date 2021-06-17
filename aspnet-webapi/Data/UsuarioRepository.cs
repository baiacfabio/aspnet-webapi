using System.Collections.Generic;
using System.Linq;
using aspnet_webapi.Data.Models;

namespace aspnet_webapi.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IList<UsuarioEntidade> usuarios; 
        public UsuarioRepository(IUsuarioFakeHelper usuarioFakeHelper)
        {
            usuarios = usuarioFakeHelper.CriarUsuariosFake(100).ToList();
        }
        
        public IEnumerable<UsuarioEntidade> ListarTodos()
        {
            return usuarios;
        }

        public void Salvar(UsuarioEntidade usuario)
        {
            if (usuario.Id == 0){
                usuario.Id = ObterProximoId();
            }
            else
            {
                var usuarioParaAlterar = this.usuarios.FirstOrDefault(x => x.Id == usuario.Id);
                this.usuarios.Remove(usuarioParaAlterar);
            }
            
            this.usuarios.Add(usuario);
        }

        private int ObterProximoId(){
            return usuarios.Max(x => x.Id) + 1;
        }
    }
}