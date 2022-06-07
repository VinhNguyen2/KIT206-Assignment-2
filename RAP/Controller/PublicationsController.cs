using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Text;
using System.Threading.Tasks;
using RAP.Database;
using RAP.Entity;

namespace RAP.Controller
{
    public static class PublicationsController
    {
        public static List<string> PublicationYears { get; private set; }
        public static Publication CurrentPublication { get; private set; }
     
        public static List<Publication> LoadPublicationsFor(Researcher r)
        {
            r = ResearcherController.CurrentResearcher;

            if (r != null)
            {
                
                PublicationYears = Enumerable.Range(r.EarliestStart.Year, DateTime.Today.Year - (r.EarliestStart.Year - 1))
                    .Select(n => n.ToString()).ToList();
                PublicationYears.Insert(0, "");

                return r.PublicationList; 
            }

            return null;
        }

        public static List<Publication> FilterBy(int year1, int year2)
        {
            // in case the user is strange and enters backwards values
            int earliestYear = Math.Min(year1, year2);
            int latestYear = Math.Max(year1, year2);

            var filterQuery =
                from entry in ResearcherController.CurrentResearcher.PublicationList
                where entry.Year >= earliestYear &&
                    entry.Year <= latestYear
                select entry;

            return filterQuery.ToList(); 
        }
    }
}
