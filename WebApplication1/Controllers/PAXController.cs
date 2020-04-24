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
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSuitcase(PAXInputModel inputModel)
        {
                await _paxService.CreateSuitcase(inputModel.SuitcaseInputModel);
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
            if (!await _paxService.CheckIfPassengerByFullNameExists(fullNameInputModel.FullName))
            {
                TempData["Error"] = "No such passenger exists";
                return View("OffloadEdit");
            }


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, InvalidPAXErrorMessages.PaxFullNameInvalid);
                return View("OffloadEdit");
            }

            var offloadEditViewModel = await _paxService.GetPassengerByFullName(fullNameInputModel.FullName);
            return View("OffloadEditPassenger", offloadEditViewModel);
                
        }

        [HttpPost]
        public IActionResult  DisplayPassengerByFullName(PassengerOffloadEditViewModel offloadEditViewModel)
        {
            return View(offloadEditViewModel);
        }

        [HttpGet]
        public IActionResult OffloadEditPassenger()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Offload(int id)
        {
            await _paxService.OffloadPassenger(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> EditPassenger(PassengerOffloadEditViewModel offloadEdit, int id)
        {
            await _paxService.EditPassengerData(offloadEdit.OffloadEditInputModel,id);

            return RedirectToAction("Index", "Home");
        }
      
    }
}
