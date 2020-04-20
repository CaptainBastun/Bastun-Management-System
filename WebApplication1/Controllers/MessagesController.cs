namespace BMS.Controllers
{
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
        private readonly IContainerMessageParser _containerMessageParser;

        public MessagesController(IMovementParser movementParser,
            ILoadMessageParser loadMessageParser, IContainerMessageParser containerMessageParser)
        {
            _movementParser = movementParser;
            _loadMessageParser = loadMessageParser;
            _containerMessageParser = containerMessageParser;
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
                    return RedirectToAction("InboundMessages");
                }
            } 

          return RedirectToAction("Index", "Home");
        } 
        
        [HttpPost]
        public async Task<IActionResult> InboundCPM(MessageInputModel messageInputModel)
        {
            if (ModelState.IsValid)
            {
                if (await _containerMessageParser.ParseInboundContainerPalletMessage(messageInputModel.Message))
                {
                    return RedirectToAction("InboundMessages");
                }
            }
            
           return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult OutboundMessages()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OutboundCPM(MessageInputModel messageInputModel)
        {
            if (ModelState.IsValid)
            {
                if (await _containerMessageParser.ParseOutboundContainerPalletMessage(messageInputModel.Message))
                {
                    return RedirectToAction("OutboundMessages");
                }
            }

            return RedirectToAction("Index","Home");
        }


        [HttpPost]
        public async Task<IActionResult> OutboundLDM(MessageInputModel messageInputModel)
        {
            if (ModelState.IsValid)
            {
                if (await _loadMessageParser.ParseOutboundLoadDistributionMessage(messageInputModel.Message))
                {
                    return RedirectToAction("OutboundMessages");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
