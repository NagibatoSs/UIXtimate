namespace UIXtimate.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int Views {  get; set; }
        public int EstimationsCount { get; set; }
        // RepliesCount??
        public virtual List<PostVisualContent> VisualContents { get; set; }
        public virtual List<PostReply> Replies { get; set; }

        public virtual User Author { get; set; }
        // public string AuthorUrl { get; set; }
        //public IEnumerable<string> FigmasUrls {  get; set; }
        //public IEnumerable<string> ImagesUrls {  get; set; }
    }
}
