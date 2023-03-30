using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public partial class VehiculoPersonalizado
    {
        public VehiculoPersonalizado()
        {
            VentaPrecioVehiculoPersonalizadoNavigations = new HashSet<Venta>();
            VentaVinVehiculoPersonalizadoNavigations = new HashSet<Venta>();
        }

        public int IdConstruccionVehiculo { get; set; }
        public int? IdMarca { get; set; }
        public int? IdModelo { get; set; }
        public string? Vin { get; set; }
        public int? ColorExterior { get; set; }
        public int? ColorInterior { get; set; }
        public int? Extra01 { get; set; }
        public int? Extra02 { get; set; }
        public int? Extra03 { get; set; }
        public int? Extra04 { get; set; }
        public int? Extra05 { get; set; }
        public int? Extra06 { get; set; }
        public int? Extra07 { get; set; }
        public int? Extra08 { get; set; }
        public int? Extra09 { get; set; }
        public int? Extra10 { get; set; }
        public int? Extra11 { get; set; }
        public int? Extra12 { get; set; }
        public int? Extra13 { get; set; }
        public int? Extra14 { get; set; }
        public int? Extra15 { get; set; }
        public int? Extra16 { get; set; }
        public int? Extra17 { get; set; }
        public int? Extra18 { get; set; }
        public int? Extra19 { get; set; }
        public int? Extra20 { get; set; }
        public decimal? Precio { get; set; }

        public virtual ColorExterior? ColorExteriorNavigation { get; set; }
        public virtual ColorInterior? ColorInteriorNavigation { get; set; }
        public virtual EquipamientoExtra? Extra01Navigation { get; set; }
        public virtual EquipamientoExtra? Extra02Navigation { get; set; }
        public virtual EquipamientoExtra? Extra03Navigation { get; set; }
        public virtual EquipamientoExtra? Extra04Navigation { get; set; }
        public virtual EquipamientoExtra? Extra05Navigation { get; set; }
        public virtual EquipamientoExtra? Extra06Navigation { get; set; }
        public virtual EquipamientoExtra? Extra07Navigation { get; set; }
        public virtual EquipamientoExtra? Extra08Navigation { get; set; }
        public virtual EquipamientoExtra? Extra09Navigation { get; set; }
        public virtual EquipamientoExtra? Extra10Navigation { get; set; }
        public virtual EquipamientoExtra? Extra11Navigation { get; set; }
        public virtual EquipamientoExtra? Extra12Navigation { get; set; }
        public virtual EquipamientoExtra? Extra13Navigation { get; set; }
        public virtual EquipamientoExtra? Extra14Navigation { get; set; }
        public virtual EquipamientoExtra? Extra15Navigation { get; set; }
        public virtual EquipamientoExtra? Extra16Navigation { get; set; }
        public virtual EquipamientoExtra? Extra17Navigation { get; set; }
        public virtual EquipamientoExtra? Extra18Navigation { get; set; }
        public virtual EquipamientoExtra? Extra19Navigation { get; set; }
        public virtual EquipamientoExtra? Extra20Navigation { get; set; }
        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual Modelo? IdModeloNavigation { get; set; }
        public virtual ICollection<Venta> VentaPrecioVehiculoPersonalizadoNavigations { get; set; }
        public virtual ICollection<Venta> VentaVinVehiculoPersonalizadoNavigations { get; set; }
    }
}
