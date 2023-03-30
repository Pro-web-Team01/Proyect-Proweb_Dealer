using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public partial class ServicioOficial
    {
        public ServicioOficial()
        {
            ServicioOficialVendedores = new HashSet<ServicioOficialVendedore>();
            Venta = new HashSet<Venta>();
        }

        public int IdServicioOficial { get; set; }
        public int? IdConcesionario { get; set; }
        public string? NombreServicioOficial { get; set; }
        public string? DomicilioServicioOficial { get; set; }
        public string? RncServicioOficial { get; set; }
        public string? ImgConcesionario { get; set; }

        public virtual Concesionario? IdConcesionarioNavigation { get; set; }
        public virtual ICollection<ServicioOficialVendedore> ServicioOficialVendedores { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
