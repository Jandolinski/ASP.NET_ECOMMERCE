using System.Collections.Generic;
using ASP.NET_ECOMMERCE.Models;

namespace ASP.NET_ECOMMERCE.DataProvider
{
    public interface IProducerDataProvider
    {
        Producer GetProducerById(int? id);
        void SaveProducer(Producer producer);
        void DeleteProducer(int id);
        ICollection<Producer> GetAllProducers();
    }
}
