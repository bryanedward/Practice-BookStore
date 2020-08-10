using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Models;

namespace WebApplication.Pages.BookList
{
    public class Edit : PageModel
    {
        private DbContextDatabase _database;
        public Edit(DbContextDatabase database)
        {
            _database = database;
        }
        [BindProperty] 
        public Books Books { get; set; }

        public async Task OnGet(int id)
        {
            Books = await _database.Bookses.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //validar campo y buscar en la base de datos el id del libro
                var updateBooks = await _database.Bookses.FindAsync(Books.Id);
                updateBooks.Author = Books.Author;
                updateBooks.NameBook = Books.NameBook;
                updateBooks.ISBN = Books.ISBN;
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