using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{

  //[Authorize]
  public class WriterController : Controller
  {
    [Authorize]
    public IActionResult Index()
    {
      return View();
    }
  }
}
