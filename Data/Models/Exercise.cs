using LanTutV2.Data.Interface;

namespace LanTutV2.Data.Models
{
    public class Exercise : ILanTutExercise
    {
        private List<QuestionData> _questionSet
        {
            get;
            set;
        }

        private int _questionIndex;

        public Exercise(List<QuestionData> _lqset)
        {
            _questionSet = _lqset;
            _questionIndex = 0;
        }

        public int GetQuestionSetCount
        {
            get
            {
                return _questionSet.Count;
            }
        }
        //Gets the current question and moves question index to the next point
        public Question GetQuestion()
        {
            //keep the index from reaching end of question set
            if(_questionIndex >= GetQuestionSetCount)
            {
                _questionIndex = 0;
            }
            return Question.ConvertFromQuestionData(_questionSet[_questionIndex++]);
        }

        public int ExerciseID
        {
            get;
            set;
        }
    }
}