using Exam_02.Assoicated_Classes;
using Exam_02.Base_Classes;

namespace Exam_02.Child_Classes.QuestionType
{
    internal class TFQuestion : Question
    {
        #region Methods
        //override Display() Method that was Abstracted in Question Class
        public override void Display()
        {
            string? input;
            int result;
            bool isParsed;

            Header = "True | False Question";
            Console.WriteLine(Header); // Header Of the Question 

            do
            {
                Console.WriteLine("Please Enter The Body Of Question:");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input cannot be empty. Please enter a valid question.");
                }
                else
                {
                    Body = input; //Body Of The Question
                }
            } while (string.IsNullOrWhiteSpace(input));

            do
            {
                Console.WriteLine("Please Enter The Mark Of Question:");
                isParsed = int.TryParse(Console.ReadLine(), out result);
                if (!isParsed)
                {
                    Console.WriteLine("Please Enter a Valid Numeric Number");
                }
                else
                {
                    Mark = result; //Mark Of The Question
                }
            } while (!isParsed);

            Answers[] choices = new Answers[2];
            choices[0] = new Answers() { AnswerId = 1, AnswerText = "True" };
            choices[1] = new Answers() { AnswerId = 2, AnswerText = "False" };
            AnswerList = choices;

            string? correctAnswerInput;
            Answers correctAnswer = null;
            do
            {
                Console.WriteLine("Please Specify The Correct Choice Of Question (enter 1 for True or 2 for False):");
                correctAnswerInput = Console.ReadLine();

                if (int.TryParse(correctAnswerInput, out result) && result >= 1 && result <= 2)
                {
                    correctAnswer = choices[result - 1];
                    RightAnswer = correctAnswer; // Assign the correct answer to RightAnswer
                }
                else
                {
                    Console.WriteLine("Invalid input. Please specify a number (1 for True, 2 for False)");
                }
            } while (correctAnswer == null);

            Console.Clear();
        }
        #endregion
    }
}
