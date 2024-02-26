using UIXtimate.Models;

namespace UIXtimate.trash
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string Author { get; set; }
        // public string AuthorUrl { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }
        //public IEnumerable<string> FigmasUrls {  get; set; }
        //public IEnumerable<string> ImagesUrls {  get; set; }

        //public virtual IEnumerable<Post> Posts { get; set; }

    }
}
