using System;
using System.Linq;
using Model.DomainModel;
using Model.Exceptions;

namespace Model.FilterSearch
{
    public class FilterLinqSearch
    {
        public Filter Filter;

        public FilterLinqSearch(Filter filter)
        {
            this.Filter = filter;
        }

        // Search in filter
        public QuestionGroup FindQuestionGroup(int id)
        {
            QuestionGroup questionGroup = Filter.QuestionGroups.SingleOrDefault(q => q.Id == id);
            if (questionGroup != null)
            {
                return questionGroup;
            }

            throw new SearchException("Fejl i FilterLinqSearch:FindQuestionGroup. Kunne ikke finde QuestionGroup med Id'et = " + id);

        }

        public Question FindQuestion(int questionGroupId, int questionId)
        {
            Question foundQuestion = FindQuestionGroup(questionGroupId).Questions.SingleOrDefault(q => q.Id == questionId);
            if (foundQuestion != null)
            {
                return foundQuestion;
            }
            throw new SearchException("Fejl i FilterLinqSearch:FindQuestion. Kunne ikke finde question i questionGroup id: "+questionGroupId+" med id "+questionId);
        }
        public Question FindQuestion(QuestionGroup questionGroup, int questionId)
        {
            Question foundQuestion = questionGroup.Questions.SingleOrDefault(q => q.Id == questionId);
            if (foundQuestion != null)
            {
                return foundQuestion;
            }
            throw new SearchException("Fejl i FilterLinqSearch:FindQuestion. Kunne ikke finde question i questionGroup id: " + questionGroup.Title + " med id " + questionId);
        }
        public Answer FindAnswer(int questionGroupId, int questionId, decimal answerId)
        {
            Answer foundAnswer = FindQuestion(questionGroupId, questionId).Answers.Single(a => a.Id == answerId);
            if (foundAnswer != null)
            {
                return foundAnswer;
            }
            throw new SearchException("Fejl i FilterLinqSearch:FindAnswer. Kunne ikke finde Answer "+answerId+"  i Questiongroup id : "+questionGroupId+": på spørgsmål id "+questionId);
        }
        public Answer FindAnswer(Question question, int answerId)
        {
            Answer foundAnswer = question.Answers.Single(a => a.Id == answerId);
            if (foundAnswer != null)
            {
                return foundAnswer;
            }
            throw new SearchException("Fejl i FilterLinqSearch:FindAnswer.Kunne ikke finde Answer id "+answerId+" i question "+question.Title);
        }
    }
}