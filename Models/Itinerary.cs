using System;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Models
{
    public class Itinerary
    {
        [Key]
        public int ItineraryId { get; set; }
        public int TripId { get; set; }
        public Trip? Trip { get; set; }
        public DateTime Date { get; set; }
        public decimal FoodBudget { get; set; }
        public decimal AccommodationBudget { get; set; }
        public decimal TravelBudget { get; set; }
        public string Activities { get; set; }
        public string ThingsToCarry { get; set; }
    }
}
