using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccess;

namespace Model.DomainModel
{
    [Serializable()]
    public class QuestionGroup
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public decimal Rank { get; set; }
        public BindingList<Question> Questions = new BindingList<Question>();
        public string Title { get; set; }

        public QuestionGroup()
        {
            Id = AI.New("QuestionGroup");
        }

        public override string ToString()
        {
            return Title;
        }
    }
}