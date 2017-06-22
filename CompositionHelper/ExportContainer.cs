using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompositionHelper
{
    public class ExportContainer
    {

        [ImportingConstructor]
        public ExportContainer([Import(AllowDefault = true)]Action<string> specialDelegate)
        {
            this.MyActionDelegate = specialDelegate;
        }

        public string ExportName { get; set; }
        public Action<string> MyActionDelegate { get; set; }

        [Export]
        [ExportMetadata("Name", "Plugin from Plugin1")]
        public string GetName()
        {
            this.ExportName = "Plugin from Plugin1";

            if (this.MyActionDelegate != null)
                this.MyActionDelegate(this.ExportName);

            return this.ExportName;
        }
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


    }
}
