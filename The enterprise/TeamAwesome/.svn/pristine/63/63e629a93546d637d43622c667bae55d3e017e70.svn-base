using System.Collections.Generic;
using System.Linq;
using Model.Constroller;
using Model.DomainModel;
using DataAccess;
namespace Model
{
    public class ModelFacade
    {
        public Filter Filter;
        DataAccessFacade dataAccess = new DataAccessFacade();
        private FilterSearchController filterSearchController;

        public ModelFacade(FilterType filterType)
        {
            Filter = dataAccess.Load(filterType);
            init();
        }
        public ModelFacade(Filter filter)
        {
            this.Filter = filter;
            init();
        }

        public void init()
        {
            filterSearchController = new FilterSearchController(Filter);
        }

        public QuestionGroup FindQuestionGroup(int id)
        {
            return filterSearchController.FindQuestionGroup(id);
        }
        public Question FindQuestion(int questionGroupId, int questionId)
        {
            return filterSearchController.FindQuestion(questionGroupId, questionId);
        }
        public Question FindQuestion(QuestionGroup questionGroup, int questionId)
        {
            return filterSearchController.FindQuestion(questionGroup, questionId);
        }
        public Answer FindAnswer(int questionGroupId, int questionId, decimal answerId)
        {
            return filterSearchController.FindAnswer(questionGroupId, questionId, answerId);
        }
        public Answer FindAnswer(Question question, int answerId)
        {
            return filterSearchController.FindAnswer(question, answerId);
        }



        public void LoadFilter()
        {
           
        }
        public void LoadTemplate(FilterType filterType)
        {
            
        }
        public void Save()
        {
            dataAccess.Save(Filter);
        }
        public void Print()
        {
            dataAccess.CreatePrintFile(Filter);
        }

    }
}