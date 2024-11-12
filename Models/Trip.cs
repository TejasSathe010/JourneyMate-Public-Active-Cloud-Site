using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JourneyMate_Public_Active_Cloud_Site.Models;

namespace TripPlanner.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        public required string TripName { get; set; }
        public required string SourceLocation { get; set; }
        public required string DestinationLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Itinerary> Itineraries { get; set; }
    }
    public class Trips{
        public List<Trip> data { get; set; }
    }
}
