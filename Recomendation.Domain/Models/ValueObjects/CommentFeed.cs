using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Models.ValueObjects
{
    public class CommentFeed
    {
        public string CommentDescription { get; set; }

        public int AccountId { get; set; }
    }
}
