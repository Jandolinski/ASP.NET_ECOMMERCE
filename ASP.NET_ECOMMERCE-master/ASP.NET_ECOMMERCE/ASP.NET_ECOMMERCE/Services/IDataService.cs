using System;
using System.Collections.Generic;

namespace ASP.NET_ECOMMERCE.Services
{
    public interface IDataService<T> : IDisposable
    {
        T GetById(int id);
        void Save(T obj);
        void Delete(int id);
        ICollection<T> GetAll();
    }
}
