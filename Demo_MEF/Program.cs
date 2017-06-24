using CompositionHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo_MEF
{

    [Export]
    public class TextFormatter
    {
        public string Format(string str)
        {
            return string.Format("Formatted Message:{0}", str);
        }
    }

    [Export]
    public class ConsoleLogger
    {
        TextFormatter _formatter;

        [ImportingConstructor]
        public ConsoleLogger(TextFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Log(string str)
        {
            string formattedString = _formatter.Format(str);
            Console.WriteLine(formattedString);
        }
    }

    class Program
    {
        int a = 0;
        [Import]
        public ConsoleLogger Logger { get; set; }
        
        static void Main(string[] args)
        {
            Program p = new Program();
            CompositionContainer container =
            new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            
            container.ComposeParts(p);
            p.Logger.Log("This is a test");
        }
    }

    class Program1
    {
        static void Main1(string[] args)
        {




            var objCompHelper = new CalciCompositionHelper();

            //Assembles the calculator components that will participate in composition
            objCompHelper.AssembleCalculatorComponents();

            var result = objCompHelper.GetResult(1, 2,"+");
            Console.ReadLine();
        }
    }
}
