using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotallyNormalCalculator
{
    
    public class CalculatorModel
    {

      
        public static long Add(long x, long y)
        {
            
            return x + y;   
        }
        
        public static long Subtract(long x, long y)
        {
            return x - y;
        }

        public static long Mulitply(long x, long y)
        {
            return x * y;
        }

        public static object Divide(long x, long y)
        {
            try
            {
                return x / y;
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }

    }
}
