using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();
            Console.WriteLine($"Please enter a GradeBook name.");
            
            //after subscrib. "method"(ONC) to "event"(NC) can "method" react to "event"
            book.NameChanged += OnNameChanged;
            book.Name = Console.ReadLine();

            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static IGradeTracker CreateGradeBook()
        {
            // bacause TAGB has already inherited from GB
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult($"Your grade is {stats.Description}", stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            //StreamWriting data to .txt file >>> closing the stream
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                //Calling "WriteGrades" which Writes grades to a destination of choice
                //Console.Out - a "parameter" that allows us to change destination
                //Console.Out - static member of the console class
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Changing GradeBook name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }
    }
}
