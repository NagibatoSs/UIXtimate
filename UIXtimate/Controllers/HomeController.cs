using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UIXtimate.Data;
using UIXtimate.Models;
using UIXtimate.Models.PostViewModels;
using UIXtimate.Service;

namespace UIXtimate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPost _postService;

        public HomeController(ILogger<HomeController> logger, IPost postService)
        {
            _logger= logger;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var posts = _postService
                .GetAllPosts()
                .Select(post => new PostsListViewModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description
                });
            var model = new HomeIndexViewModel
            {
                PostsList = posts
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
