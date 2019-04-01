using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ThuisFornuis_Backend.DTOs;
using ThuisFornuis_Backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThuisFornuis_Backend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenusRepository _menusRepository;

        public MenusController(IMenusRepository menusRepository)
        {
            _menusRepository = menusRepository;
        }

        //----------------------------Menus----------------------------
        [HttpGet]
        public IEnumerable<Menu> GetMenus()
        { 
            return _menusRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Menu> GetMenu(int id)
        {
            var menu = _menusRepository.GetBy(id);
            if (menu == null)
            {
                return NotFound();
            }
            return menu;
        }

        [HttpPost]
        public ActionResult<Menu> PostMenu(MenuDTO menu)
        {
            Menu menuToCreate = new Menu(menu.Datum, menu.Omschrijving);
            if (menu.Gerechten != null)
            {
                foreach (var gerecht in menu.Gerechten)
                    menuToCreate.AddGerecht(new Gerecht(gerecht.Naam, gerecht.Prijs, gerecht.Hoeveelheid, gerecht.Omschrijving, gerecht.Foto));
            }
            if (menu.Soepen != null)
            {
                foreach (var soep in menu.Soepen)
                    menuToCreate.AddSoep(new Soep(soep.Naam, soep.Prijs, soep.Hoeveelheid, soep.Omschrijving, soep.Foto));
            }
            if(menu.Desserts != null)
            {
                foreach (var dessert in menu.Desserts)
                    menuToCreate.AddDessert(new Dessert(dessert.Naam, dessert.Prijs, dessert.Hoeveelheid, dessert.Omschrijving, dessert.Foto));
            }
            _menusRepository.Add(menuToCreate);
            _menusRepository.SaveChanges();
            //201 + link naar gecreeerd menu + optioneel het gecreerde menu
            return CreatedAtAction(nameof(GetMenu), new { id = menuToCreate.Id }, menuToCreate);
        }

        [HttpPut("{id}")]
        public IActionResult PutMenu(int id, Menu menu)
        {
            if (id != menu.Id)
            {
                return BadRequest();
            }
            _menusRepository.Update(menu);
            _menusRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Menu> DeleteMenu(int id)
        {
            Menu menu = _menusRepository.GetBy(id);
            if (menu == null)
            {
                return NotFound();
            }
            _menusRepository.Delete(menu);
            _menusRepository.SaveChanges();
            return menu;
        }


        //----------------------------Gerechten----------------------------
        [HttpGet("{id}/gerechten")]
        public IEnumerable<Gerecht> GetGerechten(int id)
        {
            if(!_menusRepository.TryGetMenu(id, out var menu))
            {
                return new List<Gerecht>();
                //return NotFound();
            }
            return menu.Gerechten.OrderBy(g => g.Naam);
        }

        [HttpGet("{id}/gerechten/{gerechtId}")]
        public ActionResult<Gerecht> GetGerecht(int id, int gerechtId)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
                return NotFound();
            Gerecht gerecht = menu.GetGerecht(gerechtId);
            if (gerecht == null)
                return NotFound();
            return gerecht;
        }

        [HttpPost("{id}/gerechten")]
        public ActionResult<Gerecht> PostGerecht(int id, GerechtDTO gerecht)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return NotFound();
            }
            var gerechtToCreate = new Gerecht(gerecht.Naam, gerecht.Prijs, gerecht.Hoeveelheid, gerecht.Omschrijving, gerecht.Foto);
            menu.AddGerecht(gerechtToCreate);
            _menusRepository.SaveChanges();
            return CreatedAtAction("GetGerecht", new { id = menu.Id, gerechtId = gerechtToCreate.Id }, gerechtToCreate);
        }

        [HttpDelete("{id}/gerechten/{gerechtId}")]
        public ActionResult<Gerecht> DeleteGerecht(int id, int gerechtId)
        {
            Menu menu = _menusRepository.GetBy(id);
            if (menu == null)
                return NotFound();
            Gerecht gerecht = menu.GetGerecht(gerechtId);
            if (gerecht == null)
                return NotFound();

            menu.DeleteGerecht(gerecht);
            _menusRepository.SaveChanges();
            return gerecht;
        }

        //----------------------------Soepen----------------------------
        [HttpGet("{id}/soepen")]
        public IEnumerable<Soep> GetSoepen(int id)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return new List<Soep>();
                //return NotFound();
            }
            return menu.Soepen.OrderBy(s => s.Naam);
        }

        [HttpGet("{id}/soepen/{soepId}")]
        public ActionResult<Soep> GetSoep(int id, int soepId)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
                return NotFound();
            Soep soep = menu.GetSoep(soepId);
            if (soep == null)
                return NotFound();
            return soep;
        }

        [HttpPost("{id}/soepen")]
        public ActionResult<Soep> PostSoep(int id, SoepDTO soep)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return NotFound();
            }
            var soepToCreate = new Soep(soep.Naam, soep.Prijs, soep.Hoeveelheid, soep.Omschrijving, soep.Foto);
            menu.AddSoep(soepToCreate);
            _menusRepository.SaveChanges();
            return CreatedAtAction("GetSoep", new { id = menu.Id, soepId = soepToCreate.Id }, soepToCreate);
        }

        [HttpDelete("{id}/soepen/{soepId}")]
        public ActionResult<Soep> DeleteSoep(int id, int soepId)
        {
            Menu menu = _menusRepository.GetBy(id);
            if (menu == null)
                return NotFound();
            Soep soep = menu.GetSoep(soepId);
            if (soep == null)
                return NotFound();

            menu.DeleteSoep(soep);
            _menusRepository.SaveChanges();
            return soep;
        }

        //----------------------------Desserts----------------------------
        [HttpGet("{id}/desserts")]
        public IEnumerable<Dessert> GetDesserts(int id)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return new List<Dessert>();
                //return NotFound();
            }
            return menu.Desserts.OrderBy(d => d.Naam);
        }

        [HttpGet("{id}/desserts/{dessertId}")]
        public ActionResult<Dessert> GetDessert(int id, int dessertId)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
                return NotFound();
            Dessert dessert = menu.GetDessert(dessertId);
            if (dessert == null)
                return NotFound();
            return dessert;
        }

        [HttpPost("{id}/desserts")]
        public ActionResult<Dessert> PostDessert(int id, DessertDTO dessert)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return NotFound();
            }
            var dessertToCreate = new Dessert(dessert.Naam, dessert.Prijs, dessert.Hoeveelheid, dessert.Omschrijving, dessert.Foto);
            menu.AddDessert(dessertToCreate);
            _menusRepository.SaveChanges();
            return CreatedAtAction("GetDessert", new { id = menu.Id, dessertId = dessertToCreate.Id }, dessertToCreate);
        }

        [HttpDelete("{id}/desserts/{dessertId}")]
        public ActionResult<Dessert> DeleteDessert(int id, int dessertId)
        {
            Menu menu = _menusRepository.GetBy(id);
            if (menu == null)
                return NotFound();
            Dessert dessert = menu.GetDessert(dessertId);
            if (dessert == null)
                return NotFound();

            menu.DeleteDessert(dessert);
            _menusRepository.SaveChanges();
            return dessert;
        }

    }
}
