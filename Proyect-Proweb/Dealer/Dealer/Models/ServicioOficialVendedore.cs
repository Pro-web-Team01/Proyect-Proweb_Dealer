using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public partial class ServicioOficialVendedore
    {
        public ServicioOficialVendedore()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdVendedor { get; set; }
        public int? IdServicioOficial { get; set; }
        public string? NombreVendedor { get; set; }
        public string? CedulaVendedor { get; set; }
        public string? Domicilio { get; set; }

        public virtual ServicioOficial? IdServicioOficialNavigation { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
