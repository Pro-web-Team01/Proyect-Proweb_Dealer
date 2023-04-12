using System;
using System.Collections.Generic;

namespace Dealer.ModelsTemp
{
    public partial class CondicionVehiculo
    {
        public CondicionVehiculo()
        {
            VehiculosStocks = new HashSet<VehiculosStock>();
        }

        public int IdCondicion { get; set; }
        public string? Condicion { get; set; }

        public virtual ICollection<VehiculosStock> VehiculosStocks { get; set; }
    }
}
