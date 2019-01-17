﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using CodiJobService.Model.CodiJobDb;
using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;

namespace Infraestructure.Repositories
{
    public class EFGrupoRepository : IGrupoRepository
    {
        private CodiJobDbContext context;
        public IQueryable<TGrupo> Items => context.TGrupo;
        public EFGrupoRepository(CodiJobDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TGrupo grupo)
        {
            if (grupo.Id == Guid.Empty)
            {
                grupo.Id = Guid.NewGuid();
                context.TGrupo.Add(grupo);
            }
            else
            {
                TGrupo dbEntry = context.TGrupo
                .FirstOrDefault(p => p.Id == grupo.Id);
                if (dbEntry != null)
                {
                    dbEntry.GrupoFoto = grupo.GrupoFoto;
                    dbEntry.GrupoNom = grupo.GrupoNom;
                    dbEntry.GrupoProm = grupo.GrupoProm;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid GrupoID)
        {
            TGrupo dbEntry = context.TGrupo
            .FirstOrDefault(p => p.Id == GrupoID);
            if (dbEntry != null)
            {
                context.TGrupo.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
