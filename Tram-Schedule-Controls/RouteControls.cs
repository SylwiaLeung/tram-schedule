using System.Collections.Generic;
using System.Linq;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule.Models;

namespace Tram_Schedule_Controls
{
    public class RouteControls
    {
        private readonly IDao<Route> routeDao;

        public RouteControls(IDao<Route> dao)
        {
            routeDao = dao;
        }

        public IEnumerable<string> ReadAllRouteNames()
        {
            return routeDao.ReadAll().Select(x => x.Name).ToList();
        }
    }
}
