﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorContract;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.IO;

namespace CompositionHelper
{
    public class CalciCompositionHelper
    {
        [ ImportMany]
        public System.Lazy<ICalculator,IDictionary<string, object>>[] CalciPlugins{ get; set; }



        [Import("PTru",typeof( Func<int,int,int>))]
        public Func<int,int,int> PTTru { get; set; }
        /// <summary>
        /// Assembles the calculator components
        /// </summary>
        public void AssembleCalculatorComponents()
        {
            try
            {
                //Step 1: Initializes a new instance of the 
                //        System.ComponentModel.Composition.Hosting.AssemblyCatalog  
                //        class with the current executing assembly.
                var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

                //Step 2: The assemblies obtained in step 1 are added to the 
                //CompositionContainer
                var container = new CompositionContainer(catalog);

                //Step 3: Composable parts are created here i.e. 
                //the Import and Export components 
                //        assembles here
                container.ComposeParts(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sends the result back to the client
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int GetResult(int num1, int num2, string operationType)
        {
            int c= PTTru(num1, num2);
            int result = 0;
            foreach (var CalciPlugin in CalciPlugins)
            {
                //["CalciMetaData"] == 
                if ((string)CalciPlugin.Metadata["CalciMetaData"] == operationType)
                {
                    result = CalciPlugin.Value.GetNumber(num1, num2);
                    break;
                }
            }
            return result;
        }

    }

}

