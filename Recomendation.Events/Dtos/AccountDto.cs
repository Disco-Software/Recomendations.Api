﻿using Disco.Domain.Events.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Events.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }

        public string? Photo { get; set; }

        public List<UserFollowerDto> UserFollowerDtos { get; set; }
        public List<UserFollowerDto> UserFollowingDtos { get; set; }

        public UserDto UserDto { get; set; }
    }
}
