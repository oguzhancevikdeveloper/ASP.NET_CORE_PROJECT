using ASP.NET_CORE_PROJECT;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
  public class GenericRepository<T> : IGenericDal<T> where T : class
  {
    Context context;
    public GenericRepository(Context _context)
    {
      context = _context;
    }

    public void Delete(T t)
    {
      context.Remove(t);
      context.SaveChanges();
    }

    public T GetById(int id)
    {
      return context.Set<T>().Find(id); //tolist olabilir. bakıcaz using var c = new Context
    }

    public List<T> GetListAll()
    {
      return context.Set<T>().ToList();
    }

    public void Insert(T t)
    {
      context.Add(t);
      context.SaveChanges();
    }

    public void Update(T t)
    {
      context.Update(t);
      context.SaveChanges();
    }
  }
}
