using System;
using System.Collections.Generic;

namespace Dealer.Models
{
    public partial class EquipamientoSerie
    {
        public int IdEquipamientoSerie { get; set; }
        public int? IdModelo { get; set; }
        public string NombreEquipamientoExtra { get; set; } = null!;

        public virtual Modelo? IdModeloNavigation { get; set; }
    }
}
