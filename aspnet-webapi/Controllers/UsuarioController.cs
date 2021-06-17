using System;
using System.Collections.Generic;
using aspnet_webapi.Models;
using aspnet_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_webapi.Controllers
{
    [ApiController]
    [Route("v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<UsuarioListagem>> Get()
        {
            var usuarios = usuarioService.ListarTodos();

            return Ok(usuarios);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Post([FromBody]Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                usuarioService.Salvar(usuario);
                return Ok(usuario);//todo: retornar created
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}