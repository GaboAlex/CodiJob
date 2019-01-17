//using CodiJobService.Model.CodiJobDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Domain.IRepositories
{
    public interface IProyectoRepository : IRepository<TProyecto>
    {
        IQueryable<TProyecto> FilterProyectos(int pageSize, int page);
    }
}
