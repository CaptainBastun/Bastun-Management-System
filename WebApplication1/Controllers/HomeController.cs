namespace WebApplication1.Controllers
{
    using System.Diagnostics;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using WebApplication1.Models;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlightService _flightsService;

        public HomeController(ILogger<HomeController> logger,IFlightService flightsService)
        {
            _logger = logger;
            _flightsService = flightsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var flights = _flightsService.GetAllFlights();
            return View(flights);
        }
     

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
