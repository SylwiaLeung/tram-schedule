using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tram_Schedule.Models;

namespace Tram_Schedule.DAL.DAO
{
    public class TramStopDao
    {
        private DatabaseContext Context { get; set; }

        public TramStopDao(DatabaseContext context)
        {
            Context = context;
        }

        public void Add(TramStop instance)
        {
            Context.TramStops.Add(instance);
            Context.SaveChanges();
        }

        public void Delete(TramStop instance)
        {
            Context.TramStops.Remove(instance);
            Context.SaveChanges();
        }

        public TramStop Read(string name)
        {
            return Context.TramStops.AsNoTracking().Where(x => x.Name == name).FirstOrDefault();
        }

        public IEnumerable<TramStop> ReadAll()
        {
            return Context.TramStops.AsNoTracking().ToList();
        }

        public void Update(TramStop instance)
        {
            Context.TramStops.Update(instance);
            Context.SaveChanges();
        }

        public IEnumerable<string> ReadAllTramStopNames()
        {
            return Context.TramStops.Select(x => x.Name).AsNoTracking().ToList();
        }

        public IEnumerable<string> ReadTramStopDescription(string name)
        {
            List<string> descriptions = new List<string>();
            descriptions.Add(Read(name).Description);
            return descriptions;
        }
    }
}