using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tram_Schedule.Models;

namespace Tram_Schedule.DAL.DAO
{
    public class RouteDao : IDao<Route>
    {
        public IDatabaseContext Context { get; set; }

        public RouteDao(IDatabaseContext context)
        {
            Context = context;
        }

        public void Add(Route instance)
        {
            Context.TramRoutes.Add(instance);
            Context.Save();
        }

        public void Delete(Route instance)
        {
            Context.TramRoutes.Remove(instance);
            Context.Save();
        }

        public Route Read(string name) 
            => Context.TramRoutes.AsNoTracking().Include(t => t.StopsList).Where(x => x.Name == name).FirstOrDefault();

        public List<Route> ReadAll() 
            => Context.TramRoutes.AsNoTracking().Include(t => t.StopsList).ToList();

        public void Update(Route instance)
        {
            Context.TramRoutes.Update(instance);
            Context.Save();
        }
    }
}
