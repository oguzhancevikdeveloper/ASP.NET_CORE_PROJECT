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
    Context _context;

    public void Delete(T t)
    {
      _context.Remove(t);
      _context.SaveChanges();
    }

    public T GetById(int id)
    {
      return _context.Set<T>().Find(id); //tolist olabilir. bakıcaz using var c = new Context
    }

    public List<T> GetListAll()
    {
      return _context.Set<T>().ToList();
    }

    public void Insert(T t)
    {
      _context.Add(t);
      _context.SaveChanges();
    }

    public void Update(T t)
    {
      _context.Update(t);
      _context.SaveChanges();
    }
  }
}
