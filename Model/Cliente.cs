using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Ventas.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechayhoraAlta { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
