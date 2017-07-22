using System.Collections;
using System.IO;

namespace PSGrades
{
    //Making our own interface inherit from a "base" interface
    internal interface IGradeTracker : IEnumerable
    {
        //Inside of an interface we can not use an acces modifier
        //E.G. Private/Protected/Public
        //The methods below are implicity "public" and "virtual", because they are part of an interface
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
        string Name { get; set; }
        event NameChangedDelegate NameChanged;
    }
}