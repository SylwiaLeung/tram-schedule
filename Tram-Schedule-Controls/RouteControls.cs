using System.Collections.Generic;
using System.Linq;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule.Models;

namespace Tram_Schedule_Controls
{
    public class RouteControls
    {
        private readonly IDao<Route> _routeDao;

        public RouteControls(IDao<Route> dao)
        {
            _routeDao = dao;
        }

        public List<string> ReadAllRouteNames() => _routeDao.ReadAll().Select(x => x.Name).ToList();
    }
}
