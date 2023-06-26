using AutoMapper;
using Disco.Domain.Events.Dto;
using Recomendation.Domain.Models.Aggregates;
using Recomendation.Domain.Models.ValueObjects;
using Recomendation.Events.Dtos;
using Recomendation.Events.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.EventListener.Mappers
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<PostImageDto, PostImageFeed>();
            CreateMap<PostVideoDto, PostVideoFeed>();
            CreateMap<PostSongDto, PostSongFeed>();
            CreateMap<LikeDto, LikeFeed>();
            CreateMap<CommentDto, CommentFeed>();
            CreateMap<UserDto, UserFeed>();
            CreateMap<AccountDto, AccountFeed>();
            CreateMap<UserFollowerDto, UserFollowerFeed>();

            CreateMap<PostCreatedEvent, PostFeed>();
        }
    }
}
