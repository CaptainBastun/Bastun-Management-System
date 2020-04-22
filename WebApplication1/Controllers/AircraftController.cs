namespace BMS.Controllers
{
    using BMS.Models;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class AircraftController : Controller
    {
        private readonly IAircraftService _aircraftService;
        private readonly IAircraftCabinBaggageHoldService _cabinBaggageHoldService;
        private readonly IFlightService _flightService;
 

        public AircraftController(IAircraftService aircraftService,
            IAircraftCabinBaggageHoldService cabinBaggageHoldService,
            IFlightService flightService)
        {
            _aircraftService = aircraftService;
            _cabinBaggageHoldService = cabinBaggageHoldService;
            _flightService = flightService;
        
        }


        [HttpGet]
        public IActionResult RegisterAircraft()
        {
            return  View();
        }

        [HttpPost] 
        public async Task<IActionResult> RegisterAircraft(AircraftInputModel aircraftInputModel)
        {
            if (ModelState.IsValid)
            {
               await _aircraftService.RegisterAircraft(aircraftInputModel);
               return RedirectToAction("CreateBaggageHold", "Aircraft", aircraftInputModel.FlightNumber);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBaggageHold(string flightNumber)
        {
            if (!string.IsNullOrWhiteSpace(flightNumber))
            {
                var flight = await _flightService.GetOutboundFlightByFlightNumber(flightNumber);
                await _cabinBaggageHoldService.CreateBaggageHoldAndCompartments(flight);
                return RedirectToAction("CreateCabin", flightNumber);
            }

            return RedirectToAction("RegisterAircraft");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCabin(string flightNumber)
        {
            if (!string.IsNullOrWhiteSpace(flightNumber))
            {
                var flight = await _flightService.GetOutboundFlightByFlightNumber(flightNumber);
                await _cabinBaggageHoldService.CreateCabinAndZones(flight);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("RegisterAircraft");
        }


    }
}
