using System;
using System.Collections.Generic;

namespace Dealer.ModelsTemp
{
    public partial class Concesionario
    {
        public Concesionario()
        {
            ServicioOficials = new HashSet<ServicioOficial>();
            Venta = new HashSet<Venta>();
        }

        public int IdConcesionario { get; set; }
        public string? NombreConcesionario { get; set; }
        public string? Img { get; set; }

        public virtual ICollection<ServicioOficial> ServicioOficials { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
