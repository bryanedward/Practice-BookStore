using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BootController : Controller
    {
        private readonly DbContextDatabase _database;

        public BootController(DbContextDatabase database)
        {
            _database = database;
        }

        // GET 
        [HttpGet]
        public IActionResult GeAll()
        {
            return Json(new
            {
                data = _database.Bookses.ToList()
            });
        }
        
        
    }
}