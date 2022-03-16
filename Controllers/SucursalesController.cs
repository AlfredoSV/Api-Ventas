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
    public class SucursalesController : ControllerBase
    {
     
        private readonly VentasContext _context;

        
        public SucursalesController(VentasContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public ActionResult ConsultarSucursales(int? id)
        {
            var resultado = !id.HasValue ? _context.Sucursals.Where(s => s.Estatus == "En servicio"):
                     _context.Sucursals.Where(s => s.IdSucursal == id && s.Estatus == "En servicio");
			if(resultado.Count() == 0)
				return NoContent();
			
           return Ok(resultado.Select(s => new DtoSucursal { IdSucursal = s.IdSucursal, NombreSucrusal = s.NombreSucursal, Estatus = s.Estatus }));
        }

        [HttpDelete("[action]")]
        public ActionResult EliminarSucursal(int? id){

            var res = _context.Sucursals.Where(s => s.IdSucursal == id).ToList();
            
            res.ForEach(s => s.Estatus = "Fuera de servicio" );

            _context.SaveChanges();
            
            return Ok(new { Elimnado = !_context.Sucursals.Where(s => s.IdSucursal == id && s.Estatus == "En servicio").Any() });
			
        }

        [HttpPost("[action]")]
        public ActionResult CrearSucursal(DtoSucursal s){

            _context.Sucursals.Add(new Sucursal(){
					
					NombreSucursal = s.NombreSucrusal,
			
					Estatus = s.Estatus
				
			});
            _context.SaveChanges(); 

			return StatusCode(201);			

        }
		
		[HttpPut("[action]")]
        public ActionResult EditarSucursal(DtoSucursal s){
			
			var res = _context.Sucursals.Where(s1 => s1.IdSucursal == s.IdSucursal).ToList();
            
            foreach(var reg in res){
				reg.NombreSucursal = s.NombreSucrusal;
				reg.Estatus = s.Estatus;
			}
			
            
            _context.SaveChanges(); 

			return NoContent();			

        }
		
        

    }
}
