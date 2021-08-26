using System;
using System.Collections.Generic;

#nullable disable

namespace Api_Ventas.Model
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int IdProducto { get; set; }
        public int IdSucursal { get; set; }
        public int PzDisponibles { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Sucursal IdSucursalNavigation { get; set; }
    }
}
