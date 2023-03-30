using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
            VehiculoPersonalizados = new HashSet<VehiculoPersonalizado>();
            VehiculosStocks = new HashSet<VehiculosStock>();
            Venta = new HashSet<Venta>();
        }

        public int IdMarca { get; set; }
        public string NombreMarca { get; set; } = null!;
        public string? UrlLogoMarca { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizados { get; set; }
        public virtual ICollection<VehiculosStock> VehiculosStocks { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
