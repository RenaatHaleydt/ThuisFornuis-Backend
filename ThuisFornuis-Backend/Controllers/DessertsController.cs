using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ThuisFornuis_Backend.Models;
using ThuisFornuis_Backend.Models.Domain.IRepositories;

namespace ThuisFornuis_Backend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class DessertsController : ControllerBase
    {
        private readonly IDessertsRepository _dessertsRepository;

        public DessertsController(IDessertsRepository dessertsRepository)
        {
            _dessertsRepository = dessertsRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Dessert> Get()
        {
            return _dessertsRepository.GetAll();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Dessert> GetDessert(int id)
        {
            var dessert = _dessertsRepository.GetBy(id);
            if (dessert == null)
            {
                return NotFound();
            }
            return dessert;
        }

        [HttpPost]
        public ActionResult<Dessert> PostDessert(Dessert dessert)
        {
            Dessert dessertToCreate = new Dessert(dessert.Naam, dessert.Prijs, dessert.Hoeveelheid, dessert.Omschrijving, dessert.Foto);
            _dessertsRepository.Add(dessertToCreate);
            _dessertsRepository.SaveChanges();
            //201 + link naar gecreeerd dessert + optioneel het gecreerde dessert
            return CreatedAtAction(nameof(GetDessert), new { id = dessertToCreate.Id }, dessertToCreate);
        }

        [HttpPut("{id}")]
        public ActionResult<Dessert> PutDessert(int id, Dessert dessert)
        {
            if (!_dessertsRepository.TryGetDessert(id, out var des))
            {
                return NotFound();
            }
            des.Naam = dessert.Naam;
            des.Omschrijving = dessert.Omschrijving;
            des.Prijs = dessert.Prijs;
            des.Foto = dessert.Foto;
            des.Hoeveelheid = dessert.Hoeveelheid;
            _dessertsRepository.Update(des);
            _dessertsRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Dessert> DeleteDessert(int id)
        {
            Dessert dessert = _dessertsRepository.GetBy(id);
            if (dessert == null)
            {
                return NotFound();
            }
            _dessertsRepository.Delete(dessert);
            _dessertsRepository.SaveChanges();
            return dessert;
        }
    }
}
