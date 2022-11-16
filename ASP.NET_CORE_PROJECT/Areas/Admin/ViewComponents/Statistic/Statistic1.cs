using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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


      string api = "3bc802164a795dce17f538d2a2769e92";
      string connection = "https://api.openweathermap.org/data/2.5/weather?q=%C4%B0stanbul&mode=xml&appid="+api;
      XDocument document = XDocument.Load(connection);
      ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
      return View();
    }
  }
}
