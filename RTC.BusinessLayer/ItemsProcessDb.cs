using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTC.DataAccess;
using RTC.Dto;

namespace RTC.BusinessLayer
{
    public class ItemsProcessDb : IItemsProcess
    {
        private readonly IItemsDao _itemsDao;

        public ItemsProcessDb()
        {
            _itemsDao = DaoFactory.GetItems();
        }
        public void Add(ItemsDto item)
        {
            _itemsDao.Add(DtoConverter.Convert(item));
        }

        public void Delete(int idOrder)
        {
            _itemsDao.Delete(idOrder);
        }

        public IList<ItemsDto> GetList()
        {
            return DtoConverter.Convert(_itemsDao.GetAll());
        }

        public void Update(ItemsDto item)
        {
            _itemsDao.Update(DtoConverter.Convert(item));
        }
    }
}
