using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public interface ICustomerDao
    {
        /// <summary>
        /// Получить клиента по его номеру.
        /// </summary>
        /// <param name="id">Номер клиента.</param>
        /// <returns></returns>
        Customer Get(int id);
        /// <summary>
        /// Получить список всех клиентов в базе.
        /// </summary>
        /// <returns>Список всех клиентов в базе.</returns>
        IList<Customer> GetAll();
        /// <summary>
        /// Добавить клиента в базу.
        /// </summary>
        /// <param name="customer">Новый отдел.</param
        void Add(Customer customer);
        /// <summary>
        /// Обновить клиента.
        /// </summary>
        /// <param name="customer">Обновленный клиент.</param>
        void Update(Customer customer);
        /// <summary>
        /// Удалить клиента по его номеру.
        /// </summary>
        /// <param name="id">Номер клиента.</param>
        void Delete(int id);

        IList<Customer> SearchCustomer(string Name);
    }
}
