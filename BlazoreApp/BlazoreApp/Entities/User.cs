using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazoreApp.Database;


namespace BlazoreApp.Entities;


[Table("Users")]
public class User
{

    public int UserId { get; set; }
  [MaxLength(50)]
  public string UserName { get; set; }
    [MaxLength(50)]

    public int MoneyAmount { get; set; }

}