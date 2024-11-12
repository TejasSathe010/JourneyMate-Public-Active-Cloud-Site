using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TravelPlanner.Data;
using Microsoft.EntityFrameworkCore;

public class TripsController : Controller
{
    private readonly ApplicationDbContext _context;

    public TripsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("trips/create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("trips/create")]
    public IActionResult Create(Trip trip, List<Itinerary> itineraries)
    {
    if (ModelState.IsValid)
    {
        _context.Trips.Add(trip);
        _context.SaveChanges();

        foreach (var itinerary in itineraries)
        {
            itinerary.TripId = trip.TripId; // Set the foreign key only
            _context.Itineraries.Add(itinerary); // Do not set ItineraryId manually
        }

        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

        return View(trip);
    }
    [HttpGet]
    [Route("trips/details")]
    public IActionResult Details(int id)
    {
        var trip = _context.Trips
                        .Include(t => t.Itineraries)
                        .FirstOrDefault(t => t.TripId == id);
        
        if (trip == null)
        {
            return NotFound();
        }
        decimal foodBudget = 0;
        decimal accommodationBudget = 0;
        decimal travelBudget = 0;
        List<decimal> dailyFoodBudget = new List<decimal>();
        List<decimal> dailyAccommodationBudget = new List<decimal>();
        List<decimal> dailyTravelBudget = new List<decimal>();
        List<decimal> dailyBudget = new List<decimal>();
        List<DateTime> dates = new List<DateTime>();
        foreach (Itinerary itinerary in trip.Itineraries){
            foodBudget += itinerary.FoodBudget;
            accommodationBudget += itinerary.AccommodationBudget;
            travelBudget += itinerary.TravelBudget;
            dailyFoodBudget.Add(itinerary.FoodBudget);
            dailyAccommodationBudget.Add(itinerary.AccommodationBudget);
            dailyTravelBudget.Add(itinerary.TravelBudget);
            dailyBudget.Add(itinerary.AccommodationBudget + itinerary.FoodBudget + itinerary.TravelBudget);
            dates.Add(itinerary.Date);
        }
        List<decimal> budgets = new List<decimal>();
        budgets.Add(foodBudget);
        budgets.Add(accommodationBudget);
        budgets.Add(travelBudget);
        // The starting date
        DateTime startDate = dates.First();

        // Generate a list of formatted day strings
        List<string> formattedDays = dates
            .Select((date, index) => 
                $"Day {((date - startDate).Days + 1)} - {date:MMM dd, yy}")
            .ToList();

        // Pass the formatted list to the view
        ViewBag.FormattedDays = formattedDays;
        ViewBag.Budgets = budgets;
        ViewBag.Days = formattedDays;
        ViewBag.DailyBudget = dailyBudget;
        ViewBag.DailyFoodBudget = dailyFoodBudget;
        ViewBag.DailyAccommodationBudget = dailyAccommodationBudget;
        ViewBag.DailyTravelBudget = dailyTravelBudget;
        return View(trip);
    }
}

