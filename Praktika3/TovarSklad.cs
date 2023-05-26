using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika3
{
   public class TovarSklad
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public TovarSklad (string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public decimal CalculateQuality ()
        {
            return Price / Quantity;
        }

        public override string ToString ()
        {
            return Name;
        }
    }
}
