namespace BMS.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using BMS.Models.MovementsInputModels;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class MovementsController : Controller
    {
        private readonly IMessageParser _messageParser;
        private readonly IAircraftService _flightsService;

        public MovementsController(IMessageParser messageParser,IAircraftService flightsService)
        {
            _messageParser = messageParser;
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
