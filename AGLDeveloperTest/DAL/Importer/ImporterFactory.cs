using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.DAL.Importer
{
    //Factory class to initialize appropriate concrete class.
    public class ImporterFactory
    {
        #region Methods

        public static FileImporter CreateFileImporter(string url, ImportFileType fileType)
        {
            switch (fileType)
            {
                case ImportFileType.JSON:
                    return new JSONImporter(url);

                case ImportFileType.XML:
                    return new XMLImporter();

                default:
                    throw new ArgumentException("The import file type is not supported.");
            }
        }

        #endregion
    }




   
}
