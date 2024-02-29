using Microsoft.EntityFrameworkCore;
using UIXtimate.Data;
using UIXtimate.Models;

namespace UIXtimate.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Create(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetAllPosts()
        {
            return _context.Posts
                .Include(post => post.Replies)
                .Include(post => post.Author);
        }

        public IEnumerable<PostReply> GetAllPostsReplies()
        {
            throw new NotImplementedException();
        }

        public User GetAuthor()
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int id)
        {
            var post = _context.Posts
                .Where(post => post.Id == id)
                .Include(post => post.Replies)
                    .ThenInclude(r => r.Author)
                .Include(post => post.Author)
                .FirstOrDefault();
            return post;
        }

        public Task UpdatePostDescription(int postId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostTitle(int postId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
