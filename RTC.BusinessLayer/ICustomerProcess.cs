using RTC.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.BusinessLayer
{
    public interface ICustomerProcess
    {
        /// <summary>
        /// Получить список всех клиентов.
        /// </summary>
        /// <returns>Список клиентов.</returns>
        IList<CustomerDto> GetList();
        /// <summary>
        /// Получить клиента по его номеру.
        /// </summary>
        /// <param name="id">Номер клиента.</param>
        /// <returns>Клиент.</returns>
        CustomerDto Get(int id);
        /// <summary>
        /// Добавить клиента.
        /// </summary>
        /// <param name="customer">Клиент.</param>
        void Add(CustomerDto customer);
        /// <summary>
        /// Обновить данные о клиенте.
        /// </summary>
        /// <param name="customer">Клиент.</param>
        void Update(CustomerDto customer);
        /// <summary>
        /// Удалить клиента.
        /// </summary>
        /// <param name="id">Номер клиента.</param>
        void Delete(int id);
        IList<CustomerDto> SearchCustomer(string Name);

    }
}
