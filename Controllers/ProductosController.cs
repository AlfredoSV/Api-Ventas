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
        public ActionResult ConsultarProductos(DtoConsultarProducto dtoConsultarProducto)
        {
            IEnumerable<Dtos.DtoProducto> resultado = !dtoConsultarProducto.Id.HasValue ? _context.Productos.Where(p => p.Estatus != "Inactivo").Select(p => new Dtos.DtoProducto() { Nombre = p.NombreProducto, CostoPz = p.CostoPz, CostoPzMayoreo = p.CostoPzMayoreo,Estatus= p.Estatus }).ToList() :
                _context.Productos.Where(s => s.IdProducto == dtoConsultarProducto.Id && s.Estatus != "Inactivo").Select(p => new Dtos.DtoProducto() { Nombre = p.NombreProducto, CostoPz = p.CostoPz, CostoPzMayoreo = p.CostoPzMayoreo, Estatus = p.Estatus }).ToList();
			if(resultado.Count() == 0)
				return NoContent();
			
           return Ok(resultado);
        }

        [HttpDelete("[action]")]

        public bool Delete(DtoConsultarProducto dtoConsultarProducto){

            var res = _context.Productos.Where(p => p.IdProducto == dtoConsultarProducto.Id).ToList();
            
            res.ForEach(p => p.Estatus = "Inactivo" );

            _context.SaveChanges();
            
            return (_context.Productos.Where(p => p.IdProducto == dtoConsultarProducto.Id && p.Estatus == "Activo" ).Count()
                                                                                                 == 0);
        }

        [HttpPost("[action]")]
        public ActionResult Post(DtoProducto dtoProducto){

            _context.Productos.Add(new Producto(){
					
					NombreProducto = dtoProducto.Nombre,
					CostoPz = dtoProducto.CostoPz,
					CostoPzMayoreo  = dtoProducto.CostoPzMayoreo,
					Estatus = dtoProducto.Estatus
				
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
