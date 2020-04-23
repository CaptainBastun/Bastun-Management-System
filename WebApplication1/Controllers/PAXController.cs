namespace WebApplication1.Controllers
{
    using BMS.Models;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
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
      
    }
}
