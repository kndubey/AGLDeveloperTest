using AGLDeveloperTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.Model
{
    /// <summary>
    /// Owner class
    /// </summary>
    public class Owner : IOwner
    {
        private int age;
        private string gender;
        private string name;
        
        private List<Pet> pets;
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public List<Pet> Pets
        {
            get
            {
                return pets;
            }
            set
            {
                pets = value;
            }
        }
    }
}
