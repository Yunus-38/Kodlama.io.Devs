using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserGithub : Entity
    {
        public int UserId { get; set; }
        public string ProfileLink { get; set; }
        public User? User { get; set; }

        public UserGithub()
        {
        }

        public UserGithub(int id, int userId, string profileLink)
        {
            Id = id;
            UserId = userId;
            ProfileLink = profileLink;
        }
    }
}
