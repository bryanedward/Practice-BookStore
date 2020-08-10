using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.BookList
{
    public class Upsert : PageModel
    {
        private DbContextDatabase _database;
        public Upsert(DbContextDatabase database)
        {
            _database = database;
        }
        [BindProperty] 
        public Books Books { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Books = new Books();
            if (id == null)
            {
                return Page();
            }
            Books = await _database.Bookses.FirstOrDefaultAsync(data => data.Id == id);
            if (Books == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //validar campo y buscar en la base de datos el id del libro
                if (Books.Id == 0)
                {
                    _database.Bookses.Add(Books);
                }
                else
                {
                    _database.Bookses.Update(Books);
                }
                
                /*var updateBooks = await _database.Bookses.FindAsync(Books.Id);
                updateBooks.Author = Books.Author;
                updateBooks.NameBook = Books.NameBook;
                updateBooks.ISBN = Books.ISBN;*/
                
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