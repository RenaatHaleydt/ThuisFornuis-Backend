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
    public class SoepenController : ControllerBase
    {
        private readonly ISoepenRepository _soepenRepository;

        public SoepenController(ISoepenRepository soepenRepository)
        {
            _soepenRepository = soepenRepository;
        }

        [HttpGet]
        public IEnumerable<Soep> Get()
        {
            return _soepenRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Soep> GetSoep(int id)
        {
            var soep = _soepenRepository.GetBy(id);
            if (soep == null)
            {
                return NotFound();
            }
            return soep;
        }

        [HttpPost]
        public ActionResult<Soep> PostSoep(Soep soep)
        {
            Soep soepToCreate = new Soep(soep.Naam, soep.Prijs, soep.Hoeveelheid, soep.Omschrijving, soep.Foto);
            _soepenRepository.Add(soepToCreate);
            _soepenRepository.SaveChanges();
            //201 + link naar gecreeerd soep + optioneel het gecreerde soep
            return CreatedAtAction(nameof(GetSoep), new { id = soepToCreate.Id }, soepToCreate);
        }

        [HttpPut("{id}")]
        public ActionResult<Soep> PutSoep(int id, Soep soep)
        {
            if (!_soepenRepository.TryGetSoep(id, out var so))
            {
                return NotFound();
            }
            so.Naam = soep.Naam;
            so.Omschrijving = soep.Omschrijving;
            so.Prijs = soep.Prijs;
            so.Foto = soep.Foto;
            so.Hoeveelheid = soep.Hoeveelheid;
            _soepenRepository.Update(so);
            _soepenRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Soep> DeleteSoep(int id)
        {
            Soep soep = _soepenRepository.GetBy(id);
            if (soep == null)
            {
                return NotFound();
            }
            _soepenRepository.Delete(soep);
            _soepenRepository.SaveChanges();
            return soep;
        }
    }
}
