using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LanTutV2.Data.Models
{
    public class QuestionDataHandler
    {
        private List<QuestionData> questionList;

        public QuestionDataHandler()
        {
            questionList = new List<QuestionData>();
        }

        public void ReadDataFromCSV(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length >= 10)
                    {
                        var question = new QuestionData(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9]);
                        questionList.Add(question);
                    }
                }
            }
        }



        public void AddQuestion(QuestionData question)
        {
            questionList.Add(question);
        }

        public void UpdateQuestion(int index, QuestionData updatedQuestion)
        {
            if (index >= 0 && index < questionList.Count)
            {
                questionList[index] = updatedQuestion;
            }
        }

        public void DeleteQuestion(int index)
        {
            if (index >= 0 && index < questionList.Count)
            {
                questionList.RemoveAt(index);
            }
        }

        public bool VerifyAnswer(int index, string userAnswer)
        {
            if (index >= 0 && index < questionList.Count)
            {
                return questionList[index].CorrectAnswer.Equals(userAnswer, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public List<QuestionData> GetQuestionsByLanguage(string language)
        {
            return questionList.Where(q => q.Language.Equals(language, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<QuestionData> GetQuestionsByCategory(string category)
        {
            return questionList.Where(q => q.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<QuestionData> GetQuestionsByRelation(string relation)
        {
            return questionList.Where(q => q.Relation.Equals(relation, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<QuestionData> GetQuestionsByDifficulty(string difficulty)
        {
            return questionList.Where(q => q.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase)).ToList();
        }



        public List<QuestionData> GetQuestionsByCriteria(string language, string category, string relation, string difficulty, int batchSize)
        {
            var result = questionList.Where(q =>
                q.Language.Equals(language, StringComparison.OrdinalIgnoreCase) &&
                q.Category.Equals(category, StringComparison.OrdinalIgnoreCase) &&
                q.Relation.Equals(relation, StringComparison.OrdinalIgnoreCase) &&
                q.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase)).ToList();

            return LazyLoadQuestions(result, batchSize);
        }

        private List<QuestionData> LazyLoadQuestions(List<QuestionData> questions, int batchSize)
        {
            if (batchSize <= 0 || batchSize >= questions.Count)
            {
                return questions;
            }

            return questions.Take(batchSize).ToList();
        }
    }
}
