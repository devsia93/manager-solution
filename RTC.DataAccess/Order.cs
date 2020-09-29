using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTC.DataAccess
{
    public class Order
    {
        public int ID;
        public int ManagerID;
        public int CustomerID;
        public double Price;
        public DateTime? Date;
        public string Status;
        public string TypeOfPayment;
        public double? Made;
    }
}
