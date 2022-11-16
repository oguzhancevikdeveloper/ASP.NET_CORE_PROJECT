using ASP.NET_CORE_PROJECT.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Areas.Admin.Controllers
{

  [Area("Admin")]
  public class ChartController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult CategoryChart()
    {
      List<Category> list = new List<Category>();

      list.Add(new Category
      {
        categoryName = "Teknoloji",
        categoryCount = 10
      });
      list.Add(new Category
      {
        categoryName = "Yazılım",
        categoryCount = 9
      });
      list.Add(new Category
      {
        categoryName = "Spor",
        categoryCount = 4
      });

      return Json(new { jsonlist = list });
    }
  }
}
