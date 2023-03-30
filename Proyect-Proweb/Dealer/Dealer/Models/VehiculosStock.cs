using System;
using System.Collections.Generic;
using Dealer.Models;

namespace Dealer.Models
{
    public partial class VehiculosStock
    {
        public VehiculosStock()
        {
            VentaPrecioVehiculoStockNavigations = new HashSet<Venta>();
            VentaVinVehiculoStockNavigations = new HashSet<Venta>();
        }

        public int IdVehiculoStock { get; set; }
        public int? IdMarca { get; set; }
        public int? IdModelo { get; set; }
        public string? Vin { get; set; }
        public int? ColorExterior { get; set; }
        public int? ColorInterior { get; set; }
        public string? Anio { get; set; }
        public string? DescripcionEquipamientoExtra { get; set; }
        public decimal? Precio { get; set; }
        public string? Img { get; set; }
        public int? Condicion { get; set; }

        public virtual ColorExterior? ColorExteriorNavigation { get; set; }
        public virtual ColorInterior? ColorInteriorNavigation { get; set; }
        public virtual CondicionVehiculo? CondicionNavigation { get; set; }
        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual Modelo? IdModeloNavigation { get; set; }
        public virtual ICollection<Venta> VentaPrecioVehiculoStockNavigations { get; set; }
        public virtual ICollection<Venta> VentaVinVehiculoStockNavigations { get; set; }
    }
}
