using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public partial class EquipamientoExtra
    {
        public EquipamientoExtra()
        {
            VehiculoPersonalizadoExtra01Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra02Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra03Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra04Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra05Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra06Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra07Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra08Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra09Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra10Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra11Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra12Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra13Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra14Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra15Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra16Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra17Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra18Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra19Navigations = new HashSet<VehiculoPersonalizado>();
            VehiculoPersonalizadoExtra20Navigations = new HashSet<VehiculoPersonalizado>();
        }

        public int IdEquipamientoExtra { get; set; }
        public int? IdModelo { get; set; }
        public string? NombreEquipamientoExtra { get; set; }
        public decimal? Precio { get; set; }
        public string? Img { get; set; }

        public virtual Modelo? IdModeloNavigation { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra01Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra02Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra03Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra04Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra05Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra06Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra07Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra08Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra09Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra10Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra11Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra12Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra13Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra14Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra15Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra16Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra17Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra18Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra19Navigations { get; set; }
        public virtual ICollection<VehiculoPersonalizado> VehiculoPersonalizadoExtra20Navigations { get; set; }
    }
}
