﻿using RTC.DataAccess;
using RTC.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.BusinessLayer
{
    public class WorkerProcessDb:IWorkerProcess
    {
        private readonly IWorkerDao _workerDao;

        public WorkerProcessDb()
        {
            _workerDao = DaoFactory.GetWorker();
        }

        public void Add(WorkerDto worker)
        {
            _workerDao.Add(DtoConverter.Convert(worker));
        }

        public void Delete(int id)
        {
            _workerDao.Delete(id);
        }

        public WorkerDto Get(int id)
        {
            return DtoConverter.Convert(_workerDao.Get(id));
        }

        public IList<WorkerDto> GetList()
        {
            return DtoConverter.Convert(_workerDao.GetAll());
        }

        public void Update(WorkerDto worker)
        {
            _workerDao.Update(DtoConverter.Convert(worker));
        }
    }
}
