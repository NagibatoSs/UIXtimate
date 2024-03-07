using Microsoft.AspNetCore.Mvc;

namespace UIXtimate.Controllers
{
    public class PostCreationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePost()
        {
            return View();
        }
    }
}
