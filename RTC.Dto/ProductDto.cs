using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC.Dto
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public double MRC { get; set; }
        public int Count { get; set; }
        public int? Reserve { get; set; }
        public double Price { get; set; }
        public string Importer { get; set; }
    }
}
