using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api_Ventas.Model;
using Microsoft.AspNetCore.Http;

namespace Api_Ventas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
     
        private readonly VentasContext _context;

        
        public ProductosController(VentasContext context)
        {
            _context = context;
        }

        [HttpGet("{id?}")]
        public ActionResult<List<Producto>> Get(int? id)
        {
            IEnumerable<Producto> resultado = !id.HasValue ? _context.Productos.Where(p => p.Estatus != "Inactivo").ToList() :
                     _context.Productos.Where(s => s.IdProducto == id && s.Estatus != "Inactivo");
			if(resultado.Count() == 0)
				return NoContent();
			
           return Ok(resultado);
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
        public ActionResult Post(Producto p){

            _context.Productos.Add(new Producto(){
					
					NombreProducto = p.NombreProducto,
					CostoPz = p.CostoPz,
					CostoPzMayoreo  = p.CostoPzMayoreo,
					Estatus = p.Estatus
				
			});
            _context.SaveChanges(); 

			return StatusCode(201);			

        }
		
		[HttpPut]
        public ActionResult Put(Producto p){
			
			var res = _context.Productos.Where(pro => pro.IdProducto == p.IdProducto).ToList();
            
            foreach(var reg in res){
				reg.NombreProducto = p.NombreProducto;
				reg.CostoPz = p.CostoPz;
				reg.CostoPzMayoreo  = p.CostoPzMayoreo;
				reg.Estatus = p.Estatus;
			}
			
            
            _context.SaveChanges(); 

			return NoContent();			

        }
		
        

    }
}
