using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using CalculatorContract;

namespace CompositionHelper
{
    [Export( typeof(ICalculator))]
    [ExportMetadata("Add","*")]
    public class Nhan :ICalculator
    {
        public int GetNumber(int a, int b)
        {
            return a * b;
        }
    }
}
