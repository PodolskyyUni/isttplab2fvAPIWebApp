using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isttplab2fvAPIWebApp.Models

{
    public enum OrderStatus
    {
        Received,
        Declined,
        InProcess,
        GivenToDeliveryService,
        Done,
        Canceled
    }

}
