using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
  public interface IWriterService : IGenericService<Writer>
  {
    public List<Writer> GetWriterById(int id);
  }
}
