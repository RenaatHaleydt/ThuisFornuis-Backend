using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ThuisFornuis_Backend.DTOs;
using ThuisFornuis_Backend.Models;
using ThuisFornuis_Backend.Models.Domain.IRepositories;

namespace ThuisFornuis_Backend.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenusRepository _menusRepository;
        private readonly IGerechtenRepository _gerechtenRepository;

        public MenusController(IMenusRepository menusRepository, IGerechtenRepository gerechtenRepository)
        {
            _menusRepository = menusRepository;
            _gerechtenRepository = gerechtenRepository;
        }

        //----------------------------Menus----------------------------
        [HttpGet]
        public IEnumerable<MenuDTO> GetMenus()
        { 
            return _menusRepository.GetAll().Select(m => MenuDTO.MapMenu(m)).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<MenuDTO> GetMenu(int id)
        {
            var menu = _menusRepository.GetBy(id);
            if (menu == null)
            {
                return NotFound();
            }
            return MenuDTO.MapMenu(menu);
        }

        [HttpPost]
        public ActionResult<MenuDTO> PostMenu(MenuDTO menu)
        {
            Menu menuToCreate = new Menu(menu.Datum, menu.Omschrijving);
            if (menu.Gerechten != null)
            {
                foreach (var gerecht in menu.Gerechten)
                    menuToCreate.AddGerecht(new Gerecht(gerecht.Naam, gerecht.Prijs, gerecht.Hoeveelheid, gerecht.Omschrijving, gerecht.Foto), DateTime.Now);
            }
            if (menu.Soepen != null)
            {
                foreach (var soep in menu.Soepen)
                    menuToCreate.AddSoep(new Soep(soep.Naam, soep.Prijs, soep.Hoeveelheid, soep.Omschrijving, soep.Foto), DateTime.Now);
            }
            if(menu.Desserts != null)
            {
                foreach (var dessert in menu.Desserts)
                    menuToCreate.AddDessert(new Dessert(dessert.Naam, dessert.Prijs, dessert.Hoeveelheid, dessert.Omschrijving, dessert.Foto), DateTime.Now);
            }
            _menusRepository.Add(menuToCreate);
            _menusRepository.SaveChanges();
            //201 + link naar gecreeerd menu + optioneel het gecreerde menu
            return CreatedAtAction(nameof(GetMenu), new { id = menuToCreate.Id }, MenuDTO.MapMenu(menuToCreate));
        }

        //TODO: nakijken!
        //Ik kan MenuDTO niet converten naar Menu, vanwege de MenuGerechten, MenuSoepen en MenuDesserts
        [HttpPut("{id}")]
        public ActionResult<MenuDTO> PutMenu(int id, MenuDTO menuDTO)
        {
            if (id != menuDTO.Id)
            {
                return BadRequest();
            }
            _menusRepository.TryGetMenu(menuDTO.Id, out var menu);
            menu.Omschrijving = menuDTO.Omschrijving;
            menu.Datum = menuDTO.Datum;
            _menusRepository.Update(menu);
            _menusRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<MenuDTO> DeleteMenu(int id)
        {
            Menu menu = _menusRepository.GetBy(id);
            if (menu == null)
            {
                return NotFound();
            }
            _menusRepository.Delete(menu);
            _menusRepository.SaveChanges();
            return MenuDTO.MapMenu(menu);
        }


        //----------------------------Gerechten----------------------------
        [HttpGet("{id}/gerechten")]
        public IEnumerable<GerechtDTO> GetGerechten(int id)
        {
            if(!_menusRepository.TryGetMenu(id, out var menu))
            {
                return new List<GerechtDTO>();
                //return NotFound();
            }
            return menu.MenuGerechten.Select(mg => GerechtDTO.MapGerecht(mg)).OrderBy(g => g.Naam);
        }

        [HttpGet("{id}/gerechten/{gerechtId}")]
        public ActionResult<GerechtDTO> GetGerecht(int id, int gerechtId)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
                return NotFound();
            MenuGerecht menuGerecht = menu.GetMenuGerecht(gerechtId);
            if (menuGerecht == null)
                return NotFound();
            return GerechtDTO.MapGerecht(menuGerecht);
        }

        [HttpPost("{id}/gerechten/{gerechtId}")]
        public ActionResult<GerechtDTO> PostGerecht(int id, int gerechtId)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return NotFound();
            }
            _gerechtenRepository.TryGetGerecht(gerechtId, out var gerecht);
            //var gerechtToCreate = new Gerecht(gerecht.Naam, gerecht.Prijs, gerecht.Hoeveelheid, gerecht.Omschrijving, gerecht.Foto);
            menu.AddGerecht(gerecht, DateTime.Now);
            _menusRepository.SaveChanges();
            return CreatedAtAction("GetGerecht", new { id = menu.Id, gerechtId = gerecht.Id }, GerechtDTO.MapGerecht(menu.GetMenuGerecht(gerecht.Id)));
        }

        [HttpDelete("{id}/gerechten/{gerechtId}")]
        public ActionResult<GerechtDTO> DeleteGerecht(int id, int gerechtId)
        {
            Menu menu = _menusRepository.GetBy(id);
            if (menu == null)
                return NotFound();
            Gerecht gerecht = menu.GetGerecht(gerechtId);
            if (gerecht == null)
                return NotFound();

            var returnType = GerechtDTO.MapGerecht(menu.GetMenuGerecht(gerechtId));
            menu.DeleteGerecht(gerecht);
            _menusRepository.SaveChanges();
            return returnType;
        }

        //TODO: Soepen en Desserts toevoegen!
    }
}
