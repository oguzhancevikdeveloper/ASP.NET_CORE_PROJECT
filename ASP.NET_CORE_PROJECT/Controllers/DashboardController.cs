using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  [AllowAnonymous]
  public class DashboardController : Controller
  {
    BlogManager bm = new BlogManager(new EfBlogRepository());  
    public IActionResult Index()
    {
      Context c = new Context();

      var username = User.Identity.Name;
      ViewBag.v = username;
      var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

      var writerId = c.Users.Where(x => x.Email == usermail).Select(t => t.Id).FirstOrDefault();

      ViewBag.v1 = c.Blogs.Count().ToString();
      ViewBag.v2 = c.Blogs.Where(x => x.WriterId == writerId).Count();
      ViewBag.v3 = c.Categories.Count().ToString();
      return View();
    }
  }
}
