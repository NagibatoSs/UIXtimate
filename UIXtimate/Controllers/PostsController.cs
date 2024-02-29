using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using UIXtimate.Data;
using UIXtimate.Models;
using UIXtimate.Models.PostViewModels;

namespace UIXtimate.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPost _postService;
        public PostsController(IPost postService)
        {
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
            var model = new PostIndexViewModel
            {
                PostsList = posts
            };
            return View(model);
        }

        public IActionResult OpenThePost(int id)
        {
            var post = (_postService.GetPostById(id));
            var postContVM = new PostContentViewModel
            {
                Title = post.Title,
                Description = post.Description,
                Created = post.Created.ToShortDateString(),
                Author = post.Author.UserName,
                Replies = (IQueryable<PostReply>)post.Replies
            };

            var model = new PostContent
            {
                PostContentVM = postContVM
            };
            return View(model);
        }
    }
}
