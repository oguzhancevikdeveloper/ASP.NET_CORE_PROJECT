using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class WidgetController : Controller
  {
    BlogManager bm = new BlogManager(new EfBlogRepository());
    public IActionResult Index()
    {
      ViewBag.v1 = bm.GetList().Count();
      return View();
    }
  }
}
