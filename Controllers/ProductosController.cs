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
            
            return !id.HasValue ? _context.Productos.Where(p => p.Estatus != "Inactivo").ToList() :
                     _context.Productos.Where(s => s.IdProducto == id && s.Estatus != "Inactivo");
        }

        [HttpDelete("{id}")]

        public bool Delete(int id){

            var res = _context.Productos.Where(p => p.IdProducto == id).ToList();
            
            res.ForEach(p => p.Estatus = "Inactivo" );

            _context.SaveChanges();
            
            return (_context.Productos.Where(p => p.IdProducto == id && p.Estatus == "Activo" ).Count()
                                                                                                 == 0);
        }

        [HttpPost]
        public void Post(Producto p){

            _context.Productos.Add(p);
            _context.SaveChanges();          

        }
        

    }
}
