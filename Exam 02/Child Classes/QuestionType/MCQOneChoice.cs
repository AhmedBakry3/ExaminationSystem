using Exam_02.Assoicated_Classes;
using Exam_02.Base_Classes;

namespace Exam_02.Child_Classes.QuestionType
{
    internal class MCQOneChoice : Question
    {
        #region Methods
        //override Display() Method that was Abstracted in Question Class
        public override void Display()
        {
            string? input;
            int result;
            bool isParsed;

            Header = "Choose One Answer Question";
            Console.WriteLine(Header); // Header of the Question

            do
            {
                Console.WriteLine("Please Enter The Body Of Question:");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please enter a valid name.");
                }
                else
                {
                    Body = input; // Body of the Question
                }

            } while (string.IsNullOrWhiteSpace(input));

            do
            {
                Console.WriteLine($"Please Enter The Mark Of Question:");
                isParsed = int.TryParse(Console.ReadLine(), out result);
                if (!isParsed)
                {
                    Console.WriteLine("Please Enter a Valid Numeric Number");
                }
                else
                {
                    Mark = result;  // Mark of the Question
                }

            } while (!isParsed);

            Answers[] choices = new Answers[4];
            Console.WriteLine("The Choices Of Question:");

            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.Write($"Please Enter The Choice Number {i + 1}: ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty. Please enter a valid choice.");
                    }
                    else
                    {
                        choices[i] = new Answers() { AnswerId = i + 1, AnswerText = input }; 
                    }

                } while (string.IsNullOrWhiteSpace(input));
            }

            string? correctAnswerInput;
            do
            {
                Console.WriteLine("Please Specify The Right Choice Of Question:");
                correctAnswerInput = Console.ReadLine();

                if (int.TryParse(correctAnswerInput, out result) && result >= 1 && result <= 4)
                {
                    RightAnswer = choices[result - 1]; 
                }
                else
                {
                    Console.WriteLine("Invalid input. Please specify a number between 1 and 4");
                }

            } while (RightAnswer == null);

            AnswerList = choices;
            Console.Clear();
        }
        #endregion
    }
}
