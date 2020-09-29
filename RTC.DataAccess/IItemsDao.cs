using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public interface IItemsDao
    {
        /// <summary>
        /// Получить список всех позиций по номеру заявки.
        /// </summary>
        /// <param name="idOrder">Номер заявки.</param>
        /// <returns>Позиции заявки.</returns>
        IList<Items> Get(int idOrder);
        /// <summary>
        /// Получить список всех позиций в базе.
        /// </summary>
        /// <returns>Список всех позиций в базе.</returns>
        IList<Items> GetAll();
        /// <summary>
        /// Добавить менеджера в базу.
        /// </summary>
        /// <param name="item">Новый менеджер.</param
        void Add(Items item);
        /// <summary>
        /// Обновить позицию.
        /// </summary>
        /// <param name="item">Обновленная позиция.</param>
        void Update(Items item);
        /// <summary>
        /// Удалить позицию по его номеру.
        /// </summary>
        /// <param name="id">Номер позиции.</param>
        void Delete(int id);
    }
}
