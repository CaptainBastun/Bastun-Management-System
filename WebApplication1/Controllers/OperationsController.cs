namespace BMS.Controllers
{
    using BMS.Models;
    using BMS.Models.LoadingInstructionInputModels;
    using BMS.Services.Contracts;
    using BMS.Models.ViewModels.Passengers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using BMS.Services.ConvertToPdf.Enums;

    [Authorize]
    public class OperationsController : Controller
    {
        private readonly IFlightService _flightsService;
        private readonly IAircraftService _aircraftService;
        private readonly ILoadControlService _loadControlService;
        private readonly IPAXService _passengerService;
        private readonly IViewRenderService _viewRenderService;
        private readonly IHtmlToPdfConverter _toPdfConverter;
        private readonly IHostingEnvironment _hostingEnvironment;

        public OperationsController(IFlightService flightService, IAircraftService aircraftService, 
            ILoadControlService loadControlService,IPAXService passengerService,IViewRenderService viewRenderService,
            IHtmlToPdfConverter toPdfConverter, IHostingEnvironment hostingEnvironment)
        {
            _flightsService = flightService;
            _aircraftService = aircraftService;
            _loadControlService = loadControlService;
            _passengerService = passengerService;
            _viewRenderService = viewRenderService;
            _toPdfConverter = toPdfConverter;
            _hostingEnvironment = hostingEnvironment;
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

        [HttpPost]
        public IActionResult PAXManifest(string flightNumber)
        {
            var model =  _passengerService.GetAllPassengers(flightNumber);
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePAXManifest(string flightNumber)
        {
            var pax = _passengerService.GetAllPassengers(flightNumber);
            var htmlData = await _viewRenderService.RenderToStringAsync("~/Views/Operations/_PassengerManifestPartial.cshtml", pax);
            var formatType = FormatType.A4;
            var orientationType = OrientationType.Portrait;
            var fileContents = _toPdfConverter.Convert(_hostingEnvironment.ContentRootPath, htmlData, formatType, orientationType);

            return File(fileContents, "application/pdf");
        }

        [HttpGet]
        public IActionResult DepartureControl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Depart()
        {
            return Ok();
        }
    }
}
