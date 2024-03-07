using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UIXtimate.Models.PostViewModels;
using UIXtimate.Service;

namespace UIXtimate.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult GetUserProfile(int id)
        //{
        //    var post = (_postService.GetPostById(id));
        //    var postContVM = new PostContentViewModel
        //    {
        //        Title = post.Title,
        //        Description = post.Description,
        //        Created = post.Created.ToShortDateString(),
        //        Author = post.Author.UserName,
        //        Replies = post.Replies
        //    };

        //    var model = new PostContent
        //    {
        //        PostContentVM = postContVM
        //    };
        //    return View(model);
        //}
    }
}
