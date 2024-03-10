using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using UIXtimate.Data;
using UIXtimate.Models;
using UIXtimate.Models.PostViewModels;
using UIXtimate.Models.ViewModels;

namespace UIXtimate.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPost _postService;
        private readonly UserManager<User> _userManager;
        public PostsController(IPost postService, UserManager<User> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }
        //public IActionResult AllPosts()
        //{
        //    var posts = _postService
        //        .GetAllPosts()
        //        .Select(post => new PostsListViewModel()
        //        {
        //            Id = post.Id,
        //            Title = post.Title,
        //            Description = post.Description
        //        });
        //    var model = new HomeIndexViewModel
        //    {
        //        PostsList = posts
        //    };
        //    return View(model);
        //}

        public IActionResult OpenPostById(int id)
        {
            var post = (_postService.GetPostById(id));
            var postContVM = new PostContentViewModel
            {
                Title = post.Title,
                Description = post.Description,
                Created = post.Created.ToShortDateString(),
                Author = post.Author.UserName,
                Replies = post.Replies
            };

            var model = new PostContent
            {
                PostContentVM = postContVM
            };
            return View(model);
        }
        public IActionResult CreateNewPost()
        {
            var model = new NewPostModel
            {
                AuthorName = User.Identity.Name
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = BuildPost(model, user);
            await _postService.Create(post);
            //сюда юзер рейтинг манипуляции
            return RedirectToAction("OpenPostById", "Posts", post.Id);
        }
        private Post BuildPost(NewPostModel model, User user)
        {
            return new Post
            {
                Title = model.Title,
                Description = model.Description,
                Author = user,
                Created = DateTime.Now,
                Views = 0,
                EstimationsCount = 0
            };
        }
    }
}
