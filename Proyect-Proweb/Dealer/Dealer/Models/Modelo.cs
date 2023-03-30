using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            EquipamientoExtras = new HashSet<EquipamientoExtra>();
            EquipamientoSeries = new HashSet<EquipamientoSerie>();
            VehiculoPersonalizados = new HashSet<VehiculoPersonalizado>();
            VehiculosStocks = new HashSet<VehiculosStock>();
            Venta = new HashSet<Venta>();
        }

        public int IdModelo { get; set; }
        public int? IdMarca { get; set; }
        public string NombreModelo { get; set; } = null!;
        public string Potencia { get; set; } = null!;
        public string Cilindrada { get; set; } = null!;
        public string Combustible { get; set; } = null!;
        public string? Pasajeros { get; set; }
        public string Traccion { get; set; } = null!;
        public decimal PrecioBase { get; set; }
        public string? ImgModelo { get; set; }

        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual ICollection<EquipamientoExtra> EquipamientoExtras { get; set; }
        public virtual ICollection<EquipamientoSerie> EquipamientoSeries { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizados { get; set; }
        public virtual ICollection<VehiculosStock> VehiculosStocks { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
