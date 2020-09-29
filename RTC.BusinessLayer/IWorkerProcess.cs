using System;
using RTC.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.BusinessLayer
{
    public interface IWorkerProcess
    {
        /// <summary>
        /// Получить список всех работников.
        /// </summary>
        /// <returns>Список работников.</returns>
        IList<WorkerDto> GetList();
        /// <summary>
        /// Получить работника по его номеру.
        /// </summary>
        /// <param name="id">Номер работника.</param>
        /// <returns>Клиент.</returns>
        WorkerDto Get(int id);
        /// <summary>
        /// Добавить работника.
        /// </summary>
        /// <param name="worker">Работник.</param>
        void Add(WorkerDto worker);
        /// <summary>
        /// Обновить данные о работнике.
        /// </summary>
        /// <param name="worker">Работник.</param>
        void Update(WorkerDto worker);
        /// <summary>
        /// Удалить работника.
        /// </summary>
        /// <param name="id">Номер работника.</param>
        void Delete(int id);
    }
}
