namespace BMS.Controllers
{
    using BMS.Models;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IMessageParser _messageParser;

        public MessagesController(IMessageParser messageParser)
        {
            _messageParser = messageParser;
        }

        [HttpGet]
        public IActionResult InboundMessages()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InboundLDM(MessageInputModel  messageInputModel)
        {
            if (ModelState.IsValid)
            {
                _messageParser.ParseInboundLDM(messageInputModel.Message);
                return RedirectToAction("InboundMessages");
            } 

          return this.RedirectToAction("Index", "Home");
        } 
        
        [HttpPost]
        public IActionResult InboundCPM(MessageInputModel messageInputModel)
        {
            if (_messageParser.ParseInboundCPM(messageInputModel.Message))
            {
                return RedirectToAction("InboundMessages");
            }
            
           return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult OutboundMessages()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OutboundCPM(MessageInputModel messageInputModel)
        {
            if (ModelState.IsValid)
            {
                if (_messageParser.ParseOutboundCPM(messageInputModel.Message))
                {
                    return RedirectToAction("OutboundMessages");
                } 
            }

            return RedirectToAction("Index","Home");
        }


        [HttpPost]
        public IActionResult OutboundLDM(MessageInputModel messageInputModel)
        {
            if (ModelState.IsValid)
            {
                if (_messageParser.ParseOutboundLDM(messageInputModel.Message))
                {
                    return RedirectToAction("OutboundMessages");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
