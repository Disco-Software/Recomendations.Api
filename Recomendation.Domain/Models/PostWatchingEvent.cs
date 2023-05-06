using Recomendation.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Models
{
    public class PostWatchingEvent : BaseModel<int>
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
