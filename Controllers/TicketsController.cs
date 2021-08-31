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
    public class TicketsController : ControllerBase
    {
     
        private readonly VentasContext _context;

        
        public TicketsController(VentasContext context)
        {
            _context = context;
        }

        [HttpGet("{id?}")]
        public ActionResult<List<object>> Get(int? id)
        {
			List<object> resultado;
			if(!id.HasValue){
				
				resultado = (from t in _context.Tickets join c2 in _context.Clientes on  t.IdCliente equals  c2.IdCliente
				group new {t,c2} by new {t.IdCliente,c2.Nombre } into  g select new {id = g.Key.IdCliente,nombre = g.Key.Nombre
				, total= g.Sum(c => c.t.MontoTotal )  }).ToList<object>();
			
			}else{
				
				resultado = (from t in _context.Tickets join c2 in _context.Clientes on  t.IdCliente equals  c2.IdCliente where t.IdCliente == id
				group new {t,c2} by new {t.IdCliente,c2.Nombre } into  g select new {id = g.Key.IdCliente,nombre = g.Key.Nombre
				, total= g.Sum(c => c.t.MontoTotal )  }).ToList<object>();
			
				
			}
            
			
           return Ok(resultado);
        }

       
        

    }
}
