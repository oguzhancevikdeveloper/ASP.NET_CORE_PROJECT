﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  [AllowAnonymous]
  public class BlogController : Controller
  {
    BlogManager bm = new BlogManager(new EfBlogRepository());
    CategoryManager cm = new CategoryManager(new EfCategoryRepository());
    public IActionResult Index()
    {
      var values = bm.GetBlogListWithCategory(); // Burada iki table include edip view e gönderdik :)
      return View(values);
    }
    public IActionResult BlogReadAll(int id)
    {
      ViewBag.Id = id;
      var values = bm.GetBlogById(id);
      return View(values);
    }

    public IActionResult BlogListByWriter()
    {
      var values = bm.GetListWithCategoryByWriterBm(1);
      return View(values);
    }

    [HttpGet]
    public IActionResult BlogAdd()
    {
      
      List<SelectListItem> categoryValues = (from x in cm.GetList()
                                            select new SelectListItem
                                            {
                                              Text = x.CategoryName,
                                              Value = x.CategoryId.ToString()
                                            }).ToList();
      ViewBag.cv = categoryValues;
      return View();
    }

    [HttpPost]
    public IActionResult BlogAdd(Blog blog)
    {
      BlogValidator blv = new BlogValidator();
      ValidationResult results = blv.Validate(blog);

      if (results.IsValid)
      {
        blog.BlogStatus = true;
        blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        bm.TAdd(blog);
        return RedirectToAction("BlogListByWriter", "Blog");
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
    public IActionResult DeleteBlog(int id)
    {
      var blogValue = bm.TGetById(id);
      bm.TDelete(blogValue);
      return RedirectToAction("BlogListByWriter");
    }

    [HttpGet]
    public IActionResult EditBlog(int id)
    {
      List<SelectListItem> categoryValues = (from x in cm.GetList()
                                             select new SelectListItem
                                             {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                             }).ToList();
      var blogValue = bm.TGetById(id);
      ViewBag.cv = categoryValues;
      return View(blogValue);
    }

    [HttpPost]
    public IActionResult EditBlog(Blog blog)
    {
      blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
      blog.BlogStatus = true;
      blog.WriterId = 1;
      bm.TUpdate(blog);
      return View("BlogListByWriter");
    }
  }
}
