using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public IEnumerable<Menu> GetMenus()
        { 
            return _menusRepository.GetAll().OrderBy(m => m.Datum);
        }

        [HttpGet("{id}")]
        public ActionResult<Menu> GetMenu(int id)
        {
            var menu = _menusRepository.GetBy(id);
            if (menu == null)
            {
                //return NotFoundResult();
            }
            return menu;
        }

        [HttpPost]
        public ActionResult<Menu> PostMenu(Menu menu)
        {
            _menusRepository.Add(menu);
            _menusRepository.SaveChanges();
            //201 + link naar gecreeerd menu + optioneel het gecreerde menu
            return CreatedAtAction(nameof(GetMenu), new { id = menu.Id }, menu);
        }

    
    }
}
