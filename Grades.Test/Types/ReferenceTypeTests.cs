using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSGrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Test.Types
{
    [TestClass]
    public class TypeTests
    {
        //Array - reference type, assrting = behvaes as reference type
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        //String = reference type,assertion
        [TestMethod]
        public void UppercaseString()
        {
            string name = "scott";
            //if "name" is not assigned, "name.ToUpper();" constructs a new string
            //even though String is a ReferenceType, i behvase like ValueType
            name = name.ToUpper();

            Assert.AreEqual("SCOTT", name);
        }


        //String = ReferenceType, testing assertion
        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            //if "date" is not assigned, "date.AddDays(1);" constructs a new date time
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }


        // Asserting if ValueType passes by value
        // + "46" from inside "x" is copied into "number"
        // but since this is a copy, the changes are only visible inside the code which
        // is "IncrementANumber"
        // "ref" makes sure all changes are adopted to the "variable" we reference
        // "out" works the same as "red" only is expect a certain output
        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementANumber(ref x);
            Assert.AreEqual(47, x);
        }
        
        private void IncrementANumber(ref int number)
        {
            number += 1;
        }


        //Asserting ReferenceType according to value
        // + Creating a method for assigning a string value into a "reference type"
        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(ref book2);
            Assert.AreEqual("A GradeBook", book2.Name);
        }
        
        private void GiveBookAName(ref GradeBook book)
        {
            book = new GradeBook();
            book.Name = "A GradeBook";
        }


        //creating a bool variable which will hold the "true" or "false" result
        // + Assert the bool variable for "true" or "false"
        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";
            
            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }


        //Here we use a "value type" the value is stored directly inside the variable
        //there are not pointers
        //Asserting x1 == x2 after the above operations
        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;
            x1 = 4;

            Assert.AreNotEqual(x1, x2);
        }


        //Testing what we think should happen when certain things are changed
        //Here the value inside the variable is a pointer since we use a "reference type"
        //changing the variable in one "reference type"
        //makes it visible in all other "reference types" that point at same variable
        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;
            
            g1 = new GradeBook();
            g1.Name = "Scott's grade book";
            Assert.AreNotEqual(g1.Name, g2.Name);
        }
    }
}
