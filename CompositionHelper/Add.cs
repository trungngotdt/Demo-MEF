using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorContract;

namespace CompositionHelper
{
    [Export( typeof(ICalculator))]
    [ExportMetadata("Add","+")]
    public class Add : ICalculator
    {
        #region Interface members
        public int GetNumber(int num1, int num2)
        {
            return num1 + num2;
        }
        #endregion
    }

}
