namespace BMS.ViewComponents
{
    using BMS.ViewComponents.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ViewComponent(Name = "SuccessAlert")]
    public class SuccessAlertViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string message)
        {
            var viewModel = new SucessAlertViewModel
            {
                Message = message
            };

            return View(viewModel);
        }
    }
}
