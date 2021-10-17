using System;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule.Models;

namespace Tram_Schedule_Controls
{
    public class TramStopControls
    {
        private readonly IDao<TramStop> _tramStopDao;

        public TramStopControls(IDao<TramStop> dao)
        {
            _tramStopDao = dao;
        }

        public void AddNewStop(string name, string description, string routeName)
        {
            RouteDao dao = new(_tramStopDao.Context);
            if (!string.IsNullOrEmpty(routeName))
            {
                var route = dao.Read(routeName);
                if (string.IsNullOrEmpty(description) || description == "Description of the stop")
                {
                    description = "No description given";
                }
                _tramStopDao.Add(new TramStop() { Name = name, Description = description, RouteID = route.ID });
            }
            else
            {
                throw new ArgumentException("Please choose from the list of routes.");
            }
        }
    }
}
