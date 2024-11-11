using JourneyMate_Public_Active_Cloud_Site.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelPlanner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
    }
}
