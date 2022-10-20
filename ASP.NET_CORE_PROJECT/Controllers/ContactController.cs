using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class ContactController : Controller
  {
    ContactManager cm = new ContactManager(new EfContactRepository());

    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Index(Contact contact)
    {
      contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
      contact.ContactStatus = true;
      cm.AddContact(contact);
      return View("Index","Blog");
    }
  }
}
