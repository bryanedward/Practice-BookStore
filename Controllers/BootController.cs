using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GeAll()
        {
            return Json(new
            {
                data = await _database.Bookses.ToListAsync()
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDatabase = await _database.Bookses.FirstOrDefaultAsync(data => data.Id == id);
            if (bookFromDatabase == null)
            {
                return Json(new
                {
                    success = false , message = "error en la eliminación"
                });
            }
            _database.Bookses.Remove(bookFromDatabase);
            await _database.SaveChangesAsync();
            return Json(new
            {
                success = true , message = "eliminación satisfactoria"
            });
        }
        
    }
}