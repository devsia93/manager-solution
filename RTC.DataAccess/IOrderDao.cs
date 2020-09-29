using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public interface IOrderDao
    {
        /// <summary>
        /// Получить заявку по ее номеру.
        /// </summary>
        /// <param name="id">Номер заявки.</param>
        /// <returns></returns>
        Order Get(int id);
        /// <summary>
        /// Получить список всех заявок в базе.
        /// </summary>
        /// <returns>Список всех заявок в базе.</returns>
        IList<Order> GetAll();
        /// <summary>
        /// Добавить заявку в базу.
        /// </summary>
        /// <param name="order">Новая заявка.</param
        void Add(Order order);
        /// <summary>
        /// Обновить заявку.
        /// </summary>
        /// <param name="order">Обновленная заявка.</param>
        void Update(Order order);
        /// <summary>
        /// Удалить заявку по ее номеру.
        /// </summary>
        /// <param name="id">Номер заявки.</param>
        void Delete(int id);
        IList<Order> GetFromManager(int idManager);
        int GetMaxID();

    }
}
