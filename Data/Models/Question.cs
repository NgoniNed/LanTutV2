namespace LanTutV2.Data.Models
{
    //store the question with answer
    /*

    *   stores number of questions affiliated with this exercise
        checks if question answer is correct
        question with answer and check result
    */
    public class Question
    {
        public int QID
        {
            get;
            private set;
        }

        public string _question
        {
            get;
            private set;
        }

        public string[] _answers
        {
            get;
            private set;
        }
        
        private string _correct;
        private double _timespent=0;
        private int _attempts=0;
        private int _failedAttempts=0;
        private int _correctAttempts=0;
        private bool _isCorrect =false;

        public Question(int _qid,string _ques, string[] _answ,string _corrt,int _lattempts,int _fattempts,int _cattempts)
        {
            this.QID = _qid;
            this._question = _ques;
            this._answers = _answ;
            this._correct = _corrt;
            this._attempts = _lattempts;
            this._failedAttempts = _fattempts;
            this._correctAttempts = _cattempts;
        }

        public int GetAttempts
        {
            get
            {
                return _attempts;
            }
        }

        public int GetCorrectAttempts
        {
            get
            {
                return _correctAttempts;
            }
        }

        public int GetFailedAttempts
        {
            get
            {
                return _failedAttempts;
            }
        }

        public void UpdateTimeSpent(double _startTime,double _endTime)
        {
            //ensure times are in correct order
            if(_startTime > _endTime && (_startTime ==_endTime))
            {
                _timespent = _endTime - _startTime;
            }
            else
            {
                _timespent = _startTime - _endTime;
            }

        }

        public void CheckAnswer(string _luserResponse)
        {
            //check if response is part of answer options
            if(_answers.Contains(_luserResponse))
            {
                //check if user response is correct
                if(_correct == _luserResponse)
                {
                    _isCorrect = true;
                }
                else
                {
                    _isCorrect = false;
                }
            }
        }

        public void UpdateAttempts()
        {
            //increase the number of attempts
            _attempts++;
            //check to see if user got the answer correct
            if(_isCorrect)
            {
                _correctAttempts++;
            }
            else
            {
                _failedAttempts++;
            }
        }
    }
}