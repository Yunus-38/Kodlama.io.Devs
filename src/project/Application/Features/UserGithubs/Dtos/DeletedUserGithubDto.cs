using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Dtos
{
    public class DeletedUserGithubDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProfileLink { get; set; }
    }
}
