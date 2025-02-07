using Exam_02.Base_Classes;
using Exam_02.Child_Classes.QuestionType;

namespace Exam_02.Child_Classes.ExamType
{
    internal class FinalExam : Exam
    {
        #region Methods
        //override ShowExam() Method that was Abstracted in Exam Class
        public override void ShowExam()
        {
            Console.Clear();

            string[] userAnswers = new string[Questions.GetQuestions().Length];
            int questionIndex = 0;
            string? input = string.Empty;

            foreach (var question in Questions.GetQuestions())
            {
                if (question != null)
                {
                    Console.WriteLine($"Question {questionIndex + 1} - Mark({question.Mark})");
                    Console.WriteLine(question.Body); // Display the body of the question

                    if (question is MCQOneChoice)
                    {
                        Console.WriteLine("Choices:");
                        for (int i = 0; i < question.AnswerList?.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {question.AnswerList[i].AnswerText}");
                        }

                        bool validAnswer = false;
                        do
                        {
                            Console.WriteLine("Please choose your answer:");
                            input = Console.ReadLine();

                            if (int.TryParse(input?.Trim(), out int userChoice) && userChoice >= 1 && userChoice <= 4)
                            {
                                userAnswers[questionIndex] = input.Trim(); 
                                validAnswer = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            }
                        } while (!validAnswer);
                    }
                    else if (question is TFQuestion)
                    {
                        bool validAnswer = false;
                        do
                        {
                            Console.WriteLine("Please choose your answer (T/F):");
                            input = Console.ReadLine()?.ToUpper();

                            if (input == "T" || input == "F")
                            {
                                userAnswers[questionIndex] = input; 
                                validAnswer = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Please enter 'T' for True or 'F' for False.");
                            }

                        } while (!validAnswer);
                    }

                    Console.WriteLine();
                    Console.WriteLine("---------------------------------");

                    questionIndex++;
                }
            }

            DisplayCorrectAnswers(userAnswers);
        }

        // Method to display the correct answers
        private void DisplayCorrectAnswers(string[] userAnswers)
        {
            Console.Clear();
            Console.WriteLine("Your Answers:");

            int questionIndex = 0;

            foreach (var question in Questions.GetQuestions())
            {
                if (question != null)
                {
                    Console.WriteLine($"Question {questionIndex + 1} - Mark({question.Mark})");
                    Console.WriteLine(question.Body); // Display the body of the question

                    if (question is MCQOneChoice)
                    {
                        for (int i = 0; i < question?.AnswerList?.Length; i++)
                        {
                            Console.Write($"{i + 1}. {question.AnswerList[i].AnswerText}         ");
                        }

                        Console.WriteLine("\nYour Selected Answer:");
                        Console.WriteLine(userAnswers[questionIndex]);
                    }
                    else if (question is TFQuestion)
                    {
                        Console.WriteLine("\nYour Selected Answer:");
                        Console.WriteLine(userAnswers[questionIndex] == "T" ? "True" : "False");
                    }

                    // Display the correct answer for both types of questions
                    if (question?.RightAnswer != null)
                    {
                        if (question is MCQOneChoice)
                        {
                            Console.WriteLine($"Correct Answer: {Array.IndexOf(question.AnswerList , question.RightAnswer) + 1}. {question.RightAnswer.AnswerText}");
                        }
                        else if (question is TFQuestion)
                        {
                            Console.WriteLine($"Correct Answer: {question.RightAnswer.AnswerText}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No correct answer specified.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("---------------------------------");

                    questionIndex++;
                }
            }
        }

        #endregion
    }
}
