using Microsoft.EntityFrameworkCore;
using Tram_Schedule.Models;

namespace Tram_Schedule.DAL
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Tram> Trams { get; set; }

        public virtual DbSet<TramStop> TramStops { get; set; }

        public virtual DbSet<Route> TramRoutes { get; set; }

        public string DbPath { get; private set; }

        public DatabaseContext()
        {
            DbPath = @"C:\Users\CTNW74\Desktop\projects\tram-schedule\Tram-Schedule\bin\Debug\net5.0\TramTable.db";
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedTrams();
            //try
            //{
            //    connection.Open();
            //    TramDao dao = new(context);
            //    List<Tram> trams = dao.ReadAll();
            //    dataGridView1.DataSource = trams;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error connection", ex.Message);
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }
    }
}
