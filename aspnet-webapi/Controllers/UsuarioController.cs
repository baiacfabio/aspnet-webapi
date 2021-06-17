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

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<IEnumerable<UsuarioListagem>> Get([FromRoute]int id)
        {
            try
            {
                var usuario = usuarioService.ObterPeloId(id);
                return Ok(usuario);
            }
            catch(ArgumentNullException)
            {
                return NotFound("Usuário não foi encontrado.");
            }
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
                return Ok();//todo: retornar created
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("")]
        public ActionResult Put([FromBody]Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                usuarioService.Salvar(usuario);
                return Ok();
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}