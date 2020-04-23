namespace WebApplication1.Controllers
{
    using BMS.GlobalData.ErrorMessages;
    using BMS.Models;
    using BMS.Models.ViewModels.Passengers;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Authorize]
    public class PAXController : Controller
    {
        private readonly IPAXService _paxService;

        public PAXController(IPAXService paxService)
        {
            _paxService = paxService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(PAXInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                await _paxService.CreatePassenger(inputModel);
                return Redirect("Register");
            }

            return RedirectToAction("Index", "Home");
        }

        
        [HttpGet]
        public IActionResult OffloadEdit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetPassengerByFullNameData(PassengerFullNameInputModel fullNameInputModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, InvalidPAXErrorMessages.PaxFullNameInvalid);
                return View("OffloadEdit");
            }

            try
            {
                var offloadEditViewModel = await _paxService.GetPassengerByFullName(fullNameInputModel.FullName);
                return View("OffloadEditPassenger", offloadEditViewModel);
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult  DisplayPassengerByFullName(PassengerOffloadEditViewModel offloadEditViewModel)
        {
            return View(offloadEditViewModel);
        }

        [HttpPost]
        public IActionResult OffloadEditPassenger(PassengerOffloadEditInputModel passengerOffloadEditInput)
        {
            return Ok();
        }
      
    }
}
