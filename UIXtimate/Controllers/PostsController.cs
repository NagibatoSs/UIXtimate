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
        ////} 
        //[HttpPost]
        //public IActionResult AddVisualContent(NewPostModel model)
        //{
        //    if (model.VisualContents == null)
        //        model.VisualContents = new List<string>();
        //    model.VisualContents.Add(new PostVisualContent());
        //    return RedirectToAction("CreateNewPost", model);
        //   // return RedirectToAction("CreateNewPost", "Posts", model);
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
                Replies = post.Replies,
                VisualContents = post.VisualContents
            };

            var model = new PostContent
            {
                PostContentVM = postContVM
            };
            return View(model);
        }
        public IActionResult CreateNewPost(NewPostModel model = null)
        {
            if (model == null)
            {
                model = new NewPostModel
                {
                    AuthorName = User.Identity.Name,
                    // Title = 
                };
            }
            if (model.VisualContents == null)
                model.VisualContents = new List<string>();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            //var userId = _userManager.GetUserId(User);
            var userId = "1";
            var user = _userManager.FindByIdAsync(userId).Result;
            var post = BuildPost(model, user);
            _postService.Create(post).Wait();
            //сюда юзер рейтинг манипуляции
            return RedirectToAction("OpenPostById", "Posts",new { id = post.Id });
        }
        private Post BuildPost(NewPostModel model, User user)
        {
            var post = new Post
            {
                Title = model.Title,
                Description = model.Description,
                Author = user,
                Created = DateTime.Now,
                Views = 0,
                EstimationsCount = 0,
                VisualContents = new List<PostVisualContent>()
            };
            foreach(var content in model.VisualContents)
            {
                var visual = new PostVisualContent() { ContentUrl = content };
                post.VisualContents.Add(visual);
            }
            return post;
        }
    }
}
