using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Models;

namespace WebApplication.Pages.BookList
{
    public class Create : PageModel
    {
        private readonly DbContextDatabase _database;

        public Create(DbContextDatabase database)
        {
            _database = database;
        }
        
        [BindProperty]
        public Books Books { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //validar que estan todos los campos completados guardat y redireccionar
                await _database.Bookses.AddAsync(Books);
                await _database.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
        
    }
}