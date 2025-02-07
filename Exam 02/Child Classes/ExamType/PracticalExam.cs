using Exam_02.Base_Classes;
using Exam_02.Child_Classes.QuestionType;

namespace Exam_02.Child_Classes.ExamType
{
    internal class PracticalExam : Exam
    {
        #region Methods
        //override ShowExam() Method that was Abstracted in Exam Class
        public override void ShowExam()
        {
            Console.Clear();

            int[][] userAnswers = new int[Questions.GetQuestions().Length][];
            int questionIndex = 0;

            foreach (var question in Questions.GetQuestions())
            {
                if (question != null)
                {
                    Console.WriteLine($"Multiple Choices Question     Mark({question.Mark})");
                    Console.WriteLine(question.Body); // Display the body of the question

                    if (question.AnswerList != null && question.AnswerList.Length > 0)
                    {
                        Console.WriteLine("Choices:");
                        for (int i = 0; i < question.AnswerList.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {question.AnswerList[i].AnswerText}");
                        }

                        bool validAnswer = false;
                        int[] selectedChoices = new int[4];
                        string? input = string.Empty;
                        int count = 0;

                        do
                        {
                            Console.WriteLine("Please choose your answers:");
                            input = Console.ReadLine();
                            string[]? choiceStrings = input?.Split(',');

                            validAnswer = true;
                            foreach (string choice in choiceStrings)
                            {
                                if (int.TryParse(choice.Trim(), out int userChoice) && userChoice >= 1 && userChoice <= 4)
                                {
                                    selectedChoices[count++] = userChoice;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4");
                                    validAnswer = false;
                                    break;
                                }
                            }
                        } while (!validAnswer);

                        userAnswers[questionIndex] = selectedChoices;
                    }

                    Console.WriteLine();
                    Console.WriteLine("---------------------------------");

                    questionIndex++;
                }
            }

            DisplayCorrectAnswers(userAnswers);
        }

        // Method to display the correct answers
        private void DisplayCorrectAnswers(int[][] userAnswers)
        {
            Console.Clear();
            int questionIndex = 0;

            foreach (var question in Questions.GetQuestions())
            {
                    if (question?.RightAnswer != null)
                    {
                        Console.WriteLine($"Correct Answer: {Array.IndexOf(question.AnswerList, question.RightAnswer) + 1}. {question.RightAnswer.AnswerText}");
                    }
                    else
                    {
                        Console.WriteLine("No correct answer specified");
                    }

                    Console.WriteLine();
                    Console.WriteLine("---------------------------------");

                    questionIndex++;
                }
            }
        
        #endregion

    }
}
