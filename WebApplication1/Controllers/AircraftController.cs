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
     
        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
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
               return View();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
