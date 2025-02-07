namespace Exam_02.Assoicated_Classes
{
    internal class Answers   
    {
        #region Properties
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }
        #endregion

        #region Constructors
        //parameterized constructor
        public Answers(int answerId, string? answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        //Empty ParameterLess Concstructor
        public Answers() { }    
        #endregion

        #region Methods
        //override The toString() Method
        public override string ToString()
        {
            return $"AnswerId : {AnswerId}, AnswerText : {AnswerText}";
        }
        #endregion
    }
}
