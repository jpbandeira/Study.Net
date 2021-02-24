using EFCOre.WebAPI.Data;
using EFCOre.WebAPI.Model;
using EFCOre.WebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCOre.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly EFCoreRepository _repository;
        public ValuesController(EFCoreRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listHeroi = await _repository.GetAll();
            return Ok(listHeroi);
        }

        // GET api/values/nome
        [HttpGet("{filtro}")]
        public ActionResult<string> Get(string filtro)
        {
            var listHeroi = new List<Heroi>();
            listHeroi = _repository.Herois
                                .Where(where => where.Nome.Contains(filtro))
                                .ToList();
            /*
            listHeroi = (from heroi in _context.Herois where heroi.Nome.Contains(filtro) select heroi).ToList();
            
            listHeroi = _context.Herois
                                .Where(where => where.Nome.Contains(filtro))
                                .OrderBy(order => order.Id)
                                .ToList();

            listHeroi = _context.Herois
                                .Where(where => where.Nome.Contains(filtro))
                                .OrderByDescending(order => order.Id)
                                .ToList();
            */

            return Ok(listHeroi);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] Heroi value)
        {
            // O EF faz uma analise do estado do objeto antes de salvar no banco
            // caso o objeto venha com dados preenchidos, menos o ID, ele percebe que se trata de um insert
            // caso o objeto venha com dados preenchidos e o ID, ele percebe que se trata de um update

            _repository.Add(value);
            await _repository.SaveChangeAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Heroi> Put(int id, [FromBody] Heroi heroiParam)
        {
            Heroi heroi = new Heroi();

            // Existem consultas que travam o objeto, não permitindo fazer alterações nele e persistir no banco
            // Utilizando a função AsNoTrackinh() eu informo que não quero travar esse objeto.
            // Dessa forma é possível criar consultas diretamente sem utilziar a função Where(), como demonstrado abaixo!
            /*
             heroi = _context.Herois.AsNoTracking().SingleOrDefault(where => where.Id == id);
            */
            
            heroi = _context.Herois.Where(where => where.Id == id).Single();
            heroi = heroiParam;
            _repository.Update(heroi);
            _context.SaveChanges();

            return Ok(heroi);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Heroi heroi = _context.Herois
                               .Where(where => where.Id == id).Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}
