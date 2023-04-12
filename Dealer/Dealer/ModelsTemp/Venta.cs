using System;
using System.Collections.Generic;

namespace Dealer.ModelsTemp
{
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Registro { get; set; }
        public int? IdConcesionario { get; set; }
        public int? IdServicioOficial { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public int? VinVehiculoStock { get; set; }
        public int? VinVehiculoPersonalizado { get; set; }
        public int? IdMarca { get; set; }
        public int? IdModelo { get; set; }
        public int? PrecioVehiculoStock { get; set; }
        public int? PrecioVehiculoPersonalizado { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int? MetodoPago { get; set; }

        public virtual ServicioOficialCliente? IdClienteNavigation { get; set; }
        public virtual Concesionario? IdConcesionarioNavigation { get; set; }
        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual Modelo? IdModeloNavigation { get; set; }
        public virtual ServicioOficial? IdServicioOficialNavigation { get; set; }
        public virtual ServicioOficialVendedore? IdVendedorNavigation { get; set; }
        public virtual MetodoPago? MetodoPagoNavigation { get; set; }
        public virtual VehiculoPersonalizado? PrecioVehiculoPersonalizadoNavigation { get; set; }
        public virtual VehiculosStock? PrecioVehiculoStockNavigation { get; set; }
        public virtual VehiculoPersonalizado? VinVehiculoPersonalizadoNavigation { get; set; }
        public virtual VehiculosStock? VinVehiculoStockNavigation { get; set; }
    }
}
