using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AGLDeveloperTest.Model;

namespace AGLDeveloperTest.DAL
{
    /// <summary>
    /// Json deserializer class.
    /// </summary>
    public class JSONDeserializer
    {
        /// <summary>
        /// Returns list of owners from JSON data.
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public List<Owner> GetOwnersFromJSon(string jsonString)
        {
            List<Owner> ownerList = JsonConvert.DeserializeObject<List<Owner>>(jsonString);
            return ownerList;
        }
    }
}
