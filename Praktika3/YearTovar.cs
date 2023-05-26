using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika3
{
   public class YearTovar:TovarSklad
    {
        public int Year { get; set; }

        public YearTovar (string name, decimal price, int quantity, int year) : base(name, price, quantity)
        {
            Year = year;
        }


        public new decimal CalculateQuality ()
        {
            decimal baseQuality = base.CalculateQuality( );
            decimal OkrygbaseQuality = Math.Round(baseQuality, 2);

            decimal a = OkrygbaseQuality + 0.5m * (DateTime.Now.Year - Year);
            decimal End = Math.Round(a, 3);
            return End;
                
        }
    }
}
