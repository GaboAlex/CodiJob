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
    public class UsuarioPerfilService :IUsuarioPerfilService
    {
        IUsuarioPerfilRepository repository;
        public UsuarioPerfilService(IUsuarioPerfilRepository service)
        {
            repository = service;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        public IList<UsuarioPerfilDTO> GetAll()
        {
            IQueryable<TUsuarioperfil> UsuarioPerfilEntities = repository.Items;

            return Builders.
                GenericBuilder.
                builderListEntityDTO<UsuarioPerfilDTO, TUsuarioperfil>
                (UsuarioPerfilEntities);
        }
        public void Insert(UsuarioPerfilDTO entityDTO)
        {
            TUsuarioperfil entity = Builders.
                GenericBuilder.builderDTOEntity<TUsuarioperfil, UsuarioPerfilDTO>
                (entityDTO);
            repository.Save(entity);
        }
        public UsuarioPerfilDTO GetUsuarioPerfil(Guid Id)
        {
            var entity = repository.Items.Where(u => u.UsuperId == Id).FirstOrDefault();
            return Builders.
                    GenericBuilder.
                    builderEntityDTO<UsuarioPerfilDTO, TUsuarioperfil>
                    (entity);
        }
        public void Update(UsuarioPerfilDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.builderDTOEntity<TUsuarioperfil, UsuarioPerfilDTO>
                (entityDTO);
            repository.Save(entity);
        }
    }
}
