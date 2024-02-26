using Microsoft.AspNetCore.Identity;

namespace UIXtimate.Models
{
    public class User: IdentityUser
    {
        public string ProfImg { get; set; }

        public int Reputation { get; set; }
        public int Points { get; set; }

    }
}
