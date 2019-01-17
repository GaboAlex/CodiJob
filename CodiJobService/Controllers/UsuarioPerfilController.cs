using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using CodiJobService.Model.CodiJobDb;
using Domain;

using Microsoft.AspNetCore.Mvc;
using Application.IServices;
using Application;

namespace CodiJobService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioPerfilController :Controller
    {
        IUsuarioPerfilService Service;
        public UsuarioPerfilController(IUsuarioPerfilService service)
        {
            this.Service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<UsuarioPerfilDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{UsuarioPerfilId}")]
        public UsuarioPerfilDTO Get(Guid UsuarioPerfilId)
        {
            return Service.GetAll().Where(p => p.UsuperId == UsuarioPerfilId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]UsuarioPerfilDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model is not Valid");
            }
            Service.Insert(usuario);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{UsuarioPerfilId}")]
        public IActionResult Put(Guid usuarioPerfilId, [FromBody]UsuarioPerfilDTO usuario)
        {
            usuario.UsuperId = usuarioPerfilId;
            Service.Update(usuario);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{UsuarioPerfilId}")]
        public IActionResult Delete(Guid UsuarioPerfilId)
        {
            Service.Delete(UsuarioPerfilId);
            return Ok(true);
        }
    }
}
