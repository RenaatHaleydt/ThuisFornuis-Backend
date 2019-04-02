using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ThuisFornuis_Backend.Models;
using ThuisFornuis_Backend.Models.Domain.IRepositories;

namespace ThuisFornuis_Backend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GerechtenController : ControllerBase
    {
        private readonly IGerechtenRepository _gerechtenRepository;

        public GerechtenController(IGerechtenRepository gerechtenRepository)
        {
            _gerechtenRepository = gerechtenRepository;
        }

        [HttpGet]
        public IEnumerable<Gerecht> Get()
        {
            return _gerechtenRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Gerecht> GetGerecht(int id)
        {
            var gerecht = _gerechtenRepository.GetBy(id);
            if (gerecht == null)
            {
                return NotFound();
            }
            return gerecht;
        }

        [HttpPost]
        public ActionResult<Gerecht> PostGerecht(Gerecht gerecht)
        {
            Gerecht gerechtToCreate = new Gerecht(gerecht.Naam, gerecht.Prijs, gerecht.Hoeveelheid, gerecht.Omschrijving, gerecht.Foto);
            _gerechtenRepository.Add(gerechtToCreate);
            _gerechtenRepository.SaveChanges();
            //201 + link naar gecreeerd gerecht + optioneel het gecreerde gerecht
            return CreatedAtAction(nameof(GetGerecht), new { id = gerechtToCreate.Id }, gerechtToCreate);
        }
        
        [HttpPut("{id}")]
        public ActionResult<Gerecht> PutGerecht(int id, Gerecht gerecht)
        {
            if (id != gerecht.Id)
            {
                return BadRequest();
            }
            _gerechtenRepository.Update(gerecht);
            _gerechtenRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Gerecht> DeleteGerecht(int id)
        {
            Gerecht gerecht = _gerechtenRepository.GetBy(id);
            if (gerecht == null)
            {
                return NotFound();
            }
            _gerechtenRepository.Delete(gerecht);
            _gerechtenRepository.SaveChanges();
            return gerecht;
        }
    }
}
