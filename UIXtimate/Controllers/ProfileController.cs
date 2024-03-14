using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UIXtimate.Data;
using UIXtimate.Models;
using UIXtimate.Models.PostViewModels;
using UIXtimate.Models.ViewModels;
using UIXtimate.Service;

namespace UIXtimate.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUser _userService;
        private readonly IPost _postService;
        private readonly IPostReply _replyService;
        public ProfileController(IUser userService, IPost postService, IPostReply replyService)
        {
            _userService = userService;
            _postService = postService;
            _replyService = replyService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetUserProfile(string id)
        {
            var user = _userService.GetUserById(id);
            var userVM = new UserViewModel
            {
                Login = user.UserName,
                ProfileImgPath = user.ProfImg,
                Reputation = user.Reputation,
                Points = user.Points,
                Rank = user.Rank,
                Posts = _postService.GetAllUserPosts(user.Id).ToList(),
                PostReplies = _replyService.GetUserPostReplies(user.Id).ToList()
            };
            return View(userVM);
        }
    }
}
