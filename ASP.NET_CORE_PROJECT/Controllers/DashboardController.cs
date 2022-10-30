using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class DashboardController : Controller
  {
    BlogManager bm = new BlogManager(new EfBlogRepository());
   
    [AllowAnonymous]
    public IActionResult Index()
    {
      Context c = new Context();
      ViewBag.v1 = c.Blogs.Count().ToString();
      ViewBag.v2 = c.Blogs.Where(x => x.WriterId == 1).Count();
      ViewBag.v3 = c.Categories.Count().ToString();
      return View();
    }
  }
}
