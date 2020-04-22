namespace BMS.Controllers
{
    using BMS.Models;
    using BMS.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    public class FuelAndWeightController : Controller
    {
        private readonly IFuelAndWeightService _fuelAndWeightService;

        public FuelAndWeightController(IFuelAndWeightService fuelAndWeightService)
        {
            _fuelAndWeightService = fuelAndWeightService;
        }


        [HttpGet]
        public IActionResult FuelForm()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterFuelForm(FuelFormInputModel fuelInputModel)
        {
            if (ModelState.IsValid)
            {
                await _fuelAndWeightService.AddFuelForm(fuelInputModel);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult RegisterWeightForm()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> RegisterWeightForm(WeightFormInputModel weightInputModel)
        {
            if (ModelState.IsValid)
            {
                await _fuelAndWeightService.AddWeightForm(weightInputModel);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
