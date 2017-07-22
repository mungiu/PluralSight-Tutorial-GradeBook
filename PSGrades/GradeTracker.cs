using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSGrades
{
    //This is an "abstract" class
    //This means we can work with all the "methods" it has inside
    //By making sure that all other classes will inherit from this abstract class
    //That way classes that inherit from it can use all the methods inside of it
    public abstract class GradeTracker : IGradeTracker
    {
        //The below three lines of code satisfy the constraints of the "Interface"
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        //Because IGradeTacker inherits from IEnumerator, therefore IEnumerator method
        //must be listed in this abstract class (found by pressing F12 on IEnumerator)
        public abstract IEnumerator GetEnumerator();
        //By adding "get/set", method = "property type" and != "field type"
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                while (String.IsNullOrEmpty(value))
                {
                    GetBookName();
                    value = Console.ReadLine();
                }

                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
            }
        }
        private static void GetBookName()
        {
            try
            {
                throw new ArgumentException("GradeBook name cannot be null/empty.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        //Creating "public field" using "public event" type
        //"public field" can now be assigned smth.
        //_name = "private field" for holding original string value (Name)
        public event NameChangedDelegate NameChanged;
        protected string _name;
    }
}
