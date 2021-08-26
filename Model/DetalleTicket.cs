using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Ventas.Model
{
    public partial class DetalleTicket
    {
        public int IdDetalleTicket { get; set; }
        public int IdProducto { get; set; }
        public short Cantidad { get; set; }
        public int IdTicket { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Ticket IdTicketNavigation { get; set; }
    }
}
