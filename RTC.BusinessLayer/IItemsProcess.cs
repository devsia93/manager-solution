using RTC.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.BusinessLayer
{
    public interface IItemsProcess
    {
        /// <summary>
        /// Получить список всех позиций в заявке.
        /// </summary>
        /// <returns>Список позиций.</returns>
        IList<ItemsDto> GetList();
        /// <summary>
        /// Добавить позицию товара.
        /// </summary>
        /// <param name="item">Товар.</param>
        void Add(ItemsDto item);
        /// <summary>
        /// Обновить данные о позициях товара.
        /// </summary>
        /// <param name="item">Товар.</param>
        void Update(ItemsDto item);
        /// <summary>
        /// Удалить позицию товара.
        /// </summary>
        /// <param name="idOrder">Номер заказа.</param>
        void Delete(int idOrder);
    }
}
