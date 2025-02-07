using Exam_02.Associated_Classes;
using Exam_02.Assoicated_Classes;


namespace Exam_02.Base_Classes
{
    internal abstract class Exam 
    {
        #region Properties
        public int ExamTime {  get; set; }
        public int NumberOfQuestions {  get; set; }
        public Subject? Subject { get; set; }
        public QuestionList Questions { get; set; }

        #endregion

        #region Constructors


        //parameterized constructor
        public Exam(int examTime, int numberOfQuestions)
        {
            ExamTime = examTime;
            NumberOfQuestions = numberOfQuestions;
        }

        // Parameterless constructor
        public Exam()
        {
            Questions = new QuestionList(); 
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"ExamTime : {ExamTime}, NumberOfQuestions : {NumberOfQuestions}";
        }

        //ShowExam Method To show the exam (FinalExam And PracticalExam Classes will implement this Method)
        public abstract void ShowExam();
       
        #endregion
    }
}
