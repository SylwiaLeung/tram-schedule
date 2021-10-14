using System;
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
            return ReadAll().Select(x => x.Name).ToList();
        }

        public IEnumerable<string> ReadTramStopDescription(string name)
        {
            List<string> descriptions = new()
            {
                Read(name).Description
            };
            return descriptions;
        }

        public void AddNewStop(string name, string description, string routeName)
        {
            RouteDao dao = new(Context);
            if (routeName != string.Empty)
            {
                var route = dao.Read(routeName);
                if (description != string.Empty)
                {
                    Add(new TramStop() { Name = name, Description = description, RouteID = route.ID });
                }
                else
                {
                    Add(new TramStop() { Name = name, RouteID = route.ID });
                }
            }
            else
            {
                throw new ArgumentException("Please choose from the list of routes.");
            }
        }
    }
}