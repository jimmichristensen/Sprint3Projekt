using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Model.DomainModel;
using Model.Exceptions;
using Model.FilterSearch;

namespace Model.Constroller
{
    public class FilterSearchController
    {
        public FilterLinqSearch Search;

        public FilterSearchController(Filter filter)
        {
            Search = new FilterLinqSearch(filter);
        }

        // Search in filter
        public QuestionGroup FindQuestionGroup(int id)
        {
            try
            {
                return Search.FindQuestionGroup(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public Question FindQuestion(int questionGroupId, int questionId)
        {
            try
            {
                return Search.FindQuestion(questionGroupId,questionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Question FindQuestion(QuestionGroup questionGroup, int questionId)
        {
            try
            {
                return Search.FindQuestion(questionGroup, questionId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Answer FindAnswer(int questionGroupId, int questionId, decimal answerId)
        {
            try
            {
                return Search.FindAnswer(questionGroupId, questionId, answerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Answer FindAnswer(Question question, int answerId)
        {
            try
            {
                return Search.FindAnswer(question, answerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}