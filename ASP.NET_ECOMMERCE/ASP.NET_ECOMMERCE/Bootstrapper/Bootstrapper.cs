using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET_ECOMMERCE.DataProvider;
using ASP.NET_ECOMMERCE.Models;
using ASP.NET_ECOMMERCE.Services;
using Autofac;

namespace ASP.NET_ECOMMERCE.Bootstrapper
{
    public class Bootstrapper : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryDataProvider>().As<ICategoryDataProvider>().InstancePerRequest();
            builder.RegisterType<ProducerDataProvider>().As<IProducerDataProvider>().InstancePerRequest();
            builder.RegisterType<ProductDataProvider>().As<IProductDataProvider>().InstancePerRequest();

            builder.RegisterType<DataService<Category>>().As<IDataService<Category>>().InstancePerRequest();
            builder.RegisterType<DataService<Producer>>().As<IDataService<Producer>>().InstancePerRequest();
            builder.RegisterType<DataService<Product>>().As<IDataService<Product>>().InstancePerRequest();

            base.Load(builder);
        }
    }
}