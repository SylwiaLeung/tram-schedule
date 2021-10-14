﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tram_Schedule.Models;

namespace Tram_Schedule.DAL.DAO
{
    public class TramDao : IDao<Tram>
    {
        public DatabaseContext Context { get; set; }

        public TramDao(DatabaseContext context)
        {
            Context = context;
        }

        public void Add(Tram instance)
        {
            Context.Trams.Add(instance);
            Context.SaveChanges();
        }

        public void Delete(Tram instance)
        {
            Context.Trams.Remove(instance);
            Context.SaveChanges();
        }

        public Tram Read(string name)
        {
            return Context.Trams.AsNoTracking().Where(x => x.Name == name).FirstOrDefault();
        }

        public IEnumerable<Tram> ReadAll()
        {
            return Context.Trams.AsNoTracking().ToList();
        }

        public void Update(Tram instance)
        {
            Context.Trams.Update(instance);
            Context.SaveChanges();
        }

        public IEnumerable<string> ReadAllTramNames()
        {
            return Context.Trams.Select(x => x.Name).AsNoTracking().ToList();
        }

        public IEnumerable<DateTime> ReadTramFirstRun(string name)
        {
            var runs = new List<DateTime>();
            runs.Add(Read(name).FirstRun);
            return runs;
        }

        public void AddNewTram(string name, string firstrun)
        {
            if (firstrun != string.Empty)
            {
                DateTime dt;
                if (DateTime.TryParse(firstrun, out dt))
                {
                    if (dt <= DateTime.Now)
                    {
                        Add(new Tram() { Name = name, FirstRun = dt });
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                Add(new Tram() { Name = name });
            }
        }
    }
}