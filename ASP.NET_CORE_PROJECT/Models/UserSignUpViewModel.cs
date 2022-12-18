using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Models
{
  public class UserSignUpViewModel
  {
    [Display(Name ="Ad Soyad")]
    [Required(ErrorMessage ="Lütfen Ad Soyad Giriniz.")]
    public string NameSurname { get; set; }

    [Display(Name = "Şifre")]
    [Required(ErrorMessage = "Lütfen Şifre Giriniz.")]
    public string Password { get; set; }

    [Display(Name = "Şifre Tekrarı")]
    [Compare("Password",ErrorMessage ="Şİfreler Uyuşmuyor!")]
    public string ConfirmPassword{ get; set; }

    [Display(Name = "Mail Adresi")]
    [Required(ErrorMessage = "Lütfen Mail Giriniz.")]
    public string Mail { get; set; }

    [Display(Name = "Kullanıcı Adı")]
    [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz.")]
    public string UserName { get; set; }
  }
}
