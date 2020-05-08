using System;
using System.Collections.Generic;

namespace Entity_Framework
{
    public partial class OrderSubtotals
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
