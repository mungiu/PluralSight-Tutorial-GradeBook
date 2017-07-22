using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSGrades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        //"override" - does not mean we hide/replace "ComputeStatistics();" in "GradeBook"
        //we can still access the original method using "base.ComputeStatistics();"
        public override GradeStatistics ComputeStatistics()
        {
            //Indicating where the debug takes place (pop-up writeline)
            Console.WriteLine("ThrowAwayGradeBook::ComputeStatistics");
            //"lowest" is assigned the highest possible value "float" can take
            float lowest = float.MaxValue;
            //loops through all grades in "grades" and updates "lowest"
            //with the newest lowest found value
            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);   
            }
            //attempting to throw away the lowest found grade from the "list"
            grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}
