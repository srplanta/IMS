using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"|{Id},\t{Name},\t{Description},\t{Make},\t{Price}";
        }
    }
}
