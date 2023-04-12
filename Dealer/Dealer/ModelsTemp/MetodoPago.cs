using System;
using System.Collections.Generic;

namespace Dealer.ModelsTemp
{
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdMetodoPago { get; set; }
        public string? MetodoPago1 { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
