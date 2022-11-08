using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  [AllowAnonymous]
  public class NewsLetterController : Controller
  {
    NewsLetterManager nm = new NewsLetterManager(new EfNewsLettersRepository());

    [HttpGet]
    public PartialViewResult SubscribeMail()
    {
      return PartialView();
    }

    [HttpPost]
    public IActionResult SubscribeMail(NewsLetter newsLetter)
    {
      newsLetter.MailStatus = true;
      nm.AddNewsLetter(newsLetter);
      return PartialView();
    }
  }
}
