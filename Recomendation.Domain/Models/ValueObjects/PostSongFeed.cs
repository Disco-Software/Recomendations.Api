using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Models.ValueObjects
{
    public class PostSongFeed
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public string Source { get; set; }

        public string ExecutorName { get; set; }

    }
}
