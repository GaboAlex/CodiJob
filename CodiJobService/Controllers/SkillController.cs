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
    public class SkillController : Controller
    {/*
        private ISkillRepository repositorio;
        public SkillController(ISkillRepository repo)
        {
            this.repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TSkill> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{SkillId}")]
        public TSkill Get(Guid SkillID)
        {
            return repositorio.Items.Where(p => p.SkillId == SkillID).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]TSkill skill)
        {
            repositorio.Save(skill);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{SkillId}")]
        public IActionResult Put(Guid SkillID, [FromBody]TSkill skill)
        {
            skill.SkillId = SkillID;
            repositorio.Save(skill);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{SkillId}")]
        public IActionResult Delete(Guid SkillId)
        {
            repositorio.Delete(SkillId);
            return Ok(true);
        }*/

        ISkillService Service;
        public SkillController(ISkillService service)
        {
            this.Service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<SkillDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{SkillId}")]
        public SkillDTO Get(Guid SkillID)
        {
            return Service.GetAll().Where(p => p.SkillId == SkillID).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]SkillDTO skill)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model is not Valid");
            }
            Service.Insert(skill);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{SkillId}")]
        public IActionResult Put(Guid SkillID, [FromBody]SkillDTO skill)
        {
            skill.SkillId = SkillID;
            Service.Update(skill);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{SkillId}")]
        public IActionResult Delete(Guid SkillID)
        {
            Service.Delete(SkillID);
            return Ok(true);
        }
    }
}