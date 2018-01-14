using AGLDeveloperTest.DAL.Importer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperUnitTest
{
    /// <summary>
    /// Moq web api read class.
    /// </summary>
    public class MoqWebApiReader : FileImporter
    {
        private string moqData = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]}]";
        
        /// <summary>
        /// Retuns mocked string data.
        /// </summary>
        /// <returns></returns>
        public override string GetData()
        {
            return moqData;
        }
    }
}
