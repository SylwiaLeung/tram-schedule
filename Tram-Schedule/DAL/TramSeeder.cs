using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tram_Schedule.Models;

namespace Tram_Schedule.DAL
{
    public static class StoreSeeder
    {
        public static void SeedTrams(this ModelBuilder builder)
        {
            List<Tram> Trams = new();
            Trams.Add(new Tram()
            {
                ID = 1,
                Name = "PapaTram",
                FirstRun = DateTime.Parse("1988-05-12")
            });
            Trams.Add(new Tram()
            {
                ID = 2,
                Name = "VintageTram",
                FirstRun = DateTime.Parse("2018-12-21")
            });

            List<Route> TramRoutes = new();
            TramRoutes.Add(new Route()
            {
                ID = 1,
                Name = "Papieski",
                StopsList = new List<TramStop>()
            });
            TramRoutes.Add(new Route()
            {
                ID = 2,
                Name = "Wawelski",
                StopsList = new List<TramStop>()
            });

            List<TramStop> TramStops = new();
            TramStops.Add(new TramStop()
            {
                ID = 1,
                Name = "Sanktuarium",
                Description = "This stop is the best of them all",
                RouteID = 1
            });
            TramStops.Add(new TramStop()
            {
                ID = 2,
                Name = "Borek",
                Description = "This stop is very far",
                RouteID = 1
            });
            TramStops.Add(new TramStop()
            {
                ID = 3,
                Name = "Stradom",
                Description = "This stop lies near a very good cafe",
                RouteID = 2
            });
            TramStops.Add(new TramStop()
            {
                ID = 4,
                Name = "Wawel",
                Description = "This stop is situated by the Wawel castle",
                RouteID = 2
            });
            builder.Entity<Tram>().HasData(Trams);
            builder.Entity<TramStop>().HasData(TramStops);
            builder.Entity<Route>().HasData(TramRoutes);
        }
    }
}
