using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly HeroiContext _context;
        public BatalhaController(HeroiContext context)
        {
            _context = context;
        }
        // GET: api/<BatalhaController1>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : { ex }");
            }
        }

        // GET api/<BatalhaController1>/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BatalhaController1>
        [HttpPost]
        public ActionResult Post(Batalha model)
        {
            try
            {

                Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Batalha> entityEntry = _context.Batalhas.Add(model);
                _context.SaveChanges();

                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : { ex }");
            }
        }

        // PUT api/<BatalhaController1>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {
            try
            {
                if (_context.Batalhas.AsNoTracking().FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Batalhas.Update(model);
                    _context.SaveChanges();
                    return Ok("BAZINGA");
                }

                return Ok("Não encontrado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : { ex }");
            }
        }

        // DELETE api/<BatalhaController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
