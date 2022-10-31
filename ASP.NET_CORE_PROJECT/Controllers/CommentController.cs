using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ASP.NET_CORE_PROJECT.Controllers
{
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
    public PartialViewResult PartialAddComment(Comment comment)
    {
      comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
      comment.CommentStatus = true;
      comment.BlogId = 6;
      cm.CommentAdd(comment);
      return PartialView();
    }
    public PartialViewResult CommentListByBlog(int id)
    {
      var values= cm.GetList(id);
      return PartialView(values);
    }
  }
}
