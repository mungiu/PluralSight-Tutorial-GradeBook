using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSGrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test
{
    //IN GENERAL: Testing code 
    // Communication between all classes used inside the test, must be "public"
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputeLetterGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(20);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual("F", result.LetterGrade);
        }


        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(20);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(20, result.HighestGrade);
        }
        

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(20);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.LowestGrade);
        }
        

        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75); 

            GradeStatistics result = book.ComputeStatistics();
            //read method description mous over (double delta = acceptable deviation)
            Assert.AreEqual(85.16, result.AverageGrade, 0.01);
        }
    }
}
