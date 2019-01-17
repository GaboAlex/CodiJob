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
    public class GrupoService : IGrupoService
    {
        IGrupoRepository repository;
        public GrupoService(IGrupoRepository service)
        {
            repository = service;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<GrupoDTO> GetAll()
        {
            IQueryable<TGrupo> gruposEntities = repository.Items;

            return Builders.
                GenericBuilder.
                builderListEntityDTO<GrupoDTO, TGrupo>
                (gruposEntities);
        }
        public void Insert(GrupoDTO entityDTO)
        {
            TGrupo entity = Builders.
                GenericBuilder.builderDTOEntity<TGrupo, GrupoDTO>
                (entityDTO);
            repository.Save(entity);
        }
        public void Update(GrupoDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.builderDTOEntity<TGrupo, GrupoDTO>
                (entityDTO);
            repository.Save(entity);
        }
    }
}
