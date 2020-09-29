using RTC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.BusinessLayer
{
    public class ProcessFactory
    {
        public static ISettingsProcess GetSettingsProcess()
        {
            return new SettingsProcess();
        }
        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IWorkerProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IWorkerProcess GetWorkerProcess()
        {
            return new WorkerProcessDb();
        }

        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="ICustomerProcess"/>
        /// </summary>
        /// <returns></returns>
        public static ICustomerProcess GetCustomerProcess()
        {
            return new CustomerProcessDb();
        }

        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IOrderProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IOrderProcess GetOrderProcess()
        {
            return new OrderProcessDb();
        }

        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IProductProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IProductProcess GetProductProcess()
        {
            return new ProductProcessDb();
        }

        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IItemsProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IItemsProcess GetItemsProcess()
        {
            return new ItemsProcessDb();
        }

        public static IReportGenerator GetReport()
        {
            return new ReportGenerator();
        }
    }
}
