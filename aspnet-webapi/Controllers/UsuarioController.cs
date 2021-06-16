using System.Collections.Generic;
using aspnet_webapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_webapi.Controllers
{
    [ApiController]
    [Route("v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<List<Usuario>> Get()
        {
            var usuarios = RetornarUsuariosFake();

            return usuarios;
        }

        private static List<Usuario> RetornarUsuariosFake()
        {
            return new List<Usuario>
            {
                new Usuario("Fabio Cezar Baía", "baiacfabio@gmail.com", 31),
                new Usuario("Stela Massanares Pradella Baía", "stela@email.com", 32),
                new Usuario("Flavio Sidnei Baía", "flavio@email.com", 28),
                new Usuario("João José da Silva", "joao@email.com", 25)
            };
        }
    }
}