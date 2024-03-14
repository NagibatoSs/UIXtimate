using System.Collections;
using UIXtimate.Models;

namespace UIXtimate.Data
{
    public interface IPost
    {
        Post GetPostById(int id);
        IEnumerable<Post> GetAllPosts();
        IEnumerable<PostReply> GetAllPostReplies(int id);
        User GetPostAuthorById(int id);
        IEnumerable<Post> GetAllUserPosts(string userId);

        Task Create(Post post);
        Task Delete(int postId);
        Task UpdatePostTitle(int postId, string newTitle);
        Task UpdatePostDescription(int postId, string newDescription);
        Task AddReply(PostReply reply);
    }
}
