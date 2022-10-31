using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class WriterController : Controller
  {
    [AllowAnonymous]
    public IActionResult Index()
    {
      return View();
    }

    [AllowAnonymous]
    public IActionResult Test()
    {
      return View();
    }

    [AllowAnonymous]
    public PartialViewResult WriterNawBarPartial()
    {
      return PartialView();
    }
    [AllowAnonymous]
    public PartialViewResult WriterFooterPartial()
    {
      return PartialView();
    }
  }
}
