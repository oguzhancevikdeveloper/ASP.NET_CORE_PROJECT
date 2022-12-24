using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class MessageContoller : Controller
  {
    Message2Manager mm = new Message2Manager(new EfMessage2Repository());
    Context c = new Context();
    public IActionResult Inbox()
    {

      var username = User.Identity.Name;
      var useremail = c.Users.Where(x => x.UserName == username).Select(t => t.Email).FirstOrDefault();
      var writerId = c.Users.Where(x => x.Email == useremail).Select(y => y.Id).FirstOrDefault();

      var values = mm.GetInboxListByWriter(writerId);

      return View(values);
    }

    public IActionResult SendBox()
    {
      var username = User.Identity.Name;
      var useremail = c.Users.Where(x => x.UserName == username).Select(t => t.Email).FirstOrDefault();
      var writerId = c.Users.Where(x => x.Email == useremail).Select(y => y.Id).FirstOrDefault();

      var values = mm.GetSendBoxListByWriter(writerId);

      return View(values);
    }
    
    public IActionResult MessageDetails(int id)
    {
      var value = mm.TGetById(id);
      return View(value);
    }

    [HttpGet]
    public IActionResult SendMessage(Message2 p)
    {
      var username = User.Identity.Name;
      var useremail = c.Users.Where(x => x.UserName == username).Select(t => t.Email).FirstOrDefault();
      var writerId = c.Users.Where(x => x.Email == useremail).Select(y => y.Id).FirstOrDefault();

      p.SenderId = writerId;
      p.ReceiverId = 8;
      p.MessageStatus = true;
      p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
      mm.TAdd(p);
      return RedirectToAction("Inbox");
    }
  }
}
