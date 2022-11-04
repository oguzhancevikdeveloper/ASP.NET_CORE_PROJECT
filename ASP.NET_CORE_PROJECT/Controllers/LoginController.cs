using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class LoginController : Controller
  {
    [AllowAnonymous] // Startupta oluşturduğumuz kısıtlamayı authorize yi sadece burası için kaldır.
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult>  Index(Writer writer)
    {
      Context C = new Context();
      var datavalue = C.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

      if(datavalue != null)
      {

        var claims = new List<Claim>
        {
          new Claim(ClaimTypes.Name, writer.WriterMail)
        };

        var userIdentity = new ClaimsIdentity(claims,"a"); // Burda neden illaki string bir değer göndermemiz gerekiyor?
        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        await HttpContext.SignInAsync(principal);




        return RedirectToAction("Index", "Dashboard");
      }
      else
      {
        return View();
      }      
    }
  }
}
