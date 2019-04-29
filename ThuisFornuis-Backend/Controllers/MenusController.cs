using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenusRepository _menusRepository;
        private readonly IGerechtenRepository _gerechtenRepository;
        private readonly ISoepenRepository _soepenRepository;
        private readonly IDessertsRepository _dessertsRepository;

        public MenusController(IMenusRepository menusRepository, IGerechtenRepository gerechtenRepository, ISoepenRepository soepenRepository, IDessertsRepository dessertsRepository)
        {
            _menusRepository = menusRepository;
            _gerechtenRepository = gerechtenRepository;
            _soepenRepository = soepenRepository;
            _dessertsRepository = dessertsRepository;
        }

        //----------------------------Menus----------------------------
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<MenuDTO> GetMenus()
        { 
            return _menusRepository.GetAll().Select(m => MenuDTO.MapMenu(m)).ToList();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult<MenuDTO> PutMenu(int id, MenuDTO menuDTO)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return NotFound();
            }
            menu.Omschrijving = menuDTO.Omschrijving;
            menu.Datum = menuDTO.Datum;
            _menusRepository.Update(menu);
            _menusRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        //----------------------------Soepen----------------------------
        [HttpGet("{id}/soepen")]
        [AllowAnonymous]
        public IEnumerable<SoepDTO> GetSoepen(int id)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return new List<SoepDTO>();
                //return NotFound();
            }
            return menu.MenuSoepen.Select(ms => SoepDTO.MapSoep(ms)).OrderBy(s => s.Naam);
        }

        [HttpGet("{id}/soepen/{soepId}")]
        [AllowAnonymous]
        public ActionResult<SoepDTO> GetSoep(int id, int soepId)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
                return NotFound();
            MenuSoep menuSoep = menu.GetMenuSoep(soepId);
            if (menuSoep == null)
                return NotFound();
            return SoepDTO.MapSoep(menuSoep);
        }

        [HttpPost("{id}/soepen/{soepId}")]
        [AllowAnonymous]
        public ActionResult<SoepDTO> PostSoep(int id, int soepId)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return NotFound();
            }
            _soepenRepository.TryGetSoep(soepId, out var soep);
            //var soepToCreate = new Soep(soep.Naam, soep.Prijs, soep.Hoeveelheid, soep.Omschrijving, soep.Foto);
            menu.AddSoep(soep, DateTime.Now);
            _menusRepository.SaveChanges();
            return CreatedAtAction("GetSoep", new { id = menu.Id, soepId = soep.Id }, SoepDTO.MapSoep(menu.GetMenuSoep(soep.Id)));
        }

        [HttpDelete("{id}/soepen/{soepId}")]
        [AllowAnonymous]
        public ActionResult<SoepDTO> DeleteSoep(int id, int soepId)
        {
            Menu menu = _menusRepository.GetBy(id);
            if (menu == null)
                return NotFound();
            Soep soep = menu.GetSoep(soepId);
            if (soep == null)
                return NotFound();

            var returnType = SoepDTO.MapSoep(menu.GetMenuSoep(soepId));
            menu.DeleteSoep(soep);
            _menusRepository.SaveChanges();
            return returnType;
        }

        //----------------------------Desserts----------------------------
        [HttpGet("{id}/desserts")]
        [AllowAnonymous]
        public IEnumerable<DessertDTO> GetDesserts(int id)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return new List<DessertDTO>();
                //return NotFound();
            }
            return menu.MenuDesserts.Select(md => DessertDTO.MapDessert(md)).OrderBy(d => d.Naam);
        }

        [HttpGet("{id}/desserts/{dessertId}")]
        [AllowAnonymous]
        public ActionResult<DessertDTO> GetDessert(int id, int dessertId)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
                return NotFound();
            MenuDessert menuDessert = menu.GetMenuDessert(dessertId);
            if (menuDessert == null)
                return NotFound();
            return DessertDTO.MapDessert(menuDessert);
        }

        [HttpPost("{id}/desserts/{dessertId}")]
        [AllowAnonymous]
        public ActionResult<DessertDTO> PostDessert(int id, int dessertId)
        {
            if (!_menusRepository.TryGetMenu(id, out var menu))
            {
                return NotFound();
            }
            _dessertsRepository.TryGetDessert(dessertId, out var dessert);
            //var dessertToCreate = new Dessert(dessert.Naam, dessert.Prijs, dessert.Hoeveelheid, dessert.Omschrijving, dessert.Foto);
            menu.AddDessert(dessert, DateTime.Now);
            _menusRepository.SaveChanges();
            return CreatedAtAction("GetDessert", new { id = menu.Id, dessertId = dessert.Id }, DessertDTO.MapDessert(menu.GetMenuDessert(dessert.Id)));
        }

        [HttpDelete("{id}/desserts/{dessertId}")]
        [AllowAnonymous]
        public ActionResult<DessertDTO> DeleteDessert(int id, int dessertId)
        {
            Menu menu = _menusRepository.GetBy(id);
            if (menu == null)
                return NotFound();
            Dessert dessert = menu.GetDessert(dessertId);
            if (dessert == null)
                return NotFound();

            var returnType = DessertDTO.MapDessert(menu.GetMenuDessert(dessertId));
            menu.DeleteDessert(dessert);
            _menusRepository.SaveChanges();
            return returnType;
        }
    }
}
