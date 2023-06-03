using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recomendation.EventListener.Interfaces
{
    public interface IEventHandler<TEvent>
    {
        Task HandleAsync(TEvent @event);
    }
}
