using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tram_Schedule.Models;

namespace Tram_Schedule.DAL.DAO
{
    public class TramDao : IDao<Tram>
    {
        public IDatabaseContext Context { get; set; }

        public TramDao(IDatabaseContext context)
        {
            Context = context;
        }

        public void Add(Tram instance)
        {
            Context.Trams.Add(instance);
            Context.Save();
        }

        public void Delete(Tram instance)
        {
            Context.Trams.Remove(instance);
            Context.Save();
        }

        public Tram Read(string name)
        {
            return Context.Trams.AsNoTracking().Where(x => x.Name == name).FirstOrDefault();
        }

        public List<Tram> ReadAll()
        {
            return Context.Trams.AsNoTracking().ToList();
        }

        public void Update(Tram instance)
        {
            Context.Trams.Update(instance);
            Context.Save();
        }
    }
}