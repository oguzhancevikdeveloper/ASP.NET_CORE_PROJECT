using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.ViewComponents.Writer
{
  public class WriterNotification : ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      return View();
    }
  }
}
