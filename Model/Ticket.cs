using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Ventas.Model
{
    public partial class Ticket
    {
        public Ticket()
        {
            DetalleTickets = new HashSet<DetalleTicket>();
        }

        public int IdTicket { get; set; }
        public int IdCliente { get; set; }
        public float MontoTotal { get; set; }
        public DateTime Fechayhora { get; set; }
        public int IdCaja { get; set; }

        public virtual Caja IdCajaNavigation { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<DetalleTicket> DetalleTickets { get; set; }
    }
}
