namespace BMS.Controllers
{
    using BMS.Models;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IAircraftService _aircraftService;

        public FlightsController(IFlightService flightService, IAircraftService aircraftService)
        {
            _flightService = flightService;
            _aircraftService = aircraftService;
        }

        [HttpGet]
        public IActionResult RegisterFlight()
        {
            return this.View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterFlight(FlightInputModel flightInputModel)
        {
            if (ModelState.IsValid)
            {
                await _flightService.CreateFlights(flightInputModel);
            }

            return View();
        }

        [HttpGet]
        public IActionResult RegisterAircraft()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAircraft(AircraftInputModel aircraftInputModel)
        {
            if (ModelState.IsValid)
            {
                await _aircraftService.RegisterAircraft(aircraftInputModel);
                return RedirectToAction("DetermineCorrectLoadingInstruction", "Operations");
            }

            return View();
        }

       
    }
}
