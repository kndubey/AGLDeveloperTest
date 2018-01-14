using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGLDeveloperTest.Common;
using AGLDeveloperTest.DAL.Importer;
using AGLDeveloperTest.Interfaces;
using AGLDeveloperTest.DAL;
using AGLDeveloperTest.Model;
using System.Collections.Generic;

namespace AGLDeveloperUnitTest
{
    /// <summary>
    /// Class to test Web api calls and json data validation.
    /// </summary>
    [TestClass]
    public class FileReaderTest
    {
        string fileType;
        string url;
        ImportFileType efiletype = ImportFileType.None;
        ConfigReader reader;

        /// <summary>
        /// Initializer for the tests.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            reader = new ConfigReader();
            fileType = reader.FileFormatValue;
            url = reader.UrlValue;
            efiletype = (ImportFileType)Enum.Parse(typeof(ImportFileType), fileType);
        }

        /// <summary>
        /// Test to check if importer class is initialized and is of type for json.
        /// </summary>
        [TestMethod]
        public void FactoryObectInitiatorTest()
        {
            //Arrange
            fileType = reader.FileFormatValue;
            ImportFileType efiletype = (ImportFileType) Enum.Parse(typeof (ImportFileType), fileType);

            //Act
            ImportManager manager = new ImportManager(url, efiletype);
        
            //Assert
            Assert.IsNotNull(manager.Importer, "Factory reader object is null.");

            Assert.IsInstanceOfType(manager.Importer, typeof(JSONImporter));
        }

        /// <summary>
        /// Test to check if data is retreived from WebApi reader moq class.
        /// </summary>
        [TestMethod]
        public void MoqWebApiReaderTest()
        {

            string mowData = new MoqWebApiReader().GetData();

            Assert.IsFalse(string.IsNullOrEmpty(mowData), "There is not data from web api.");
        }

        /// <summary>
        /// Integration test to check the data is received from Web Api or not.
        /// This is not a check for correctness of data.
        /// </summary>
        [TestMethod]
        public void JsonDataTest()
        {
            //Arrange
            ImportManager manager = new ImportManager(url, efiletype);

            //Act
            manager.GetData();
            string data = manager.Data;

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(data));
        }

        /// <summary>
        /// Test to verify if owner list is retreived from repository.
        /// </summary>
        [TestMethod]
        public void AGLDevRepositoryOwnersTestMoq()
        {
            //Arrange
            IAGLDevRepository moqRepository = new MoqAGLRepository();

            //Act
            IEnumerable<Owner> moqOwners = moqRepository.GetOwners;

            //Assert
            Assert.IsNotNull(moqOwners);

        }

        /// <summary>
        /// Test to verify the sorting list is retreived from repository.
        /// </summary>
        [TestMethod]
        public void AGLDevRepositoryTestMoq()
        {
            //Arrange
            IAGLDevRepository moqRepository = new MoqAGLRepository();

            //Act
            Dictionary<string, List<string>> moqOwners = moqRepository.GetSortedList();

            //Assert
            Assert.IsNotNull(moqOwners);

        }

        /// <summary>
        /// Test to check sorting for First cat for male and female owners.
        /// </summary>
        [TestMethod]
        public void AGLDevRepositorySortTestMoq()
        {
            //Arrange
            IAGLDevRepository moqRepository = new MoqAGLRepository();
            string expectedFirstCatForMale = "Garfield";
            string expectedFirstCatForFemale = "Garfield";

            //Act
            Dictionary<string, List<string>> moqOwners = moqRepository.GetSortedList();

            //Assert
            Assert.IsFalse(!moqOwners["Male"][0].Equals(expectedFirstCatForMale), $"Expected:{expectedFirstCatForMale}, actual:{moqOwners["Male"][0]}");
            Assert.IsFalse(!moqOwners["Female"][0].Equals(expectedFirstCatForFemale), $"Expected:{expectedFirstCatForFemale}, actual:{moqOwners["Female"][0]}");
        }

        /// <summary>
        /// Integration test for Web Api call to get JSON data.
        /// </summary>
        [TestMethod]
        public void JsonDataRepositoryTest()
        {
            ImportManager manager = new ImportManager(url, efiletype);
            AGLDataContext context = new AGLDataContext(manager);
            IAGLDevRepository devRepository = new AGLDevRepository(context);

            Dictionary<string, List<string>> owners = devRepository.GetSortedList();

            Assert.IsNotNull(owners);
        }
    }
}
