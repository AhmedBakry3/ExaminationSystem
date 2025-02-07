using Exam_02.Assoicated_Classes;

namespace Exam_02.Base_Classes
{
    internal abstract class Question  
    {
        #region Properties
        public string? Header { get; set; }
        public string? Body { get; set; }
        public double Mark { get; set; }
        public Answers[]? AnswerList { get; set; }
        public Answers? RightAnswer { get; set; }
        #endregion

        #region Constructor
        //parameterized constructor
        public Question(string? header, string? body, double mark, Answers[]? answerList, Answers? rightanswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightanswer;
        }

        //Empty ParameterLess Concstructor
        public Question() { }


        #endregion

        #region Methods
        //override The toString() Method
        public override string ToString()
        {
            return $"Header : {Header}, Body : {Body}, Mark : {Mark}";
        }

        //Abstracted Display() Method ( MCQMultipleChocies , TFQuestion , MCQOnceChoice Classes will implement this Method)
        public abstract void Display();

        #endregion
    }
}
