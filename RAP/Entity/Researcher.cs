using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public enum Campus { Hobart, Launceston, Creadle_Coast };

    public class Researcher
    {
        public int Id { get; set; } //private as specified in uml TODO
        public string Type { get; set; } //should probably be an enum
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; } //says url in documentation, implement as string ?
        public EmploymentLevel CurrentJob { get; set; } //should also be an enum?

        public DateTime Utas_start { get; set; }
        public DateTime Current_start { get; set; }

        //these may not be relevant due to database setup
        public List<Position> Positions { get; set; }
        public List<Publication> PublicationList { get; set; }

        public DateTime EarliestStart  { get; set; }

        public string CurrenJobTitle { get { return Positions.Last().Title; } }

        public float Tenure {get{ return (float) ((DateTime.Now - Utas_start).TotalDays / 365.2422);} }



        //positions added to list so last is current job first is first job, may make more sense to reverse this
        public Position GetCurrentJob()
        {
            return Positions.Last();
        }
        public string CurrentJobTitle()
        {
            return Positions.Last().Title;
        }
        /*
        public DateTime CurrentJobStart()
        {
            return positions.Last().start;
        }
        made irrelevant by database formatting (variable given directly from researcher table)*/
        public Position GetEarliestJob()
        {
            return Positions.First();
        }
        /*
        public DateTime EarliestStart()
        {
            return positions.First().start; 
        }
        made irrelevant by database format (variable given directly from researcher table) */
        /*
        public float Tenure()
        {
            return (float)((DateTime.Now - Utas_start).TotalDays / 365.2422);
        }
        */
        public int PublicationsCount()
        {
            return PublicationList.Count();
        }
        //this is just for my testing and IS not complete
        public override string ToString()
        {
            return "" + Id + " (" + Title + ")" + GivenName + " " + FamilyName + " " + Email;
        }

    }

}
