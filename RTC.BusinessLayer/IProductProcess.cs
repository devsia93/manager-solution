using System;
using RTC.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.BusinessLayer
{
    public interface IProductProcess
    {
        /// <summary>
        /// Получить список всех товаров.
        /// </summary>
        /// <returns>Список товаров.</returns>
        IList<ProductDto> GetList();
        /// <summary>
        /// Получить товар по его номеру.
        /// </summary>
        /// <param name="id">Номер товара.</param>
        /// <returns>Клиент.</returns>
        ProductDto Get(int id);
        /// <summary>
        /// Добавить товар.
        /// </summary>
        /// <param name="product">Товар.</param>
        void Add(ProductDto product);
        /// <summary>
        /// Обновить данные о товаре.
        /// </summary>
        /// <param name="product">Товар.</param>
        void Update(ProductDto product);
        /// <summary>
        /// Удалить товар.
        /// </summary>
        /// <param name="id">Номер товара.</param>
        void Delete(int id);

        ProductDto GetID(string Title);

        void AddCount(int count, int id);
    }
}
