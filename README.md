AGLDeveloperTest

This project is created for AGL Developer test to consume a Web API and list the data in alphabetical order grouped by gender.

It contains 2 Projects
1. AGLDeveloperTest
   - This project is a windows console project which consumes the Web Api configurable in App.config.
   - Uses repository, factory and DI pattern.
   - Uses Newtonsoft.json to deserialize the JSON result from web api.
   - Exception handling and logging are not included in the project. 

2. AGLDeveloperUnitTest
   - This is an MSTest project for the AGLDeveloperTest.
   - Hand written mock class has been used to test the repository.
   - Configuration, classes and web api can be unit tested through this project.
