using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGLDeveloperTest;
using AGLDeveloperTest.Common;

namespace AGLDeveloperUnitTest
{
    /// <summary>
    /// Class to test configuraion settings
    /// </summary>
    [TestClass]
    public class ConfigurationFileTests
    {
        ConfigReader reader;

        /// <summary>
        /// Initializer for the class.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            reader = new ConfigReader();
        }

        /// <summary>
        /// Test to check if the URL in configuration file is present.
        /// </summary>
        [TestMethod]
        public void TestConfigurationURLEmpty()
        {
            string url = reader.UrlValue;
            Assert.IsNotNull(url, "URL is Null or Empty.");
        }

        /// <summary>
        /// Tests if the URL in configuration file is well formatted.
        /// </summary>
        [TestMethod]
        public void ConfigurationURLWellFormatted()
        {
            string url = reader.UrlValue;
            Assert.IsFalse(!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute), "URL is not well formatted.");
        }

        /// <summary>
        /// Tests if the File format in confiration file is null or empty.
        /// </summary>
        [TestMethod]
        public void ConfigurationFileFormatEmpty()
        {
            string fileFormat = reader.FileFormatValue;

            Assert.IsFalse(string.IsNullOrEmpty(fileFormat), "File format is null or empty.");
        }

        /// <summary>
        /// Tests is file format is JSON.
        /// </summary>
        [TestMethod]
        public void TestFileFormatType()
        {
            string fileType = reader.FileFormatValue;
            string expectedFileType = "JSON";

            Assert.AreEqual(expectedFileType.ToUpper(), fileType.ToUpper(), $"File Type {fileType }is not as expected {expectedFileType}");
        }
    }
}
