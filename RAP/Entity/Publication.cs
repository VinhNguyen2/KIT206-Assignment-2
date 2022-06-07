using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public enum OutputType
    {
        Conference,
        Journal,
        Other
    };
    public class Publication
    {
        public string DOI { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; } //seems like a list of strings may be more fitting? depends on it's use
        public int Year { get; set; } //think years are just represented as ints in C#
        public OutputType Type { get; set; }
        public string CiteAs { get; set; }
        public DateTime Available { get; set; }
        //TODO? need a way to not create duplicates for each author of paper? a researcher list?
        public int Age()
        {
            return (DateTime.Now - Available).Days; //Should work, not certain
        }
    }

}
