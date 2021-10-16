using System;
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

        public void AddNewTram(string name, string firstrun)
        {
            if (!string.IsNullOrEmpty(firstrun))
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
