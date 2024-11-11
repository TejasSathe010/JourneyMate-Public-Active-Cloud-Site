using Microsoft.AspNetCore.Mvc;
using TripPlanner.Models;
using TravelPlanner.Data;

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
}

