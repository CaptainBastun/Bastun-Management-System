namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class PAXController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult OffloadEdit()
        {
            return View();
        }
      
    }
}
