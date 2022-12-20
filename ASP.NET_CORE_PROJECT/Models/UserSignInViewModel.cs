using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Models
{
  public class UserSignInViewModel
  {
    [Required(ErrorMessage ="Lütfen Kullanıcı Adı Girin")]
    public string Username { get; set; }

    [Required(ErrorMessage ="Lütfen Şifrenizi Girin")]
    public string Password { get; set; }
  }
}
