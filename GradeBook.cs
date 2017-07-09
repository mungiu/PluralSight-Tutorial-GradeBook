using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSGrades
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public bool ThrowAwayLowest { get; set; }

        //we use "virtual" so when C# compiler observes we are invoking
        //ComputeStatistics(); through a variable types as "GradeBook"
        //it will no longer use the type of "variable" to figure out
        //which method to call, insted it will use the type of "object"
        //the type it sees at "runtime"
        //so when it sees that GradeBook is utimatelly a ThrowAwayGrade 
        //it will check if the "ThrowAwayGradeBook" overrides "ComputeStatistics();"
        public override GradeStatistics ComputeStatistics()
        {
            //Indicating where the debug takes place (pop-up writeline)
            Console.WriteLine("GradeBook::ComputeStatistics");

            GradeStatistics stats = new GradeStatistics();
            
            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        
        // Creating method "WriteGrades"
        // "destination" is declared as a "TextWriter"
        // "destination" - writes grades from an "array" to a destination
        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i-1]);
            }
        }

        
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        //Implementing GetEnumerator 
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }
        protected List<float> grades;
        
    }
}
