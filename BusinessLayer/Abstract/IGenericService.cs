using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
  public interface IGenericService<T>
  {
    void TAdd(T t);
    void TUpdate(T t);
    void TDelete(T t);
    List<T> GetList();
    T TGetById(int id);
  }
}
