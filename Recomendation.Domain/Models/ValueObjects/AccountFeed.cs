using Recomendation.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Models.ValueObjects
{
    public class AccountFeed
    {
        public int Id { get; set; }

        public string? Photo { get; set; }

        public List<UserFollowerFeed> UserFollowerDtos { get; set; }
        public List<UserFollowerFeed> UserFollowingDtos { get; set; }

        public UserFeed UserDto { get; set; }

    }
}
