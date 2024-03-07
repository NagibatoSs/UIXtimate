using Microsoft.EntityFrameworkCore;
using UIXtimate.Data;
using UIXtimate.Models;

namespace UIXtimate.Service
{
    public class PostReplyService : IPostReply
    {
        private readonly ApplicationDbContext _context;
        public PostReplyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Create(PostReply postReply)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int postReplyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostReply> GetAllPostsReplies()
        {
            return _context.PostReplies
                .Include(post => post.Author)
                .Include(post => post.Post);
        }

        public User GetAuthor()
        {
            throw new NotImplementedException();
        }

        public PostReply GetPostReplyById(int id)
        {
            IQueryable<PostReply> postReplies = _context.PostReplies
                .Where(reply => reply.Id == id)
                .Include(post => post.Author)
                .Include(post => post.Post);
            //.Include(post => post.Replies)
            //   .ThenInclude(r => r.Author)
            //.Include(post => post.Author);
            return postReplies.FirstOrDefault();
        }
    }
}
