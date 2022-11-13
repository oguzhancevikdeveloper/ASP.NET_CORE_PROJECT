using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Areas.Admin.ViewComponents.Statistic
{
  public class Statistic1 : ViewComponent
  {
    Context c = new Context();
    public IViewComponentResult Invoke()
    {
      ViewBag.v1 = c.Blogs.Count();
      ViewBag.v2 = c.Contacts.Count();
      ViewBag.v3 = c.Comments.Count();
      return View();
    }
  }
}
