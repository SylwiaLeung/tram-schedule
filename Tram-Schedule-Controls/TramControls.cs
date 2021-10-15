﻿using System;
using System.Collections.Generic;
using System.Linq;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule.Models;

namespace Tram_Schedule_Controls
{
    public class TramControls
    {
        private readonly IDao<Tram> tramDao;

        public TramControls(IDao<Tram> dao)
        {
            tramDao = dao;
        }

        public IEnumerable<string> ReadAllTramNames()
        {
            return tramDao.ReadAll().Select(x => x.Name).ToList();
        }

        public IEnumerable<DateTime> ReadTramFirstRun(string name)
        {
            var runs = new List<DateTime>
            {
                tramDao.Read(name).FirstRun
            };
            return runs;
        }

        public void AddNewTram(string name, string firstrun)
        {
            if (firstrun != string.Empty)
            {
                if (DateTime.TryParse(firstrun, out DateTime dt))
                {
                    if (dt <= DateTime.Now)
                    {
                        tramDao.Add(new Tram() { Name = name, FirstRun = dt });
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                tramDao.Add(new Tram() { Name = name });
            }
        }
    }
}
