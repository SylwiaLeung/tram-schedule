using Microsoft.EntityFrameworkCore;
using Tram_Schedule.Models;

namespace Tram_Schedule.DAL
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Tram> Trams { get; set; }

        public DbSet<TramStop> TramStops { get; set; }

        public DbSet<Route> TramRoutes { get; set; }

        public string DbPath { get; private set; }

        public DatabaseContext()
        {
            DbPath = @"C:\Users\CTNW74\Desktop\projects\tram-schedule\Tram-Schedule\bin\Debug\net5.0\TramTable.db";
            Save();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedTrams();
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
