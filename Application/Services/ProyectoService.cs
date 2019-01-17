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
    public class ProyectoService : IProyectoService
    {
        IProyectoRepository repository;
        public ProyectoService(IProyectoRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<ProyectoDTO> GetAll()
        {
            IQueryable<TProyecto> proyectosEntities = repository.Items;

            return Builders.
                GenericBuilder.
                builderListEntityDTO<ProyectoDTO, TProyecto>
                (proyectosEntities);
        }
        public void Insert(ProyectoDTO entityDTO)
        {
            TProyecto entity = Builders.
                GenericBuilder.builderDTOEntity<TProyecto, ProyectoDTO>
                (entityDTO);
            repository.Save(entity);
        }
        public void Update(ProyectoDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.builderDTOEntity<TProyecto, ProyectoDTO>
                (entityDTO);
            repository.Save(entity);
        }
    }
}
