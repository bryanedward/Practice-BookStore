using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.BookList
{
    public class Index : PageModel
    {
        private readonly DbContextDatabase _database;

        public Index(DbContextDatabase database)
        {
            _database = database;
        }
        public IEnumerable<Books> Bookses { get; set; }
        
        public async Task OnGet()
        {
            Bookses = await _database.Bookses.ToListAsync();
        }

        public async Task<IActionResult> OnPostEliminar(int id)
        {
            //buscar el id en la base de datos y 
            var deleteBooks = await _database.Bookses.FindAsync(id);
            if (deleteBooks != null)
            {
                _database.Bookses.Remove(deleteBooks);
                await _database.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return NotFound();
        }
    }
}