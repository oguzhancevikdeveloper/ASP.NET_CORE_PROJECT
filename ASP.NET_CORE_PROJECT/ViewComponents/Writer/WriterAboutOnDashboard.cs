using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.ViewComponents.Writer
{
  
  public class WriterAboutOnDashboard: ViewComponent
  {
    WriterManager wm = new WriterManager(new EfWriterRepository());

    public IViewComponentResult Invoke()
    {
      var useremail = User.Identity.Name;

      Context c = new Context();
      var writerId = c.Writers.Where(x => x.WriterMail == useremail).Select(y => y.WriterId).FirstOrDefault();
      var values = wm.GetWriterById(writerId);
      return View(values);
    }
  }
}
