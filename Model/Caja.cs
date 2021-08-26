using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Ventas.Model
{
    public partial class Caja
    {
        public Caja()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdCaja { get; set; }
        public string NombreCaja { get; set; }
        public int IdSucursal { get; set; }
        public string Estatus { get; set; }

        public virtual Sucursal IdSucursalNavigation { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
