using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public partial class Account
    {
        public Account()
        {
            Discussion = new HashSet<Discussion>();
            Ticket = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Discussion> Discussion { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
