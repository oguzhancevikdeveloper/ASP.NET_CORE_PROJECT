using ASP.NET_CORE_PROJECT.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class WriterController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult WriterList()
    {
      var jsonWriters = JsonConvert.SerializeObject(writers);
      return Json(jsonWriters);
    }

    public static List<Writer> writers = new List<Writer>()
    {
      new Writer
      {
         Id =1,
         Name ="A"
      },
      new Writer
      {
         Id=2,
         Name ="B"
      }
    };

  }
}
