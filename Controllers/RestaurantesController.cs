using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestaurantesApi.Models;

namespace RestaurantesApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class RestaurantesController : Controller
    {
        private readonly Contexto ctx;

        public RestaurantesController(Contexto c)
        {
            ctx = c;
        }

        // GET api/restaurantes
        [HttpGet]
        public IEnumerable<Restaurante> Get()
        {
            return ctx.Restaurantes.ToList();
        }

        // GET api/restaurantes/5
        [HttpGet("{id}", Name = "GetRestaurante")]
        public IActionResult GetById(int id)
        {
            Restaurante rest = ctx.Restaurantes.FirstOrDefault(r => r.RestauranteId == id);
            if (rest != null)
            {
                return new ObjectResult(rest);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/restaurantes
        [HttpPost]
        public IActionResult Post([FromBody]Restaurante obj)
        {
            if (obj != null)
            {
                ctx.Restaurantes.Add(obj);
                ctx.SaveChanges();
                return CreatedAtRoute("GetRestaurante", new { id = obj.RestauranteId }, obj);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/restaurantes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Restaurante obj)
        {
            if (obj == null || obj.RestauranteId != id)
            {
                return BadRequest();
            }
            Restaurante rest = ctx.Restaurantes.FirstOrDefault(r => r.RestauranteId == id);
            if (rest != null)
            {
                rest.Nome = obj.Nome;
                ctx.Restaurantes.Update(rest);
                ctx.SaveChanges();
                return new NoContentResult();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/restaurantes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Restaurante obj = ctx.Restaurantes.FirstOrDefault(r => r.RestauranteId == id);
            if (obj != null)
            {
                ctx.Restaurantes.Remove(obj);
                ctx.SaveChanges();
                return new NoContentResult();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
