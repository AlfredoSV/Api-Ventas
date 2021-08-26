using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api_Ventas.Model;

namespace Api_Ventas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
     
        private readonly VentasContext _context;

        
        public ProductosController(VentasContext context)
        {
            _context = context;
        }

        [HttpGet("{id?}")]
        public IEnumerable<Producto> Get(int? id)
        {
            
            return !id.HasValue ? _context.Productos.ToList() :
                     _context.Productos.Where(s => s.IdProducto == id);;
        }

        [HttpPost]
        public void Post(Producto p){

            _context.Productos.Add(p);
            _context.SaveChanges();          

        }
        

    }
}
