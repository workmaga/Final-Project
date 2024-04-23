using System.ComponentModel.DataAnnotations;

namespace BlazoreApp.Models;

public class UserViewModel
{
    public int UserId { get; set; }
  [MaxLength(50)]
  public string UserName { get; set; }
    [MaxLength(50)]

    public int MoneyAmount { get; set; }
}
