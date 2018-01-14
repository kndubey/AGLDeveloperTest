using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AGLDeveloperTest.Common
{
    /// <summary>
    /// Class to read settings from application's config file.
    /// </summary>
    public class ConfigReader
    {
        private readonly string FileFormatKey = "FileFormat";
        private readonly string URLKey = "URL";

       
        /// <summary>
        /// Retuns File Format value from app settings.
        /// </summary>
        public string FileFormatValue
        {
            get
            {
                return ConfigurationManager.AppSettings[FileFormatKey];
            }
        }
     
        /// <summary>
        /// Retuns Url value from app settings.
        /// </summary>
        public string UrlValue
        {
            get
            {
                return ConfigurationManager.AppSettings[URLKey];
            }
        }
    }
}
