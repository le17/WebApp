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
        private readonly IEFCoreRepository _repo;

        public BatalhaController(IEFCoreRepository Repo)
        {
            _repo = Repo;
        }
        // GET: api/<BatalhaController1>
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            try
            {
                var herois = await _repo.GetAllBatalhas(true);
                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : { ex }");
            }
        }

        // GET api/<BatalhaController1>/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var herois = await _repo.GetBatalhaById(id, true);
                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : { ex }");
            }
        }

        // POST api/<BatalhaController1>
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangAsync())
                {
                    return Ok("BAZINGA");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : { ex }");
            }
            return BadRequest("Não Salvou");
        }

        // PUT api/<BatalhaController1>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Batalha model)
        {
            try
            {
                var heroi = await _repo.GetBatalhaById(id);
                if (heroi != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangAsync())
                        return Ok("BAZINGA");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : { ex }");
            }
            return BadRequest("Não Atualizado");
        }

        // DELETE api/<BatalhaController1>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetBatalhaById(id);
                if (heroi != null)
                {
                    _repo.Delete(heroi);

                    if (await _repo.SaveChangAsync())
                    return Ok("BAZINGA");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro : { ex }");
            }
            return BadRequest("Não Deletado");
        }
    }
}
