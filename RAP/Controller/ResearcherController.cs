using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Entity;
using RAP.Database;

namespace RAP.Controller
{
    public static class ResearcherController
    {
        public static List<Researcher> Researchers { get; private set; }
        public static Researcher CurrentResearcher { get; private set; }

        // Basic details researcher
        public static List<Researcher> LoadResearcher()
        {
            Researchers = ERDAdapter.FetchBasicResearcherDetails();
            return Researchers;
        }

        public static List<Researcher> FilterBy(EmploymentLevel level)
        {
            List<Researcher> researchers = Researchers;

            if (level != EmploymentLevel.AllLevel)
            {

                var SelectQuery1 =
                    from entry in researchers
                    where entry.CurrentJob == level
                    select entry;

                researchers = SelectQuery1.ToList();
            }

            return researchers.OrderBy(x => x.FamilyName).ToList();
        }

        public static List<Researcher> FilterByName(string name)
        {
            List<Researcher> researchers = Researchers;
            String query;
            query = name.ToUpper();
            if (query != "")
            {
                var SelectQuery2 =
                    from entry in researchers
                    where (entry.GivenName.ToUpper().Contains(name)
                        || entry.FamilyName.ToUpper().Contains(name))
                    select entry;

                researchers = SelectQuery2.ToList();
            }

            return researchers.OrderBy(x => x.FamilyName).ToList();

        }

        public static void LoadResearcherDetails(object select)
        {
            if (select != null)
            {
                ERDAdapter.FetchFullResearcherDetails((int)select);
            }
            CurrentResearcher = (Researcher)select;  
           
        }
    }
}
