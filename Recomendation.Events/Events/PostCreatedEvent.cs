using Recomendation.Events.Dtos;

namespace Recomendation.Events.Events
{
    public class PostCreatedEvent
    {
        public string Description { get; set; }

        public List<PostImageDto> PostImages { get; set; }
        public List<PostSongDto> PostSongs { get; set; }
        public List<PostSongDto> PostVideos { get; set; }
        public List<LikeDto> Likes { get; set; }
        public DateTime? DateOfCreation { get; set; }

        public AccountDto Account { get; set; }
    }
}
