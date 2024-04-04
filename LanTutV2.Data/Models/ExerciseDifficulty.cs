using System;
using System.Collections.Generic;
using LanTutorV2.Data.Interfaces;

namespace LanTutorV2.Data.Models
{
    //an exercise question may have a single difficulty allocated to it
    //how ever a single difficulty may be applied on multiple questions
    //ie easy may be allocated to more than one question
    public class ExerciseDifficulty : ILanTutorItem
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public ICollection<ExerciseQuestion> exerciseQuestions
        {
            get;
            set;
        }
    }
}