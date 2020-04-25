namespace BMS.Controllers
{
    using BMS.GlobalData;
    using BMS.Models;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IMovementParser _movementParser;
        private readonly ILoadMessageParser _loadMessageParser;
        private readonly IEmailSender _emailSender;

        public MessagesController(IMovementParser movementParser,
            ILoadMessageParser loadMessageParser,
            IEmailSender emailSender)
        {
            _movementParser = movementParser;
            _loadMessageParser = loadMessageParser;
           _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult InboundMessages()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InboundLDM(MessageInputModel  messageInputModel)
        {
            if (ModelState.IsValid)
            {
                if (await _loadMessageParser.ParseInboundLoadDistributionMessage(messageInputModel.Message))
                {
                    _emailSender.Send(messageInputModel.OpsEmail, messageInputModel.Message, SendEmailConstants.LoadDistributionMessageSubject);
                    return View("InboundMessages");
                }
                TempData["Error"] = "Load distribution message is invalid";
                return View("InboundMessages");
            } 

          return RedirectToAction("Index", "Home");
        } 
        
     

        [HttpGet]
        public IActionResult OutboundMessages()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OutboundLDM(MessageInputModel messageInputModel)
        {
            if (ModelState.IsValid)
            {
                if (await _loadMessageParser.ParseOutboundLoadDistributionMessage(messageInputModel.Message))
                {
                    _emailSender.Send(messageInputModel.OpsEmail, messageInputModel.Message, SendEmailConstants.LoadDistributionMessageSubject);    
                    return RedirectToAction("OutboundMessages");
                }
                TempData["Error"] = "Load distribution message is invalid";
                return View("OutboundMessages");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
