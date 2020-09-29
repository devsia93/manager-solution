using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Dto
{
    public class OrderDto
    {
        public int ID { get; set; }
        public int ManagerID { get; set; }
        public int CustomerID { get; set; }
        public double Price { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string TypeOfPayment { get; set; }
        public double? Made { get; set; }
    }
}
