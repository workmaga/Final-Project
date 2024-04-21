using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazoreApp.Database;


namespace BlazoreApp.Entities;


[Table("Books")]
public class Book
{

    public int BookId { get; set; }
    [MaxLength(50)]
     public string Title { get; set; }
    [MaxLength(50)]

    public long ISBN { get; set; } 

    public int BookAmount { get; set; }

    public int UserId { get; set; }

    public int GenreId { get; set; }

    public virtual User user { get; set; }

}