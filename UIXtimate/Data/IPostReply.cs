using UIXtimate.Models;

namespace UIXtimate.Data
{
    public interface IPostReply
    {
        PostReply GetPostReplyById(int id);
        IEnumerable<PostReply> GetUserPostReplies(string userId);
        IEnumerable<PostReply> GetAllPostsReplies();
        User GetAuthor();

        Task Create(PostReply postReply);
        Task Delete(int postReplyId);
        //Task UpdatePostTitle(int postReplyId, string newTitle);
        //Task UpdatePostDescription(int postId, string newDescription);
    }
}
