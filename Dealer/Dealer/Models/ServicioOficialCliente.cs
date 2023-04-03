using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public partial class ServicioOficialCliente
    {
        public ServicioOficialCliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdCliente { get; set; }
        public int? IdServicioOficial { get; set; }
        public string? NombreCliente { get; set; }
        public string? CedulaCliente { get; set; }
        public string? TelefonoCliente { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
