using Exam_02.Associated_Classes;
using Exam_02.Base_Classes;
using Exam_02.Child_Classes.ExamType;
using Exam_02.Child_Classes.QuestionType;
using Exam_02.Enums;


namespace Exam_02.Assoicated_Classes
{
    internal class Subject
    {
        #region Properties
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Exam? Exam { get; set; }
        public ExamType examType { get; set; } //ExamType Enum
        public QuestionType questionType { get; set; } //QuestionType Enum
        #endregion

        #region Constructors
        public Subject(int subjectId, string? subjectName )
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        #endregion

        #region Methods
        //override The toString() Method
        public override string ToString()
        {
            return $"SubjectId : {SubjectId}, SubjectName : {SubjectName}";
        }

        //CreateExam() Method to Create the exam
        public void CreateExam()
        {
            int result;
            bool isParsed;
            int count = 0;

            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create (1 For Practical and 2 for Final): ");
                isParsed = int.TryParse(Console.ReadLine(), out result); 

                if (!isParsed || !Enum.IsDefined(typeof(ExamType), result))
                {
                    Console.WriteLine("Please Enter a Valid Numeric Number (1 for Practical or 2 for Final)");
                }
                else
                {
                    examType = (ExamType)result;
                }

            } while (!isParsed || !Enum.IsDefined(typeof(ExamType), result));


            do
            {
                Console.Write($"Please Enter The Time Of Exam In Minutes: ");
                isParsed = int.TryParse(Console.ReadLine(), out result);
                if (!isParsed)
                {
                    Console.WriteLine("Please Enter a Valid Numeric Number");
                }

            } while (!isParsed);

            do
            {
                Console.Write("Please Enter The Number Of Question You Wanted To Create: ");
                isParsed = int.TryParse(Console.ReadLine(), out result);
                if (!isParsed)
                {
                    Console.WriteLine("Please Enter a Valid Numeric Number");
                }
                else
                {
                    count = result;
                }

            } while (!isParsed);

            Console.Clear();

            if (examType == ExamType.PracticalExam)
            {
                Exam = new PracticalExam(); // Assign the exam
                Exam.Questions = new QuestionList(); 

                Console.WriteLine("Practical Exam only allows Multiple MCQ");

                for (int i = 0; i < count; i++)
                {
                    Console.Clear();
                    Console.WriteLine($"Question {i + 1} of {count}:");
                    MCQMultipleChocies mCQMultipleChoices = new MCQMultipleChocies();
                    mCQMultipleChoices.Display(); 

                    Exam.Questions.AddQuestion(mCQMultipleChoices);

                }
            }
            else if (examType == ExamType.FinalExam)
            {
                Exam = new FinalExam(); // Assign the exam

                do
                {
                    for (int i = 0; i < count; i++) 
                    {
                        do
                        {
                            Console.Write($"Please Choose The Type Of Question Number({i + 1}) (1 For True OR False || 2 For MCQ): ");
                            isParsed = int.TryParse(Console.ReadLine(), out result);

                            if (!isParsed || !Enum.IsDefined(typeof(QuestionType), result))
                            {
                                Console.WriteLine("Please Enter a Valid Numeric Number (1 For TrueOrFalse or 2 For MCQ)");
                            }
                            else
                            {
                                questionType = (QuestionType)result; 
                            }

                        } while (!isParsed || !Enum.IsDefined(typeof(QuestionType), result));

                        Console.Clear();

                        Console.WriteLine($"Question {i + 1} of {count}:");

                        if (questionType == QuestionType.TrueFalse)
                        {
                            TFQuestion tFQuestion = new TFQuestion();
                            tFQuestion.Display();
                            Exam.Questions.AddQuestion(tFQuestion);

                        }
                        else if (questionType == QuestionType.MCQOneChoice)
                        {
                            MCQOneChoice mCQOneChoice = new MCQOneChoice();
                            mCQOneChoice.Display();
                            Exam.Questions.AddQuestion(mCQOneChoice);

                        }

                    }
                } while (false); 
           

            }
        }
        #endregion

    }
}
