using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public class DaoFactory
    {
        public static ICustomerDao GetCustomer()
        {
            return new CustomerDao();
        }
        public static IOrderDao GetOrder()
        {
            return new OrderDao();
        }
        public static IProductDao GetProduct()
        {
            return new ProductDao();
        }
        public static IWorkerDao GetWorker()
        {
            return new WorkerDao();
        }

        public static IItemsDao GetItems()
        {
            return new ItemsDao();
        }
    }
}

