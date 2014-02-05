using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.DomainModel;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelFacade modelFacede = new ModelFacade(FilterType.TestTemplate);
            QuestionGroup qg = modelFacede.FindQuestionGroup(1);
            qg.Questions.Add(new Question()
            {
                Rank = 3,
                Title = "dette er et spørgsmål"
            });

            modelFacede.Filter.QuestionGroups.Single(q => q.Title == "ehe");

            modelFacede.Save();    
            Console.ReadLine();
        }

        static void testAnswerRequired(ModelFacade modelFacede)
        {
            Console.WriteLine("/// Testing af required answers");

            // Finder spørgsmål 1
            Question question1 = modelFacede.FindQuestion(1, 1);
            // Find spørgsmål2
            Question question2 = modelFacede.FindQuestion(1, 2);
            // Find svarmulighed 2 i spørgsmål 2 / Fordi den er required til spørgsmål 1 :)
            Answer answer2 = modelFacede.FindAnswer(question2, 2);

            // Sætter spørgsmål 2 til svarmulighed = som spørgsmål 2 ikke er required til
            question1.Value = modelFacede.FindAnswer(question1, 2);

            // Tester om svarmuligheden skal være aktiv ud fra de valgte svar i filtret
            if (answer2.IsActive(modelFacede.Filter))
            {
                Console.WriteLine("Rødt lys");
            }
            else
            {
                // 
                Console.WriteLine("Grøn lys");
            }
   
            // Sætter spørgsmål 1 til svarmulighed = som spørgsmål 2 er required til
            question1.Value = modelFacede.FindAnswer(question1, 1);

            // Tester igen om svarmuligheden nu er aktiv
            if (answer2.IsActive(modelFacede.Filter))
            {
                Console.WriteLine("Grøn lys");
            }
            else
            {
                Console.WriteLine("Rødt lys");
            }

        }
        static void testQuestionRequired(ModelFacade modelFacede)
        {
            Console.WriteLine("/// Testing af required Question");
            modelFacede.FindQuestion(1, 1).Value = modelFacede.FindAnswer(1, 1, 2);

            // Question 2
            Question question2 = modelFacede.FindQuestion(1, 2);
            question2.Required = modelFacede.FindQuestion(1, 1).CreateRequiredObject(modelFacede.FindAnswer(1, 1, 1));

            // Er spørgsmål 1 aktiv
            if (question2.IsActive(modelFacede.Filter))
            {
                Console.WriteLine("Rødt lys");
            }
            else
            {
                Console.WriteLine("Grøn lys");
              
            }

            modelFacede.FindQuestion(1, 1).Value = modelFacede.FindAnswer(1, 1, 1);

            // Er spørgsmål 2 aktiv
            if (question2.IsActive(modelFacede.Filter))
            {
                Console.WriteLine("Grøn lys");
            }
            else
            {
                Console.WriteLine("Rødt lys");
            }

        }
        static Filter getTestFilter()
        {
            Filter filter = new Filter();
            filter.Type = FilterType.TestTemplate;
            // Opret spørgsmåls gruppe
            QuestionGroup questionGroup = new QuestionGroup();
            questionGroup.Rank = 1;
            filter.QuestionGroups.Add(questionGroup);

            // Find en questionGroup
            QuestionGroup findedQuestionGroup = filter.QuestionGroups.Single(qg => qg.Rank == 1);

            // Question 1
            Question filterType = new Question();
            filterType.Rank = 1;
            filterType.Title = "Filter Type?";

            Answer filterTypeAnswer1 = new Answer();
            filterTypeAnswer1.Rank = 1;
            filterTypeAnswer1.Title = "4TR Filter";
            filterTypeAnswer1.Value = "4TR";

            Answer filterTypeAnswer2 = new Answer();
            filterTypeAnswer2.Rank = 2;
            filterTypeAnswer2.Title = "5TR Filter";
            filterTypeAnswer2.Value = "5TR";


            filterType.Answers.Add(filterTypeAnswer1);
            filterType.Answers.Add(filterTypeAnswer2);

            findedQuestionGroup.Questions.Add(filterType);

            // Question 2
            Question filterCoor = new Question();
            filterCoor.Rank = 2;
            filterCoor.Title = "Filter Farve?";

            Answer filterCoorAnswer1 = new Answer();
            filterCoorAnswer1.Rank = 1;
            filterCoorAnswer1.Title = "Blå";
            filterCoorAnswer1.Value = "blue";

            Answer filterCoorAnswer2 = new Answer();
            filterCoorAnswer2.Rank = 2;
            filterCoorAnswer2.Title = "Grøn";
            filterCoorAnswer2.Value = "green";
            filterCoorAnswer2.Required = filterType.CreateRequiredObject(filterTypeAnswer1);

            filterCoor.Answers.Add(filterCoorAnswer1);
            filterCoor.Answers.Add(filterCoorAnswer2);

            findedQuestionGroup.Questions.Add(filterCoor);
            return filter;
        }
    }
}
