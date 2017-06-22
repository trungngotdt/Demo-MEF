using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.Reflection;

namespace CompositionHelper
{
    public class Tru
    {
        [Export("PTru",typeof(Func<int,int,int>))]
        public int PTru(int a,int b)
        {
            return a - b;
        }
    }
}
