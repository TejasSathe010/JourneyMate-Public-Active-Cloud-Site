using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JourneyMate_Public_Active_Cloud_Site.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Source { get; set; }

        [Required]
        [StringLength(100)]
        public string Destination { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        // Navigation property for related itineraries
        public List<Itinerary> Itineraries { get; set; } = new List<Itinerary>();
    }
}