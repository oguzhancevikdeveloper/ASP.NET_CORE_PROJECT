﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class NewsLetterController : Controller
  {
    NewsLetterManager nm = new NewsLetterManager(new EfNewsLettersRepository());

    [HttpGet]
    public PartialViewResult SubscribeMail()
    {
      return PartialView();
    }

    [HttpPost]
    public PartialViewResult SubscribeMail(NewsLetter newsLetter)
    {
      newsLetter.MailStatus = true;
      nm.AddNewsLetter(newsLetter);
      return PartialView();
    }
  }
}