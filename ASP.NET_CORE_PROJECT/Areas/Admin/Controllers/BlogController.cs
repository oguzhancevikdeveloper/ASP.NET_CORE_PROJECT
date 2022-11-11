using ASP.NET_CORE_PROJECT.Areas.Admin.Models;
using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Areas.Admin.Controllers
{
  [AllowAnonymous]
  [Area("Admin")]
  public class BlogController : Controller
  {
    public IActionResult ExportStaticExcelBlogList()
    {
      using (var workbook = new XLWorkbook())
      {
        var worksheet = workbook.Worksheets.Add("Blog Listesi");
        worksheet.Cell(1, 1).Value = "Blog Id";
        worksheet.Cell(1, 2).Value = "Blog Adı";

        int blogRowCount = 2;

        foreach (var item in GetBlogList())
        {
          worksheet.Cell(blogRowCount, 1).Value = item.Id;
          worksheet.Cell(blogRowCount, 2).Value = item.BlogName;
          blogRowCount++;
        }

        using (var stream = new MemoryStream())
        {

          workbook.SaveAs(stream);
          var content = stream.ToArray();
          return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");

        }
      }
    }
    public List<BlogModel> GetBlogList()
    {

      List<BlogModel> bm = new List<BlogModel>
      {
        new BlogModel{ Id=1, BlogName="C# Prgramlama"},
        new BlogModel{ Id=2, BlogName="Java Prgramlama"},
        new BlogModel{ Id=3, BlogName="Python Prgramlama"}
      };

      return bm;
    }
    public IActionResult BlogListExcel()
    {
      return View();
    }






    public IActionResult ExportStaticExcelBlogDynamicList()
    {
      using (var workbook = new XLWorkbook())
      {
        var worksheet = workbook.Worksheets.Add("Blog Listesi");
        worksheet.Cell(1, 1).Value = "Blog Id";
        worksheet.Cell(1, 2).Value = "Blog Adı";

        int blogRowCount = 2;

        foreach (var item in GetBlogTitleList())
        {
          worksheet.Cell(blogRowCount, 1).Value = item.Id;
          worksheet.Cell(blogRowCount, 2).Value = item.BlogName;
          blogRowCount++;
        }

        using (var stream = new MemoryStream())
        {

          workbook.SaveAs(stream);
          var content = stream.ToArray();
          return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");

        }
      }
    }
    public List<BlogModel2> GetBlogTitleList()
    {
      List<BlogModel2> bm = new List<BlogModel2>();

      using (var c = new Context())
      {
        bm = c.Blogs.Select(x => new BlogModel2
        {
          Id = x.BlogId,
          BlogName = x.BlogTitle
        }).ToList();
      }
      return bm;
    }
    public IActionResult BlogTitleListExcel()
    {
      return View();
    }

  }
}
