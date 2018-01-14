using AGLDeveloperTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AGLDeveloperTest.Common;
using AGLDeveloperTest.DAL.Importer;

namespace AGLDeveloperTest.DAL
{
    public class AGLDataContext
    {
        public List<Owner> Owners { get; set; }
        
        private ImportManager importManager;

        /// <summary>
        /// Initializes dependent objects.
        /// </summary>
        /// <param name="injectedManager"></param>
        public AGLDataContext(ImportManager injectedManager)
        {
            importManager = injectedManager;
            ConfigReader reader = new ConfigReader();
            string fileFormat = reader.FileFormatValue;
            string url = reader.UrlValue;
        }

        /// <summary>
        /// Gets json data and deserialize the JSON data.
        /// </summary>
        protected internal void GetOwners()
        {
            importManager.GetData();
            
            Owners = new JSONDeserializer().GetOwnersFromJSon(importManager.Data);
        }
    }
}
