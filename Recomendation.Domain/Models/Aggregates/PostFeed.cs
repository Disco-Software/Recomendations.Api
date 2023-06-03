using Recomendation.Domain.Models.Base;
using Recomendation.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Models.Aggregates
{
    public class PostFeed : BaseModel<string>
    {
        public string Description { get; set; }

        public List<PostImageFeed> PostImages { get; set; }
        public List<PostSongFeed> PostSongs { get; set; }
        public List<PostSongFeed> PostVideos { get; set; }
        public List<LikeFeed> Likes { get; set; }
        public DateTime? DateOfCreation { get; set; }

        public int AccountId { get; set; }
        public AccountFeed Account { get; set; }

    }
}
