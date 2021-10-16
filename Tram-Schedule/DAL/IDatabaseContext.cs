using Microsoft.EntityFrameworkCore;
using Tram_Schedule.Models;

namespace Tram_Schedule.DAL
{
    public interface IDatabaseContext
    {
        DbSet<Tram> Trams { get; set; }
        DbSet<TramStop> TramStops { get; set; }
        DbSet<Route> TramRoutes { get; set; }
        void Save();
    }
}
