using Recomendation.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Models.ValueObjects
{
    public class UserFeed
    {
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}
