using Exam_02.Base_Classes;

namespace Exam_02.Associated_Classes
{
    internal class QuestionList
    {
        #region Attributes
        private Question[] questions;
        private int count;
        #endregion

         #region Constructors
        public QuestionList(int initialSize = 10)
        {
            questions = new Question[initialSize];
            count = 0;
        }
         #endregion

         #region Methods
        // Adds a new question to the araay. If the list is full, it resizes the array.
        public void AddQuestion(Question question)
        {
            if (question != null)
            {
                if (count >= questions.Length)
                {
                    Array.Resize(ref questions, questions.Length * 2);
                }
                questions[count++] = question;
            }
            else
            {
                Console.WriteLine("Cannot add a null question.");
            }
        }

        // Get all questions 
        public Question[] GetQuestions()
        {
            Question[] result = new Question[count];
            Array.Copy(questions, result, count);
            return result;
        }

        // Display all questions
        public void DisplayQuestions()
        {
            if (count == 0)
            {
                Console.WriteLine("No questions available.");
                return;
            }

            Console.WriteLine("Exam Questions:");
            for (int i = 0; i < count; i++)
            {
                if (questions[i] != null) 
                {
                    Console.WriteLine($"Question {i + 1}:");
                    questions[i].Display();
                    Console.WriteLine();
                }
            }
        }
        #endregion

    }
}
