using Exam_02.Assoicated_Classes;
using Exam_02.Child_Classes.QuestionType;
using System.Diagnostics;

namespace Exam_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating Object from Subject to start the Exam
            Subject subject = new Subject(1, "C#");
            subject.CreateExam();
            Console.Clear();
            Console.Write("Do You Want To Start the Exam (Y/N): ");


            //Call Exam.ShowExam() Method ( since ShowExam() in exam is abstracted , it will be either final or practical Showexam() depend on Choice in CreateExam() Method)
            if (char.ToUpper(Console.ReadLine()[0]) == 'Y')
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                subject?.Exam?.ShowExam();
                Console.WriteLine($"The Elasped Time = {stopwatch.Elapsed}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'Y' or 'y'");
            }

        }
    }
}
