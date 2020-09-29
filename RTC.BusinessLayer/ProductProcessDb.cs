using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTC.DataAccess;
using RTC.Dto;

namespace RTC.BusinessLayer
{
    public class ProductProcessDb : IProductProcess
    {
        private readonly IProductDao _productDao;

        public ProductProcessDb()
        {
            _productDao = DaoFactory.GetProduct();
        }
        public void Add(ProductDto product)
        {
            _productDao.Add(DtoConverter.Convert(product));
        }

        public void Delete(int id)
        {
            _productDao.Delete(id);
        }

        public ProductDto Get(int id)
        {
            return DtoConverter.Convert(_productDao.Get(id));
        }

        public IList<ProductDto> GetList()
        {
            return DtoConverter.Convert(_productDao.GetAll());
        }

        public void Update(ProductDto product)
        {
            _productDao.Update(DtoConverter.Convert(product));
        }

        public ProductDto GetID(string Title)
        {
            return DtoConverter.Convert(_productDao.GetID(Title));
        }

        public void AddCount(int count, int id)
        {
            _productDao.AddCount(count, id);
        }
    }
}
