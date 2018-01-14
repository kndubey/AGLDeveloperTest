using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGLDeveloperTest.Interfaces
{
    /// <summary>
    /// Interface for pets.
    /// </summary>
    public interface IPet
    {
        string Type { get; set; }
        string Name { get; set; }
    }
}
