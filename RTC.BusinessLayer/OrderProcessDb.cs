using RTC.DataAccess;
using RTC.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.BusinessLayer
{
    public class OrderProcessDb:IOrderProcess
    {
        private readonly IOrderDao _orderDao;

        public OrderProcessDb()
        {
            _orderDao = DaoFactory.GetOrder();
        }
        public void Add(OrderDto order)
        {
            _orderDao.Add(DtoConverter.Convert(order));
        }

        public void Delete(int id)
        {
            _orderDao.Delete(id);
        }
        public IList<OrderDto> GetFromManager(int idManager)
        {
            return DtoConverter.Convert(_orderDao.GetFromManager(idManager));
        }
        public OrderDto Get(int id)
        {
            return DtoConverter.Convert(_orderDao.Get(id));
        }

        public IList<OrderDto> GetList()
        {
            return DtoConverter.Convert(_orderDao.GetAll());
        }

        public void Update(OrderDto order)
        {
            _orderDao.Update(DtoConverter.Convert(order));
        }

        public int GetMaxID()
        {
            return _orderDao.GetMaxID();
        }
    }
}
