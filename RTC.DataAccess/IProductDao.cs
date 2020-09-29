using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public interface IProductDao
    {
        /// <summary>
        /// Получить товар по его номеру.
        /// </summary>
        /// <param name="id">Номер товара.</param>
        /// <returns></returns>
        Product Get(int id);
        /// <summary>
        /// Получить список всех товаров в базе.
        /// </summary>
        /// <returns>Список всех товаров в базе.</returns>
        IList<Product> GetAll();
        /// <summary>
        /// Добавить товар в базу.
        /// </summary>
        /// <param name="product">Новый товар.</param
        void Add(Product product);
        /// <summary>
        /// Обновить товар.
        /// </summary>
        /// <param name="product">Обновленный товар.</param>
        void Update(Product product);
        /// <summary>
        /// Удалить товар по еге номеру.
        /// </summary>
        /// <param name="id">Номер товара.</param>
        void Delete(int id);

        Product GetID(string Title);

        void AddCount(int count, int id);
    }
}
