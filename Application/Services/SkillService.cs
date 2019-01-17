using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.IServices;
//using CodiJobService.Model.CodiJobDb;
using Domain;
//using CodiJobService.Model.Repositories;
using Domain.IRepositories;
namespace Application.Services
{
    public class SkillService : ISkillService
    {
        ISkillRepository repository;
        public SkillService(ISkillRepository service)
        {
            repository = service;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<SkillDTO> GetAll()
        {
            IQueryable<TSkill> skillEntities = repository.Items;

            return Builders.
                GenericBuilder.
                builderListEntityDTO<SkillDTO, TSkill>
                (skillEntities);
        }
        public void Insert(SkillDTO entityDTO)
        {
            TSkill entity = Builders.
                GenericBuilder.builderDTOEntity<TSkill, SkillDTO>
                (entityDTO);
            repository.Save(entity);
        }
        public void Update(SkillDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.builderDTOEntity<TSkill, SkillDTO>
                (entityDTO);
            repository.Save(entity);
        }
    }
}
