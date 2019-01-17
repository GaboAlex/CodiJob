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
    public class GrupoController : Controller
    {/*
        private IGrupoRepository repositorio;
        public GrupoController(IGrupoRepository repo)
        {
            this.repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TGrupo> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{GrupoId}")]
        public TGrupo Get(Guid GrupoID)
        {
            return repositorio.Items.Where(p => p.Id == GrupoID).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]TGrupo grupo)
        {
            repositorio.Save(grupo);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{GrupoID}")]
        public IActionResult Put(Guid GrupoID, [FromBody]TGrupo grupo)
        {
            grupo.Id = GrupoID;
            repositorio.Save(grupo);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{GrupoID}")]
        public IActionResult Delete(Guid GrupoID)
        {
            repositorio.Delete(GrupoID);
            return Ok(true);
        }
        
     */
        IGrupoService Service;
        public GrupoController(IGrupoService service)
        {
            this.Service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<GrupoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{GrupoId}")]
        public GrupoDTO Get(Guid GrupoID)
        {
            return Service.GetAll().Where(p => p.Id == GrupoID).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]GrupoDTO grupo)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model is not Valid");
            }
            Service.Insert(grupo);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{GrupoId}")]
        public IActionResult Put(Guid GrupoID, [FromBody]GrupoDTO grupo)
        {
            grupo.Id = GrupoID;
            Service.Update(grupo);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{GrupoId}")]
        public IActionResult Delete(Guid GrupoID)
        {
            Service.Delete(GrupoID);
            return Ok(true);
        }
    }
}
