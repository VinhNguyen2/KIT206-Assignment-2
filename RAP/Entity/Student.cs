using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{
    public class Student : Researcher
    {
        //Should there be a staff member stored here?
        public string Degree { get; set; }
        public int Supervisor_id { get; set; }

    }
}
