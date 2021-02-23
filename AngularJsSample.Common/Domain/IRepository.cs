using System.Collections.Generic;

namespace AngularJsSample.Common
{
    public interface IRepository<T,TKey>
    {
        List<T> FindAll();
        T FindAll(TKey key);
        TKey Add(T item);
        bool Delete(T item);
        T Save(T item);
        List<T> FindAllBy(TKey key);

    }
}