using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Areas.Admin.ViewComponents.Statistic
{
  public class Statistic3 : ViewComponent
  {

    Context c = new Context();
    public IViewComponentResult Invoke()
    {
      return View();
    }
  }
}
