using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.Domain.Models.Base
{
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
    }
}
