using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Areas.Admin.ViewComponents.Statistic
{
  public class Statistic4 : ViewComponent
  {
    Context c = new Context();
    public IViewComponentResult Invoke()
    {
      ViewBag.v1 = c.Admins.Where(x => x.AdminId == 1).Select(t => t.Name).FirstOrDefault();
      ViewBag.v2 = c.Admins.Where(x => x.AdminId == 1).Select(t => t.ImageUrl).FirstOrDefault();
      ViewBag.v3 = c.Admins.Where(x => x.AdminId == 1).Select(t => t.ShortDescription).FirstOrDefault();
      return View();
    }
  }
}
