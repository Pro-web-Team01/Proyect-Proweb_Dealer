using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public partial class ColorInterior
    {
        public ColorInterior()
        {
            VehiculoPersonalizados = new HashSet<VehiculoPersonalizado>();
            VehiculosStocks = new HashSet<VehiculosStock>();
        }

        public int IdColorInterior { get; set; }
        public string? ColorInterior1 { get; set; }
        public decimal? PrecioColorInterior { get; set; }

        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizados { get; set; }
        public virtual ICollection<VehiculosStock> VehiculosStocks { get; set; }
    }
}
