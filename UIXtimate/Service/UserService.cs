﻿using Microsoft.EntityFrameworkCore;
using UIXtimate.Data;
using UIXtimate.Models;

namespace UIXtimate.Service
{
    public class UserService : IUser
    {
        ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Post> GetAllUserPostsById(string id)
        {
            return _context.Posts.Where(p => p.Author.Id == id);
        }

        public IEnumerable<PostReply> GetAllUserPostsRepliesById(string id)
        {
            return _context.PostReplies.Where(p => p.Author.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUserById(string id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Rank)
                .FirstOrDefault();
        }
    }
}
