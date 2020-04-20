namespace BMS.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using BMS.Models.MovementsInputModels;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;

    [Authorize]
    public class MovementsController : Controller
    {
        private readonly IMovementParser _movementParser;
        private readonly IAircraftService _flightsService;

        public MovementsController(IMovementParser movementParser, IAircraftService flightsService)
        {
          
            _movementParser = movementParser;
            _flightsService = flightsService;
        }

        [HttpGet]
        public IActionResult Arrival()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Arrival(MovementInputModel movementInput)
        {
            if (ModelState.IsValid)
            {
                if (await _movementParser.ParseArrivalMovement(movementInput.Movement))
                {
                    return RedirectToAction("InboundMessages", "Messages");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Departure()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Departure(MovementInputModel movementInput)
        {
            if (ModelState.IsValid)
            {
                if (await _movementParser.ParseDepartureMovement(movementInput.Movement))
                {
                    return RedirectToAction("OutboundMessages", "Messages");
                }
            }

            return View();
        }
    }
}
