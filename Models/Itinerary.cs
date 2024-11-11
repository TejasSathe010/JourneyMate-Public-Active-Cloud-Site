using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyMate_Public_Active_Cloud_Site.Models
{
    public class Itinerary
    {
        [Key]
        public int ItineraryId { get; set; }

        [Required]
        [ForeignKey("Trip")]
        public int TripId { get; set; }
        
        public Trip Trip { get; set; }

        [Required]
        public int DayNumber { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [StringLength(500)]
        public string Activities { get; set; }

        [StringLength(500)]
        public string ItemsToBring { get; set; }
    }
}