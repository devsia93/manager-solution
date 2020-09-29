using RTC.DataAccess;
using RTC.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.BusinessLayer
{
    public class DtoConverter
    {
        #region Worker
        public static WorkerDto Convert(Worker worker)
        {
            if (worker == null)
                return null;
            WorkerDto workerDto = new WorkerDto();
            workerDto.Adress = worker.Adress;
            workerDto.ID = worker.ID;
            workerDto.Name = worker.Name;
            workerDto.Phone = worker.Phone;
            return workerDto;
        }
        public static Worker Convert(WorkerDto workerDto)
        {
            if (workerDto == null)
                return null;
            Worker worker = new Worker();
            worker.Adress = workerDto.Adress;
            worker.ID = workerDto.ID;
            worker.Name = workerDto.Name;
            worker.Phone = workerDto.Phone;
            return worker;
        }
        public static IList<WorkerDto> Convert(IList<Worker> workers)
        {
            if (workers == null)
                return null;
            IList<WorkerDto> workerDtos = new List<WorkerDto>();
            foreach (var worker in workers)
            {
                workerDtos.Add(Convert(worker));
            }
            return workerDtos;
        }
        #endregion

        #region Customer
        public static CustomerDto Convert(Customer customer)
        {
            if (customer == null)
                return null;
            CustomerDto customerDto = new CustomerDto();
            customerDto.Adress = customer.Adress;
            customerDto.ID = customer.ID;
            customerDto.Info= customer.Info;
            customerDto.ManagerID = customer.ManagerID;
            customerDto.Name = customer.Name;
            customerDto.Phone = customer.Phone;
            return customerDto;
        }
        public static Customer Convert(CustomerDto customerDto)
        {
            if (customerDto == null)
                return null;
            Customer customer = new Customer();
            customer.Adress = customerDto.Adress;
            customer.ID= customerDto.ID;
            customer.Info= customerDto.Info;
            customer.ManagerID= customerDto.ManagerID;
            customer.Name = customerDto.Name;
            customer.Phone = customerDto.Phone;
            return customer;
        }
        public static IList<CustomerDto> Convert(IList<Customer> customers)
        {
            if (customers == null)
                return null;
            IList<CustomerDto> customerDtos = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                customerDtos.Add(Convert(customer));
            }
            return customerDtos;
        }

        #endregion

        #region Order
        public static OrderDto Convert(Order order)
        {
            if (order == null)
                return null;
            OrderDto orderDto = new OrderDto();
            orderDto.CustomerID = order.CustomerID;
            orderDto.Date = order.Date;
            orderDto.ID = order.ID;
            orderDto.Made = order.Made;
            orderDto.ManagerID = order.ManagerID;
            orderDto.Price = order.Price;
            orderDto.Status = order.Status;
            orderDto.TypeOfPayment = order.TypeOfPayment;
            return orderDto;
        }
        public static Order Convert(OrderDto orderDto)
        {
            if (orderDto == null)
                return null;
            Order order = new Order();
            order.CustomerID = orderDto.CustomerID;
            order.ID = orderDto.ID;
            order.Date = orderDto.Date;
            order.ManagerID = orderDto.ManagerID;
            order.Made = orderDto.Made;
            order.Price = orderDto.Price;
            order.Status = orderDto.Status; ;
            order.TypeOfPayment = orderDto.TypeOfPayment;
            return order;
        }
        public static IList<OrderDto> Convert(IList<Order> orders)
        {
            if (orders == null)
                return null;
            IList<OrderDto> orderDtos = new List<OrderDto>();
            foreach (var order in orders)
            {
                orderDtos.Add(Convert(order));
            }
            return orderDtos;
        }

        #endregion

        #region Product
        public static ProductDto Convert(Product product)
        {
            if (product == null)
                return null;
            ProductDto productDto = new ProductDto();
            productDto.Count = product.Count;
            productDto.ID = product.ID;
            productDto.Importer = product.Importer;
            productDto.MRC = product.MRC;
            productDto.Price = product.Price;
            productDto.Reserve = product.Reserve;
            productDto.Title = product.Title;
            return productDto;
        }
        public static Product Convert(ProductDto productDto)
        {
            if (productDto == null)
                return null;
            Product product = new Product();
            product.Count = productDto.Count;
            product.ID = productDto.ID;
            product.Importer = productDto.Importer;
            product.MRC = productDto.MRC;
            product.Price = productDto.Price;
            product.Reserve = productDto.Reserve;
            product.Title = productDto.Title; ;
            return product;
        }
        public static IList<ProductDto> Convert(IList<Product> products)
        {
            if (products == null)
                return null;
            IList<ProductDto> productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(Convert(product));
            }
            return productDtos;
        }

        #endregion

        #region Items
        public static ItemsDto Convert(Items items)
        {
            if (items == null)
                return null;
            ItemsDto itemsDto = new ItemsDto();
            itemsDto.Count = items.Count;
            itemsDto.ID = items.ID;
            itemsDto.OrderID = items.OrderID;
            itemsDto.Price = items.Price;
            itemsDto.ProductID = items.ProductID;
            return itemsDto;
        }
        public static Items Convert(ItemsDto itemsDto)
        {
            if (itemsDto == null)
                return null;
            Items items = new Items();
            items.Count = itemsDto.Count;
            items.ID = itemsDto.ID;
            items.OrderID = itemsDto.OrderID;
            items.Price = itemsDto.Price;
            items.ProductID = itemsDto.ProductID;
            return items;
        }
        public static IList<ItemsDto> Convert(IList<Items> items)
        {
            if (items == null)
                return null;
            IList<ItemsDto> itemsDtos = new List<ItemsDto>();
            foreach (var item in items)
            {
                itemsDtos.Add(Convert(item));
            }
            return itemsDtos;
        }

        #endregion
    }
}
