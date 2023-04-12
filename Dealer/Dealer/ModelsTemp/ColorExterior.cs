using System;
using System.Collections.Generic;

namespace Dealer.ModelsTemp
{
    public partial class ColorExterior
    {
        public ColorExterior()
        {
            VehiculoPersonalizados = new HashSet<VehiculoPersonalizado>();
            VehiculosStocks = new HashSet<VehiculosStock>();
        }

        public int IdColorExterior { get; set; }
        public string? ColorExterior1 { get; set; }
        public decimal? PrecioColorExterior { get; set; }
        public string? ColorHex { get; set; }

        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizados { get; set; }
        public virtual ICollection<VehiculosStock> VehiculosStocks { get; set; }
    }
}
