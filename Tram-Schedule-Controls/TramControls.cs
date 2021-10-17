using System;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule.Models;

namespace Tram_Schedule_Controls
{
    public class TramControls
    {
        private readonly IDao<Tram> _tramDao;

        public TramControls(IDao<Tram> dao)
        {
            _tramDao = dao;
        }

        public void AddNewTram(string name, string firstrun)
        {
            if (!string.IsNullOrEmpty(firstrun))
            {
                if (DateTime.TryParse(firstrun, out DateTime dt))
                {
                    if (dt <= DateTime.Now)
                    {
                        _tramDao.Add(new Tram() { Name = name, FirstRun = dt });
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                _tramDao.Add(new Tram() { Name = name });
            }
        }
    }
}
