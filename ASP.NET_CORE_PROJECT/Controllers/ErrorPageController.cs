using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class ErrorPageController : Controller
  {
    public IActionResult Error1(int code)
    {
      return View();
    }
  }
}
