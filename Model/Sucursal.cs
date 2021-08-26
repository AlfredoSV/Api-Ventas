using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Ventas.Model
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Cajas = new HashSet<Caja>();
            Inventarios = new HashSet<Inventario>();
        }

        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string Estatus { get; set; }

        public virtual ICollection<Caja> Cajas { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
