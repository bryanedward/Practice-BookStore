using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Books
    {
        //clase modelo para los libros
        [Key]
        public int Id { get; set; }
        
        [Required] 
        public string NameBook { get; set; }
        
        [Required] 
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }
    }
}