using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using UIXtimate.Data;
using UIXtimate.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UIXtimate.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddReply(PostReply reply)
        {
            throw new NotImplementedException();
        }

        public async Task Create(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllPosts()
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
            IQueryable<Post> posts = _context.Posts
                .Where(post => post.Id == id)
                .Include(post => post.Replies)
                   .ThenInclude(r => r.Author)
                .Include(post => post.Author);
            return posts.FirstOrDefault();
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
