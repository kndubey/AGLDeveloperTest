using AGLDeveloperTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AGLDeveloperTest.Interfaces
{
    public interface IAGLDevRepository : IDisposable
    {
        List<Owner> GetOwners { get; }
        
        Dictionary<string, List<string>> GetSortedList();
    }
}
