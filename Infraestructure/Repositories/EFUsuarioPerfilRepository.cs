//using CodiJobService.Model.CodiJobDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;

namespace Infraestructure.Repositories
{
    public class EFUsuarioPerfilRepository :IUsuarioPerfilRepository
    {
        private CodiJobDbContext context;
        public IQueryable<TUsuarioperfil> Items => context.TUsuarioperfil;
        public EFUsuarioPerfilRepository(CodiJobDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TUsuarioperfil usuarioperfil)
        {
            if (usuarioperfil.UsuperId == Guid.Empty)
            {
                usuarioperfil.UsuperId = Guid.NewGuid();
                context.TUsuarioperfil.Add(usuarioperfil);
            }
            else
            {
                TUsuarioperfil dbEntry = context.TUsuarioperfil
                .FirstOrDefault(p => p.UsuperId == usuarioperfil.UsuperId);
                if (dbEntry != null)
                {
                    dbEntry.UsuperDesc = usuarioperfil.UsuperDesc;
                    dbEntry.UsuperGit= usuarioperfil.UsuperGit;
                    dbEntry.UsuperBlog = usuarioperfil.UsuperBlog;
                    dbEntry.UsuperWeb = usuarioperfil.UsuperWeb;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid UsuarioPerfilId)
        {
            TUsuarioperfil dbEntry = context.TUsuarioperfil
            .FirstOrDefault(p => p.UsuperId == UsuarioPerfilId);
            if (dbEntry != null)
            {
                context.TUsuarioperfil.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
