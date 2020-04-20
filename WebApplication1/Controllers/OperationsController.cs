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

        public OperationsController(IFlightService flightService, IAircraftService aircraftService, ILoadControlService loadControlService)
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
        public IActionResult DefaultLoadingInstruction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DetermineCorrectLoadingInstruction(string flightNumber)
        {
            var flight = await _flightsService.GetOutboundFlightByFlightNumber(flightNumber);
            string type = _aircraftService.GetAircraftOfContainerizedType(flight);
            string correctLoadingInstruction = _loadControlService.GetCorrectLoadingInstruction(type);

            if (correctLoadingInstruction == null)
            {
                ModelState.AddModelError(string.Empty, "No valid loading instruction report found!");
            }

            return View(correctLoadingInstruction);
        }

        [HttpPost]
        public IActionResult FileBulkLoadingInstruction(BulkLoadingInstructionInputModel loadingInstructionInputModel)
        {

            return this.Ok();
        }

        [HttpPost]
        public IActionResult File788ContainerLoadingInstruction(_788LoadingInstructionInputModel loadingInstructionInputModel)
        {
            return this.Ok();
        }

        [HttpPost]
        public IActionResult File763ContainerLoadingInstruction(_763LoadingInstructionInputModel loadingInstructionInputModel)
        {
            return this.Ok();
        }

        [HttpGet]
        public IActionResult PAXManifest()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult DepartureControl()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Depart()
        {

            return this.Ok();
        }
    }
}
