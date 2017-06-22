using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorContract
{
    public interface ICalculator
    {
        int GetNumber(int a, int b);
    }
}
