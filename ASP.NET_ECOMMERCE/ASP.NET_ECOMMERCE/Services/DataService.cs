using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ASP.NET_ECOMMERCE.DataContext;

namespace ASP.NET_ECOMMERCE.Services
{
    public class DataService<T> : IDataService<T> where T : class

    {
        private readonly EcommerceDataContext _ecommerceDataContext;

        private bool _isDisposed;

        public DataService()
        {
            _ecommerceDataContext = new EcommerceDataContext();
        }

        public void Delete(int id)
        {
            var removeObj = _ecommerceDataContext.Set<T>().Find(id);
            if (removeObj == null)
            {
                _ecommerceDataContext.Set<T>().Remove(removeObj);
                _ecommerceDataContext.SaveChanges();
            }
        }

        public ICollection<T> GetAll()
        {
            return _ecommerceDataContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _ecommerceDataContext.Set<T>().Find(id);
        }

        public void Save(T obj)
        {
            _ecommerceDataContext.Set<T>().AddOrUpdate(obj);
            _ecommerceDataContext.SaveChanges();
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                    _ecommerceDataContext.Dispose();
                _isDisposed = true;
            }
        }

        ~DataService()
        {
            Dispose(false);
        }

        #endregion
    }
}