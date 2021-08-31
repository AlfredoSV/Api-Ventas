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
    public class SucursalesController : ControllerBase
    {
     
        private readonly VentasContext _context;

        
        public SucursalesController(VentasContext context)
        {
            _context = context;
        }

        [HttpGet("{id?}")]
        public ActionResult<List<Sucursal>> Get(int? id)
        {
            IEnumerable<Sucursal> resultado = !id.HasValue ? _context.Sucursals.Where(s => s.Estatus == "En servicio").ToList() :
                     _context.Sucursals.Where(s => s.IdSucursal == id && s.Estatus == "En servicio");
			if(resultado.Count() == 0)
				return NoContent();
			
           return Ok(resultado);
        }

        [HttpDelete("{id}")]

        public bool Delete(int id){

            var res = _context.Sucursals.Where(s => s.IdSucursal == id).ToList();
            
            res.ForEach(s => s.Estatus = "Fuera de servicio" );

            _context.SaveChanges();
            
            return (_context.Sucursals.Where(s => s.IdSucursal == id && s.Estatus == "En servicio" ).Count()
                                                                                                 == 0);
			
        }

        [HttpPost]
        public ActionResult Post(Sucursal s){

            _context.Sucursals.Add(new Sucursal(){
					
					NombreSucursal = s.NombreSucursal,
			
					Estatus = s.Estatus
				
			});
            _context.SaveChanges(); 

			return StatusCode(201);			

        }
		
		[HttpPut]
        public ActionResult Put(Sucursal s){
			
			var res = _context.Sucursals.Where(s1 => s1.IdSucursal == s.IdSucursal).ToList();
            
            foreach(var reg in res){
				reg.NombreSucursal = s.NombreSucursal;
				reg.Estatus = s.Estatus;
			}
			
            
            _context.SaveChanges(); 

			return NoContent();			

        }
		
        

    }
}
