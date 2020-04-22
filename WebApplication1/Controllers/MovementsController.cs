namespace BMS.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using BMS.Models.MovementsInputModels;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    using BMS.GlobalData;

    [Authorize]
    public class MovementsController : Controller
    {
        private readonly IMovementParser _movementParser;
        private readonly IEmailSender _emailSender;

        public MovementsController(IMovementParser movementParser, IEmailSender emailSender)
        {
            _movementParser = movementParser;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Arrival()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Arrival(MovementInputModel movementInput)
        {
            _emailSender.Send(movementInput.OpsEmail, movementInput.Movement, "Test");
            if (ModelState.IsValid)
            {
                if (await _movementParser.ParseArrivalMovement(movementInput.Movement))
                {
                    _emailSender.Send(movementInput.OpsEmail, movementInput.Movement, SendEmailConstants.MovementSubject);
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
                    _emailSender.Send(movementInput.OpsEmail, movementInput.Movement, SendEmailConstants.MovementSubject);
                    return RedirectToAction("OutboundMessages", "Messages");
                }
            }

            return View();
        }
    }
}
