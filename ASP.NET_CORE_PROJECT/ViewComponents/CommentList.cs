using ASP.NET_CORE_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.ViewComponents
{
  public class CommentList : ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      var commentValues = new List<UserComment>
      {
        new UserComment
        {
           Id=1,
           UserName ="Oguzhan"
        },
        new UserComment
        {
           Id=2,
           UserName ="Ali"
        },
        new UserComment
        {
           Id=3,
           UserName ="Veli"
        }
      };
      return View(commentValues);
    }
  }
}
