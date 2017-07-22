using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSGrades
{
    // Created Class only for "storing" values of grade statistics
    // E.G: Value assignment to objects 
    // Other calculations happen in "GradeBook.cs"
    // E.G: Calculating "AverageGrade"
    public class GradeStatistics
    {
        //declaring the variables
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;

        //assigning values
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }

        //creating result description
        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;

                    case "B":
                        result = "Good";
                        break;

                    case "C":
                        result = "Average";
                        break;

                    case "D":
                        result = "Below Average";
                        break;

                    default:
                        result = "Failing";
                        break;
                }
                return result;
            }
        }

        //Property-Type method - transforms grade to letter grade + returns result
        public string LetterGrade
        {
            get
            {
                string result;
                if (AverageGrade >= Math.Round(90F, 1))
                {
                    result = "A";
                }
                else if (AverageGrade >= Math.Round(80F, 1))
                {
                    result = "B";
                }
                else if (AverageGrade >= Math.Round(70F, 1))
                {
                    result = "C";
                }
                else if (AverageGrade >= Math.Round(60F, 1))
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }

        
    }
}
