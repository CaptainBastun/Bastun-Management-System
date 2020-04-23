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
        private readonly IGeneratePdf _pdfGenerator;

        public OperationsController(IFlightService flightService, IAircraftService aircraftService, 
            ILoadControlService loadControlService,IPAXService passengerService,
            IGeneratePdf pdfGenerator)
        {
            _flightsService = flightService;
            _aircraftService = aircraftService;
            _loadControlService = loadControlService;
            _passengerService = passengerService;
            _pdfGenerator = pdfGenerator;
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
        public async Task<IActionResult> PAXManifest()
        {
            var model = await _passengerService.GetAllPassengers("LH213");
            
            return View(model);
        }

       

        [HttpGet]
        public async Task<IActionResult> DepartureControl()
        {
            var model = await _passengerService.GetAllPassengers("LH213");
            return await _pdfGenerator.GetPdf<PassengerViewModel>("Views/Operations/PAXManifest.cshtml", model);
        }

        [HttpPost]
        public IActionResult Depart()
        {

            return this.Ok();
        }
    }
}
