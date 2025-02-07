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
            int totalMarks = 0, obtainedMarks = 0;
            int questionIndex = 0;
            string? input = string.Empty;

            foreach (var question in Questions.GetQuestions())
            {
                if (question != null)
                {
                    Console.WriteLine($"Question {questionIndex + 1} - Mark({question.Mark})");
                    Console.WriteLine(question.Body);
                    totalMarks += question.Mark;

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

                                // Check if the selected answer is correct and add to obtained marks
                                if (question.AnswerList[userChoice - 1] == question.RightAnswer)
                                {
                                    obtainedMarks += question.Mark;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            }
                        } while (!validAnswer);
                    }
                    else if (question is TFQuestion tfQuestion)
                    {
                        bool validAnswer = false;
                        do
                        {
                            Console.WriteLine("Please choose your answer (T/F):");
                            input = Console.ReadLine()?.ToUpper()?.Trim(); // To handle case insensitivity

                            if (input == "T" || input == "F")
                            {
                                userAnswers[questionIndex] = input;
                                validAnswer = true;

                                // Check if the answer is correct (case insensitive)
                                if (input == tfQuestion.RightAnswer?.AnswerText?.ToUpper())
                                {
                                    obtainedMarks += question.Mark;
                                }
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

            // Display the correct answers and the final grade after all questions are answered
            DisplayCorrectAnswers(userAnswers);
            DisplayFinalGrade(totalMarks, obtainedMarks);
        }

        // Method to display the correct answers
        private void DisplayCorrectAnswers(string[] userAnswers)
        {
            Console.Clear();
            
            int questionIndex = 0;

            foreach (var question in Questions.GetQuestions())
            {
                if (question != null)
                {
                    Console.WriteLine($"Question {questionIndex + 1} - Mark({question.Mark})");
                    Console.WriteLine(question.Body); // Display the body of the question

                    // Display the user's selected answer for each question
                    if (question is MCQOneChoice)
                    {
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
                            Console.WriteLine($"Correct Answer: {Array.IndexOf(question.AnswerList, question.RightAnswer) + 1}. {question.RightAnswer.AnswerText}");
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

        // Method to display the final grade
        private void DisplayFinalGrade(int totalMarks, int obtainedMarks)
        {
            Console.WriteLine($"Your Total Exam Grade: {obtainedMarks} from {totalMarks}");
        }

        #endregion
    }
}
