using ASP.NET_CORE_PROJECT.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class WriterController : Controller
  {
    WriterManager wm = new WriterManager(new EfWriterRepository());

    [Authorize]
    public IActionResult Index()
    {
      var useremail = User.Identity.Name;
      ViewBag.v = useremail;
      Context c = new Context();
      var writerName = c.Writers.Where(x => x.WriterMail == useremail).Select(y => y.WriterName).FirstOrDefault();
      ViewBag.v2 = writerName;
      return View();
    }

    [AllowAnonymous]
    public IActionResult Test()
    {
      return View();
    }

    [AllowAnonymous]
    public PartialViewResult WriterNawBarPartial()
    {
      return PartialView();
    }
    [AllowAnonymous]
    public PartialViewResult WriterFooterPartial()
    {
      return PartialView();
    }

    [HttpGet]
    public IActionResult WriterEditProfile()
    {

      var useremail = User.Identity.Name;
      Context c = new Context();
      var writerId = c.Writers.Where(x => x.WriterMail == useremail).Select(y => y.WriterId).FirstOrDefault();
      var values = wm.GetWriterById(writerId);
      return View(values);
    }

    [HttpPost]
    public IActionResult WriterEditProfile(Writer writer)
    {
      WriterValidator wl = new WriterValidator();
      ValidationResult results = wl.Validate(writer);

      if (results.IsValid)
      {
        wm.TUpdate(writer);
        return RedirectToAction("Index", "Dashboard");
      }
      else
      {
        foreach (var item in results.Errors)
        {
          ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        }
      }

      return View();
    }


    [HttpGet]
    public IActionResult AddWriter()
    {

      return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult AddWriter(AddProfileImage p)
    {
      Writer writer = new Writer();
      if(p.WriterImage != null)
      {
        var extension = Path.GetExtension(p.WriterImage.FileName);
        var newimagename = Guid.NewGuid() + extension;
        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
        var stream = new FileStream(location, FileMode.Create);
        p.WriterImage.CopyTo(stream);
        writer.WriterImage = newimagename;
      }
      writer.WriterMail = p.WriterMail;
      writer.WriterName = p.WriterName;
      writer.WriterPassword = p.WriterPassword;
      writer.RepeatPassword = p.RepeatPassword;
      writer.Status = true;
      writer.WriterAbout = p.WriterAbout;

      wm.TAdd(writer);
      return RedirectToAction("Index","Dashboard");
    }
  }
}
