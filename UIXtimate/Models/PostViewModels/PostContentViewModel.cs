﻿namespace UIXtimate.Models.PostViewModels
{
    public class PostContentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Created { get; set; }
        public string UserName { get; set; }
        public IQueryable<PostReply> Replies { get; set; }
    }
}
