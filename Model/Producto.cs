using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Ventas.Model
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleTickets = new HashSet<DetalleTicket>();
            Inventarios = new HashSet<Inventario>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public float CostoPz { get; set; }
        public float? CostoPzMayoreo { get; set; }
        public string Estatus { get; set; }

        public virtual ICollection<DetalleTicket> DetalleTickets { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
