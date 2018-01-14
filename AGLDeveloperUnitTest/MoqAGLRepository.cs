using AGLDeveloperTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGLDeveloperTest.Model;

namespace AGLDeveloperUnitTest
{
    /// <summary>
    /// Moq class for repository.
    /// </summary>
    public class MoqAGLRepository : IAGLDevRepository
    {
        private List<Owner> moqOwners = new List<Owner>();

        /// <summary>
        /// COnstructs moq objects for the class.
        /// </summary>
        public MoqAGLRepository()
        {
            List<Owner> tempList = new List<Owner>();
            List<Pet> tempPets= new List<Pet>();
            Owner moqOwner1 = new Owner();
            moqOwner1.Age = 45;
            moqOwner1.Gender = "male";
            moqOwner1.Name = "Steve";

            tempList.Add(moqOwner1);
            
            Owner moqOwner2 = new Owner();
            moqOwner2.Age = 23;
            moqOwner2.Gender = "male";
            moqOwner2.Name = "Bob";

            Pet pet1 = new Pet() { Name = "Garfield", Type = "Cat"  };
            Pet pet2 = new Pet() { Name = "Fido", Type = "Dog" };
            tempPets.Add(pet1);
            tempPets.Add(pet2);

            moqOwner1.Pets = tempPets;
            

            tempList.Add(moqOwner2);

            Owner moqOwner3 = new Owner();
            moqOwner3.Age = 40;
            moqOwner3.Gender = "female";
            moqOwner3.Name = "Samantha";

            List<Pet> tempPets1 = new List<Pet>();
            Pet pet3 = new Pet() { Name = "Tabby", Type = "Cat" };
            
            tempPets1.Add(pet3);

            moqOwner3.Pets = tempPets1;
            
            tempList.Add(moqOwner3);

            //--//
            Owner moqOwner4 = new Owner();
            moqOwner4.Age = 40;
            moqOwner4.Gender = "male";
            moqOwner4.Name = "Fred";

            List<Pet> tempPets2 = new List<Pet>();
            Pet pet4 = new Pet() { Name = "Tom", Type = "Cat" };
            Pet pet5 = new Pet() { Name = "Max", Type = "Cat" };
            Pet pet6 = new Pet() { Name = "Sam", Type = "Dog" };
            Pet pet7 = new Pet() { Name = "Jim", Type = "Cat" };

            tempPets2.Add(pet4);
            tempPets2.Add(pet5);
            tempPets2.Add(pet6);
            tempPets2.Add(pet7);

            moqOwner4.Pets = tempPets2;

            tempList.Add(moqOwner4);
            //---//

            //--//
            Owner moqOwner5 = new Owner();
            moqOwner5.Age = 18;
            moqOwner5.Gender = "female";
            moqOwner5.Name = "Jennifer";

            List<Pet> tempPets3 = new List<Pet>();
            Pet pet8 = new Pet() { Name = "Garfield", Type = "Cat" };

            tempPets3.Add(pet8);
            
            moqOwner5.Pets = tempPets3;

            tempList.Add(moqOwner5);
            //---//

            //--//
            Owner moqOwner6 = new Owner();
            moqOwner6.Age = 64;
            moqOwner6.Gender = "female";
            moqOwner6.Name = "Alice";

            List<Pet> tempPets4 = new List<Pet>();
            Pet pet9 = new Pet() { Name = "Simba", Type = "Cat" };
            Pet pet10 = new Pet() { Name = "Nemo", Type = "Fish" };

            tempPets4.Add(pet9);
            tempPets4.Add(pet10);

            moqOwner6.Pets = tempPets4;

            tempList.Add(moqOwner6);
            //---//

            moqOwners = tempList;
        }

        /// <summary>
        /// Returns moq owner list.
        /// </summary>
        public List<Owner> GetOwners
        {
            get
            {
                return moqOwners;
            }
        }

        /// <summary>
        /// Returns alphabetical sorted collection for male and female cat owners.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<string>> GetSortedList()
        {
            Dictionary<string, List<string>> genderVsName = new Dictionary<string, List<string>>();
            List<Owner> maleOnwers = moqOwners.Where(x => x.Gender.ToUpper() == "MALE").ToList();

            List<Pet> maleOwnersOfCat = (from o in maleOnwers
                            where o.Pets != null
                            select o)
                           .SelectMany(o => o.Pets)
                           .Where(p => !string.IsNullOrEmpty(p.Type) &&  p.Type.ToUpper() == "CAT").OrderBy(p => p.Name).ToList();

            genderVsName.Add("Male", maleOwnersOfCat.Select(x => x.Name).ToList());
            
            List<Owner> femaleOnwers = moqOwners.Where(x => x.Gender.ToUpper() == "FEMALE").ToList();

            List<Pet> femaleOwnersOfCat = (from o in femaleOnwers
                                           where o.Pets != null
                                           select o)
                           .SelectMany(o => o.Pets)
                           .Where(p => !string.IsNullOrEmpty(p.Type) && p.Type.ToUpper() == "CAT").OrderBy(p => p.Name).ToList();
            genderVsName.Add("Female", femaleOwnersOfCat.Select(x => x.Name).ToList());
          
            return genderVsName;

        }

        public void Dispose()
        {
            if (moqOwners != null)
                moqOwners = null;
        }
    }
}
