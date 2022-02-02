using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotallyNormalCalculator.MVVM.Model
{
    public enum Operation { Null, Addition, Subtraction, Multiplication, Division, Power}

    public class CalculationModel
    {
        public static Operation Operation { get; set; }
        public static double FirstNumber { get; set; }
        public static double SecondNumber { get; set; }
        public static double Result { get; set; }

    }

    
}
