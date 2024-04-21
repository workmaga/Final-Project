using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazoreApp.Entities;

namespace Assignment6.Entities;

[Table("Genres")]
public class Genre
{

    public int GenreId { get; set; }

    [MaxLength(50)]
    public string GenreIs { get; set; }

    public virtual Book book{ get; set; }
   
}
