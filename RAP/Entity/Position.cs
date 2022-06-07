using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Entity
{

    public enum EmploymentLevel
    {
        Student,
        A,
        B,
        C,
        D,
        E,
        AllLevel
    }
    public class Position
    {
        public EmploymentLevel Level { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string Title
        {

            get { return "Dr"; }//ToTitle; }
            //TODO unclear
        }


        public string ToTitle(EmploymentLevel l)

        {

            switch (l)

            {

                case EmploymentLevel.Student:

                    return "Student";

                case EmploymentLevel.A:

                    return "Postdoc";

                case EmploymentLevel.B:

                    return "Lecturer";

                case EmploymentLevel.C:

                    return "Senior Lecturer";

                case EmploymentLevel.D:

                    return "Associate Professor";

                case EmploymentLevel.E:

                    return "Professor";

                default:

                    return "Error in EmploymentLevel";

            }

        }

        //public string ToTitle
        //        {
        //            get
        //            {
        //                switch (Level)
        //                {
        //                    case EmploymentLevel.Student:
        //                        return "Student";
        //                    case EmploymentLevel.A:
        //                        return "Postdoc";
        //                    case EmploymentLevel.B:
        //                        return "Lecturer";
        //                    case EmploymentLevel.C:
        //                        return "Senior Lecturer";
        //                    case EmploymentLevel.D:
        //                        return "Associate Professor";
        //                    case EmploymentLevel.E:
        //                        return "Professor";
        //                    default:
        //                        return "Error in EmploymentLevel";
        //                }
        //            }
       // }
    }
}
