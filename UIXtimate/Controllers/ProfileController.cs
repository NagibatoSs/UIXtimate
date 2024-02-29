using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UIXtimate.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
