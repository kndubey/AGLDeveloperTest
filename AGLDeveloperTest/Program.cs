using AGLDeveloperTest.Common;
using AGLDeveloperTest.DAL;
using AGLDeveloperTest.DAL.Importer;
using AGLDeveloperTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowSortedData();
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// Shows the list of all cats in alphabetical order under heading of gender of their owners.
        /// </summary>
        private static void ShowSortedData()
        {
            //Get Url Value and File type from configuration file.
            ConfigReader config = new ConfigReader();

            string url = config.UrlValue;
            string fileType = config.FileFormatValue;

            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(fileType))
            {
                ImportFileType efiletype = (ImportFileType)Enum.Parse(typeof(ImportFileType), fileType);

                //Initialize Import Manager depending on type of file.
                ImportManager manager = new ImportManager(url, efiletype);

                if (manager != null)
                {
                    //Injecting the manager to data context.
                    AGLDataContext context = new AGLDataContext(manager);
                    if (context != null)
                    {
                        //Injecting the context for repository.
                        IAGLDevRepository devRepository = new AGLDevRepository(context);

                        if (devRepository != null)
                        {
                            //Getting the Sorted list.
                            Dictionary<string, List<string>> owners = devRepository.GetSortedList();
                            
                            if (owners.Any())
                            {
                                foreach (var item in owners)
                                {
                                    Console.WriteLine($"\n{item.Key} Owners of the cats");

                                    foreach (var x in item.Value)
                                        Console.WriteLine($"  {x}");
                                } 
                            } 
                        } 
                    } 
                }
            }
        }
    }
}
