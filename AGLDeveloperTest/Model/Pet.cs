using AGLDeveloperTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.Model
{
    /// <summary>
    /// Pet class.
    /// </summary>
    public class Pet : IPet
    {
        private string name;
        private string type;
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

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
