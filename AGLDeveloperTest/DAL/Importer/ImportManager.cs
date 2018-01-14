using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.DAL.Importer
{
    /// <summary>
    /// Manager class for importing data.
    /// </summary>
    public class ImportManager
    {
        private FileImporter importer;
        private string url;
        private string data;

        public string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public FileImporter Importer
        {
            get
            {
                return importer;
            }

            set
            {
                importer = value;
            }
        }

        /// <summary>
        /// Initializes imported based on file type.s
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileType"></param>
        public ImportManager(string url, ImportFileType fileType)
        {
            this.url = url;
            Importer = ImporterFactory.CreateFileImporter(url, fileType);
        }

        /// <summary>
        /// Gets data via the imported.
        /// </summary>
        public void GetData()
        {
            Data = Importer.GetData();
        }
    }
}
