using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  [AllowAnonymous]
  public class MessageContoller : Controller
  {
    Message2Manager mm = new Message2Manager(new EfMessage2Repository());

    [AllowAnonymous]
    public IActionResult Inbox()
    {
      int id = 1;
      var values = mm.GetInboxListByWriter(id);
      return View(values);
    }

    [AllowAnonymous]
    public IActionResult MessageDetails(int id)
    {
      var value = mm.TGetById(id);
      return View(value);
    }
  }
}
