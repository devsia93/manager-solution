using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public interface IWorkerDao
    {
        /// <summary>
        /// Получить менеджера по его номеру.
        /// </summary>
        /// <param name="id">Номер менеджера.</param>
        /// <returns></returns>
        Worker Get(int id);
        /// <summary>
        /// Получить список всех менеджеров в базе.
        /// </summary>
        /// <returns>Список всех менеджеров в базе.</returns>
        IList<Worker> GetAll();
        /// <summary>
        /// Добавить менеджера в базу.
        /// </summary>
        /// <param name="worker">Новый менеджер.</param
        void Add(Worker worker);
        /// <summary>
        /// Обновить менеджера.
        /// </summary>
        /// <param name="worker">Обновленный менеджер.</param>
        void Update(Worker worker);
        /// <summary>
        /// Удалить менеджера по его номеру.
        /// </summary>
        /// <param name="id">Номер менеджера.</param>
        void Delete(int id);

    }
}
