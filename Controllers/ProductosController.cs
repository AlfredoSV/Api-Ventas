using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api_Ventas.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Api_Ventas.Dtos;

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

        [HttpGet("[action]")]
        public ActionResult ConsultarProductos(int? id)
        {
            IEnumerable<Dtos.DtoProducto> resultado = !id.HasValue ? _context.Productos.Where(p => p.Estatus != "Inactivo").Select(p => new Dtos.DtoProducto() {IdProducto = p.IdProducto ,NombreProducto = p.NombreProducto, CostoPz = p.CostoPz, CostoPzMayoreo = p.CostoPzMayoreo,Estatus= p.Estatus }).ToList() :
                _context.Productos.Where(s => s.IdProducto == id && s.Estatus != "Inactivo").Select(p => new Dtos.DtoProducto() {IdProducto = p.IdProducto, NombreProducto = p.NombreProducto, CostoPz = p.CostoPz, CostoPzMayoreo = p.CostoPzMayoreo, Estatus = p.Estatus }).ToList();
			if(resultado.Count() == 0)
				return NoContent();
			
           return Ok(resultado);
        }

        [HttpDelete("[action]")]
        public ActionResult EliminarProducto(int? id)
        {

            var res = _context.Productos.Where(p => p.IdProducto == id).ToList();
            
            res.ForEach(p => p.Estatus = "Inactivo" );

            _context.SaveChanges();
            
            return Ok(new { Eliminado = !_context.Productos.Where(p => p.IdProducto == id && p.Estatus == "Activo").Any() });
        }

        [HttpPost("[action]")]
        public ActionResult CrearProducto(DtoProducto dtoProducto){

            _context.Productos.Add(new Producto(){
					
					NombreProducto = dtoProducto.NombreProducto,
					CostoPz = dtoProducto.CostoPz,
					CostoPzMayoreo  = dtoProducto.CostoPzMayoreo,
					Estatus = dtoProducto.Estatus
				
			});
            _context.SaveChanges(); 

			return StatusCode(201);			

        }
		
		[HttpPut("[action]")]
        public ActionResult EditarProducto(DtoProducto dtoProducto){
			
			var res = _context.Productos.Where(pro => pro.IdProducto == dtoProducto.IdProducto).ToList();
            
            foreach(var reg in res){
				reg.NombreProducto = dtoProducto.NombreProducto;
				reg.CostoPz = dtoProducto.CostoPz;
				reg.CostoPzMayoreo  = dtoProducto.CostoPzMayoreo;
				reg.Estatus = dtoProducto.Estatus;
			}
			
            
            _context.SaveChanges(); 

			return NoContent();			

        }
		
        

    }
}
