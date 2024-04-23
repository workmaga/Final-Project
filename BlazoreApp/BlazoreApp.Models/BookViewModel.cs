using System.ComponentModel.DataAnnotations;

namespace BlazoreApp.Models;

public class BookViewModel
{

    public int BookId { get; set; }
    [MaxLength(50)]
     public string Title { get; set; }
    [MaxLength(50)]

    public long ISBN { get; set; } 

    public int BookAmount { get; set; }

    public int UserId { get; set; }

    public int GenreId { get; set; }


}