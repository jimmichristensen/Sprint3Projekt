using System;
using System.Collections.Generic;
using System.Xml.Schema;
using DataAccess;

namespace Model.DomainModel
{
    [Serializable()]
    public class Question
    {
        public int Id { get; set; }
        public Question Required { get; set; }
        public Answer Default { get; set; }
        public Answer Value { get; set; }
        public List<Answer> Answers = new List<Answer>();
        public string Title { get; set; }
        public string PrintTitle { get; set; }
        public decimal Rank { get; set; }
        public QuestionGroup QuestionGroup { get; set; }

        public Question()
        {
            Id = AI.New("Question");
        }

        public void Validate()
        {
            
        }

        public bool IsActive(Filter filter)
        {
            if (Required != null)
            {
                if (filter.FindQuestion(this.Required,this.QuestionGroup).Value != Required.Value)
                {
                    return false;
                }
            }
            return true;
        }

        public Question CreateRequiredObject(Answer value = null)
        {
            return new Question()
            {
                Value = ( value == null ? this.Value : value ),
                Title = this.Title,
                Id = this.Id,
                QuestionGroup = this.QuestionGroup
            };
        }

        public override string ToString()
        {
            return Title;
        }
    }
}