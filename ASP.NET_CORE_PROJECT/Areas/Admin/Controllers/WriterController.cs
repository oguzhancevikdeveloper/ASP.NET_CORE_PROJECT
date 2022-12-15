using ASP.NET_CORE_PROJECT.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class WriterController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult AddWriter(Writer w)
    {
      writers.Add(w);
      var jsonwriters = JsonConvert.SerializeObject(w);
      return Json(jsonwriters);
    }

    public IActionResult DeleteWriter(int id)
    {
      var writer = writers.FirstOrDefault(x => x.Id == id);
      writers.Remove(writer);
      return Json(writer);
    }

    [HttpPost]
    public IActionResult UpdateWriter(Writer w)
    {
      var writer = writers.FirstOrDefault(x => x.Id == w.Id);
      writer.Name = w.Name;
      var jsonWriter = JsonConvert.SerializeObject(w);
      return Json(jsonWriter);
    }

    public IActionResult WriterList()
    {
      var jsonWriters = JsonConvert.SerializeObject(writers);
      return Json(jsonWriters);
    }
    public IActionResult GetWriterById(int writerid)
    {
      var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
      var jsonWriters = JsonConvert.SerializeObject(findWriter);
      return Json(jsonWriters);
    }

    public static List<Writer> writers = new List<Writer>()
    {
      new Writer
      {
         Id =1,
         Name ="A"
      },
      new Writer
      {
         Id=2,
         Name ="B"
      }
    };

  }
}
