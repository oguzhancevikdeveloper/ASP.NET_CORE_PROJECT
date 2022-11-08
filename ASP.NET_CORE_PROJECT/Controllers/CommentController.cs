using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  [AllowAnonymous]
  public class CommentController : Controller
  {
    CommentManager cm = new CommentManager(new EfCommentRepository());
    public IActionResult Index()
    {
      return View();
    }
    [HttpGet]
    public PartialViewResult PartialAddComment()
    {
      return PartialView();
    }
    [HttpPost]
    public IActionResult PartialAddComment(Comment comment)
    {
      comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
      comment.CommentStatus = true;
      comment.BlogId = 9;
      cm.CommentAdd(comment);
      return RedirectToAction("BlogReadAll", "Blog", new { id = comment.BlogId });
    }
    public PartialViewResult CommentListByBlog(int id)
    {
      var values = cm.GetList(id);
      return PartialView(values);
    }
  }
}
