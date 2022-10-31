using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
  public class BlogManager : IBlogService
  {
    IBlogDal _blogDal;
    public BlogManager(IBlogDal blogDal)
    {
      _blogDal = blogDal;
    }
    public List<Blog> GetBlogListWithCategory()
    {
      return _blogDal.GetListWithCategory();
    }
    public List<Blog> GetBlogById(int id)
    {
      return _blogDal.GetListAll(x => x.BlogId == id);
    }
    public List<Blog> GetList()
    {
      return _blogDal.GetListAll();
    }
    public List<Blog> GetListWithCategoryByWriterBm(int id)
    {
      return _blogDal.GetListWithCategoryByWriter(id);
    }
    public List<Blog> GetLast3Blog()
    {
      return _blogDal.GetListAll().TakeLast(3).ToList();
    }
    public List<Blog> GetBlogListByWriter(int id)
    {
      return _blogDal.GetListAll(x => x.WriterId == id);
    }
    public void TAdd(Blog t)
    {
      _blogDal.Insert(t);
    }
    public void TUpdate(Blog t)
    {
      _blogDal.Update(t);
    }
    public void TDelete(Blog t)
    {
      _blogDal.Delete(t);
    }
    public Blog TGetById(int id)
    {
     return _blogDal.GetById(id);
    }
  }
}
