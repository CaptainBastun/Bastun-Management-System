namespace BMS.ViewComponents
{
    using BMS.ViewComponents.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ViewComponent(Name = "ErrorAlert")]
    public class ErrorAlertViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string message)
        {
            var viewModel = new ErrorAlertViewModel
            {
                ErrorMessage = message
            };

            return View(viewModel);
        }
    }
}
