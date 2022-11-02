using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.ViewComponents.Writer
{
  public class WriterMessageNotification : ViewComponent
  {
    MessageManager mm = new MessageManager(new EfMessageRepository());
    public IViewComponentResult Invoke()
    {
      string p;
      p = "oguzhancevik.developer@gmail.com";
      var values = mm.GetInboxListByWriter(p);
      return View(values);
    }
  }
}
