using System.Collections;
using UIXtimate.Models;

namespace UIXtimate.Data
{
    public interface IPost
    {
        Post GetPostById(int id);
        IQueryable<Post> GetAllPosts();
        IEnumerable<PostReply> GetAllPostsReplies();
        User GetAuthor();

        Task Create(Post post);
        Task Delete(int postId);
        Task UpdatePostTitle(int postId, string newTitle);
        Task UpdatePostDescription(int postId, string newDescription);
    }
}
