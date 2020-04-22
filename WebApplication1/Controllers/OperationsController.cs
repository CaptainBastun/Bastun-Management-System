namespace BMS.Controllers
{
    using BMS.Models;
    using BMS.Models.LoadingInstructionInputModels;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    public class OperationsController : Controller
    {
        private readonly IFlightService _flightsService;
        private readonly IAircraftService _aircraftService;
        private readonly ILoadControlService _loadControlService;

        public OperationsController(IFlightService flightService, IAircraftService aircraftService, 
            ILoadControlService loadControlService)
        {
            _flightsService = flightService;
            _aircraftService = aircraftService;
            _loadControlService = loadControlService;
        }


        [HttpGet]
        public IActionResult Loadsheet()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoadingInstruction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileLoadingInstruction(BulkLoadingInstructionInputModel loadingInstructionInputModel)
        {
            if (ModelState.IsValid)
            {
                var outboundFlight = await _flightsService.GetOutboundFlightByFlightNumber(loadingInstructionInputModel.FlightNumber);
                await _loadControlService.AddLoadingInstruction(outboundFlight,loadingInstructionInputModel);
                return Redirect("LoadingInstruction");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult PAXManifest()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DepartureControl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Depart()
        {

            return this.Ok();
        }
    }
}
