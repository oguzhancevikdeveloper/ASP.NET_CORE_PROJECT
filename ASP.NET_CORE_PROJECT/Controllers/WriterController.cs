using ASP.NET_CORE_PROJECT.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class WriterController : Controller
  {
    WriterManager wm = new WriterManager(new EfWriterRepository());
    UserManager userManager = new UserManager(new EfUserRepository());

    private readonly UserManager<AppUser> _userManager;

    public WriterController(UserManager<AppUser> userManager)
    {
      _userManager = userManager;
    }

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
    public async Task<IActionResult> WriterEditProfile()
    {
      UserUpdateViewModel model = new UserUpdateViewModel();

      var values = await _userManager.FindByNameAsync(User.Identity.Name);

      model.mail = values.Email;
      model.namesurname = values.UserName;
      model.imageurl = values.ImageUrl;
      model.username = values.UserName;

      return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
    {

      var values = await _userManager.FindByNameAsync(User.Identity.Name);

      values.NameSurname = model.namesurname;
      values.UserName = model.username;
      values.ImageUrl = model.imageurl;
      values.Email = model.mail;
      values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,model.password);

      var result = await _userManager.UpdateAsync(values);

      return RedirectToAction("Index", "Dashboard");
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
      if (p.WriterImage != null)
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
      return RedirectToAction("Index", "Dashboard");
    }

  }
}
