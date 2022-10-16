﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class CommentController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
    public PartialViewResult PartialAddComment()
    {
      return PartialView();
    }
    public PartialViewResult CommentListByBlog()
    {
      return PartialView();
    }
  }
}
