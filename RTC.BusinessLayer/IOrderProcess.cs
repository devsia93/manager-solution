using RTC.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.BusinessLayer
{
    public interface IOrderProcess
    {
        /// <summary>
        /// Получить список всех заявок.
        /// </summary>
        /// <returns>Список заявок.</returns>
        IList<OrderDto> GetList();
        /// <summary>
        /// Получить заявку по ее номеру.
        /// </summary>
        /// <param name="id">Номер заявки.</param>
        /// <returns>Заявка.</returns>
        OrderDto Get(int id);
        /// <summary>
        /// Добавить заявку.
        /// </summary>
        /// <param name="order">Заявка.</param>
        void Add(OrderDto order);
        /// <summary>
        /// Обновить данные о заявке.
        /// </summary>
        /// <param name="order">Заявка.</param>
        void Update(OrderDto order);
        /// <summary>
        /// Удалить заявку.
        /// </summary>
        /// <param name="id">Номер заявки.</param>
        void Delete(int id);
        IList<OrderDto> GetFromManager(int idManager);
        int GetMaxID();
    }
}
