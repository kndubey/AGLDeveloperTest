using AGLDeveloperTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.Interfaces
{
    /// <summary>
    /// Interface for owner.
    /// </summary>
    public interface IOwner
    {
        string Name { get; set; }
        string Gender { get; set; }
        int Age { get; set; }
        
        List<Pet> Pets { get; set; }
    }
}
