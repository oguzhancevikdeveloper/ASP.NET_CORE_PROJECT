using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  public class CategoryController : Controller
  {
    CategoryManager cm = new CategoryManager(new EfCategoryRepository());
    public IActionResult Index()
    {
      var values = cm.GetList();
      return View(values);
    }

    public IActionResult DeleteCategory(int id)
    {
      var categoryValue = cm.TGetById(id);
      cm.TDelete(categoryValue);
      return RedirectToAction("Index","Category");
    }
  }
}
