using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.ViewComponents.Writer
{
  
  public class WriterAboutOnDashboard: ViewComponent
  {

    Context c = new Context();
    WriterManager wm = new WriterManager(new EfWriterRepository());

    public  IViewComponentResult Invoke()
    {
  
      var username = User.Identity.Name;
      ViewBag.v = username;
      var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();    
      var writerId = c.Writers.Where(x => x.WriterMail == username).Select(y => y.WriterId).FirstOrDefault();
      var values = wm.GetWriterById(writerId);
      return View(values);
    }
  }
}
