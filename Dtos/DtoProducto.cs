using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Ventas.Dtos
{
    public class DtoProducto
    {
        public string Nombre { get; set; }
        public float CostoPz { get; set; }
        public float? CostoPzMayoreo { get; set; }
        public string Estatus { get; set; }
    }
}
