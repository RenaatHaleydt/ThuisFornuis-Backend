using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ThuisFornuis_Backend.Models;
using ThuisFornuis_Backend.Models.Domain.IRepositories;

namespace ThuisFornuis_Backend.Controllers {
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class GerechtenController : ControllerBase {
        private readonly IGerechtenRepository _gerechtenRepository;

        public GerechtenController(IGerechtenRepository gerechtenRepository) {
            _gerechtenRepository = gerechtenRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Gerecht> Get(string naam = null, string omschrijving = null) {
            if (string.IsNullOrEmpty(naam) && string.IsNullOrEmpty(omschrijving))
                return _gerechtenRepository.GetAll();
            return _gerechtenRepository.GetBy(naam, omschrijving);
        }

        [HttpGet("exludeMenu/{menuId}")]
        public IEnumerable<Gerecht> Get(int menuId = 0) {
            if (menuId == 0)
                return _gerechtenRepository.GetAll();
            return _gerechtenRepository.ExcludeFromMenu(menuId);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Gerecht> GetGerecht(int id) {
            var gerecht = _gerechtenRepository.GetBy(id);
            if (gerecht == null) {
                return NotFound();
            }
            return gerecht;
        }

        [HttpPost]
        public ActionResult<Gerecht> PostGerecht(Gerecht gerecht) {
            Gerecht gerechtToCreate = new Gerecht(gerecht.Naam, gerecht.Prijs, gerecht.Hoeveelheid, gerecht.Omschrijving, gerecht.Foto);
            _gerechtenRepository.Add(gerechtToCreate);
            _gerechtenRepository.SaveChanges();
            //201 + link naar gecreeerd gerecht + optioneel het gecreerde gerecht
            return CreatedAtAction(nameof(GetGerecht), new { id = gerechtToCreate.Id }, gerechtToCreate);
        }

        [HttpPut("{id}")]
        public ActionResult<Gerecht> PutGerecht(int id, Gerecht gerecht) {
            if (!_gerechtenRepository.TryGetGerecht(id, out var ger)) {
                return NotFound();
            }
            ger.Naam = gerecht.Naam;
            ger.Omschrijving = gerecht.Omschrijving;
            ger.Prijs = gerecht.Prijs;
            ger.Foto = gerecht.Foto;
            ger.Hoeveelheid = gerecht.Hoeveelheid;
            _gerechtenRepository.Update(ger);
            _gerechtenRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Gerecht> DeleteGerecht(int id) {
            Gerecht gerecht = _gerechtenRepository.GetBy(id);
            if (gerecht == null) {
                return NotFound();
            }
            _gerechtenRepository.Delete(gerecht);
            _gerechtenRepository.SaveChanges();
            return gerecht;
        }
    }
}
