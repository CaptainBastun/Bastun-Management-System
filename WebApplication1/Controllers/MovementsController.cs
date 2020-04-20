namespace BMS.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using BMS.Models.MovementsInputModels;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class MovementsController : Controller
    {
        private readonly IMovementParser _movementParser;
        private readonly IAircraftService _flightsService;

        public MovementsController(IMovementParser movementParser, IAircraftService flightsService)
        {
          
            this._movementParser = movementParser;
            _flightsService = flightsService;
        }

        [HttpGet]
        public IActionResult Arrival()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Arrival(MovementInputModel movementInput)
        {
            if (ModelState.IsValid)
            {
                if (_messageParser.ParseArrivalMovement(movementInput.Movement))
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
        public IActionResult Departure(MovementInputModel movementInput)
        {
            if (ModelState.IsValid)
            {
                if (_messageParser.ParseDepartureMovement(movementInput.Movement))
                {
                    return RedirectToAction("OutboundMessages", "Messages");
                }
            }
            return View();
        }
    }
}
