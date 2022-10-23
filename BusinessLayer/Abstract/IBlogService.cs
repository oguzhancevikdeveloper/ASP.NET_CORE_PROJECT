using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
  public interface IBlogService : IGenericService<Blog>
  {
    List<Blog> GetBlogById(int id);
    List<Blog> GetLast3Blog();
    List<Blog> GetBlogListWithCategory();
    List<Blog> GetBlogListByWriter(int id);
  }
}
