using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tram_Schedule.Models;

namespace Tram_Schedule.DAL.DAO
{
    public class TramStopDao : IDao<TramStop>
    {
        public IDatabaseContext Context { get; set; }

        public TramStopDao(IDatabaseContext context)
        {
            Context = context;
        }

        public void Add(TramStop instance)
        {
            Context.TramStops.Add(instance);
            Context.Save();
        }

        public void Delete(TramStop instance)
        {
            Context.TramStops.Remove(instance);
            Context.Save();
        }

        public TramStop Read(string name)
        {
            return Context.TramStops.AsNoTracking().Where(x => x.Name == name).FirstOrDefault();
        }

        public List<TramStop> ReadAll()
        {
            return Context.TramStops.AsNoTracking().ToList();
        }

        public void Update(TramStop instance)
        {
            Context.TramStops.Update(instance);
            Context.Save();
        }
    }
}