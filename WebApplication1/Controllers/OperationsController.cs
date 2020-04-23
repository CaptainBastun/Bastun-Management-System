namespace BMS.Controllers
{
    using BMS.Models;
    using BMS.Models.LoadingInstructionInputModels;
    using BMS.Services.Contracts;
    using BMS.Models.ViewModels.Passengers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Wkhtmltopdf.NetCore;

    [Authorize]
    public class OperationsController : Controller
    {
        private readonly IFlightService _flightsService;
        private readonly IAircraftService _aircraftService;
        private readonly ILoadControlService _loadControlService;
        private readonly IPAXService _passengerService;
    

        public OperationsController(IFlightService flightService, IAircraftService aircraftService, 
            ILoadControlService loadControlService,IPAXService passengerService
           )
        {
            _flightsService = flightService;
            _aircraftService = aircraftService;
            _loadControlService = loadControlService;
            _passengerService = passengerService;
          
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
            var model =  _passengerService.GetAllPassengers("LH213");
            
            return View(model);
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
