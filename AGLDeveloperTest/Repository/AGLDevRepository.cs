using AGLDeveloperTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGLDeveloperTest.Model;

namespace AGLDeveloperTest.DAL
{
    /// <summary>
    /// Repository class.
    /// </summary>
     public class AGLDevRepository : IAGLDevRepository
    {
        private AGLDataContext context;
        
        public AGLDevRepository(AGLDataContext injectedContext)
        {
            this.context = injectedContext;
        }

        /// <summary>
        /// Returns the owners.
        /// </summary>
        public List<Owner> GetOwners
        {
            get
            {
                this.context.GetOwners();
                return this.context.Owners;
            }
        }

        public void Dispose()
        {
            if (context != null)
                context = null;
        }

        /// <summary>
        /// Retuns sorted list (alphabetically) for male and female owners of the cats.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<string>> GetSortedList()
        {
            Dictionary<string, List<string>> genderVsName = new Dictionary<string, List<string>>();
            List<Owner> allOwners = GetOwners;
            List<Owner> maleOnwers = allOwners.Where(x => x.Gender.ToUpper() == "MALE").ToList();

            List<Pet> maleOwnersOfCat = (from o in maleOnwers
                                         where o.Pets != null
                                         select o)
                           .SelectMany(o => o.Pets)
                           .Where(p => !string.IsNullOrEmpty(p.Type) && p.Type.ToUpper() == "CAT").OrderBy(p => p.Name).ToList();

            genderVsName.Add("Male", maleOwnersOfCat.Select(x => x.Name).ToList());

            List<Owner> femaleOnwers = allOwners.Where(x => x.Gender.ToUpper() == "FEMALE").ToList();

            List<Pet> femaleOwnersOfCat = (from o in femaleOnwers
                                           where o.Pets != null
                                           select o)
                           .SelectMany(o => o.Pets)
                           .Where(p => !string.IsNullOrEmpty(p.Type) && p.Type.ToUpper() == "CAT").OrderBy(p => p.Name).ToList();
            genderVsName.Add("Female", femaleOwnersOfCat.Select(x => x.Name).ToList());

            return genderVsName;
        }
    }
}
