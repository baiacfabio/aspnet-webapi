using System.Collections.Generic;
using System.Linq;
using aspnet_webapi.Data;
using aspnet_webapi.Models;
using aspnet_webapi.Data.Models;

namespace aspnet_webapi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository repositorioUsuario;

        public UsuarioService(IUsuarioRepository repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }
        
        public IEnumerable<UsuarioListagem> ListarTodos()
        {
            return repositorioUsuario.ListarTodos()
                .Select(x => new UsuarioListagem
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Idade = x.Idade
                } );
        }

        public void Salvar(Usuario usuario)
        {
            var usuarioEntidade = new UsuarioEntidade(usuario.Nome, usuario.Email, usuario.DataNascimento);

            this.repositorioUsuario.Salvar(usuarioEntidade);
        }
    }
}