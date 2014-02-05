using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TheEnterprise.Pages.Admin.PopUp.Question
{
    /// <summary>
    /// Interaction logic for UpdateQuestion.xaml
    /// </summary>
    public partial class UpdateQuestion : Window
    {

        private Model.DomainModel.Question question;
        private MainWindow mainWindow;
        public UpdateQuestion(Model.DomainModel.Question question,MainWindow mainWindow)
        {
            try
            {
                InitializeComponent();
                this.question = question;
                this.mainWindow = mainWindow;
                fillTextBoxWithQuestion();
                setComboBoxs();
            }
            catch (Exception ex)
            {
                ErrorLabel.Content = ex.Message;
            }
    
        }

        // Set ComboBox
        private void setComboBoxs()
        {
            try
            {
                setDefaultComboBox();
                addNoRequiredOption();
                addQuestionGroupsToComboBox();
                SetQuestionGroupIndexTo0();
                if (question.Required != null ) setRequired();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
         
        }
        // Default combobox
        private void setDefaultComboBox()
        {
            try
            {
                addNoDefaultOption();
                if (questionHasAnswers())
                {
                    addAnswersToDefault();
                    setDefaultAnswerIndex();
                }
                else
                {
                    DefaultComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
        }
        private void addNoDefaultOption()
        {
            DefaultComboBox.Items.Add("Ikke required");
        }
        private bool questionHasAnswers()
        {
            if (question.Answers.Count > 0)
            {
                return true;
            }
            return false;
        }
        private void addAnswersToDefault()
        {
            foreach (Model.DomainModel.Answer answer in question.Answers)
            {
                DefaultComboBox.Items.Add(answer.Title);
            }
        }
        private void setDefaultAnswerIndex()
        {
            if (question.Default != null)
            {
                int index = 0;
                foreach (string defaultTitle in DefaultComboBox.Items)
                {
                    if (defaultTitle == question.Default.Title)
                    {
                        break;
                    }
                    index++;
                }
                DefaultComboBox.SelectedIndex = index;
            }
            else
            {
                DefaultComboBox.SelectedIndex = 0;
            }

        }

        // Required
        private void addNoRequiredOption()
        {
            var noRequired = new Model.DomainModel.QuestionGroup()
            {
                Title = "Ikke required",
                Rank = 0
            };
            RequiredQuestionGroup.Items.Add(noRequired);
        }
        private void SetQuestionGroupIndexTo0()
        {
            if (question.Required == null)
            {
                RequiredQuestionGroup.SelectedIndex = 0;
            }
        }
        private void addQuestionGroupsToComboBox()
        {

            foreach (Model.DomainModel.QuestionGroup questionGroup in mainWindow.ModelFacade.Filter.QuestionGroups)
            {
                RequiredQuestionGroup.Items.Add(questionGroup);
            }
        }
        private void fillTextBoxWithQuestion()
        {
            QuestionRankTextBox.Text = question.Rank.ToString();
            QuestionTitelTextBox.Text = question.Title;
            QuestionPrintTitleTextBox.Text = question.PrintTitle;
        }
        // Set Required ComboBox
        private void setRequired()
        {
            try
            {
                setRequiredQuestionGroupIndex();
                setRequriedQuestion();
                setRequiredAnswer();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
        // Set questiongroup
        private void setRequiredQuestionGroupIndex()
        {
            int index = 0;
            foreach (Model.DomainModel.QuestionGroup questionGroup in RequiredQuestionGroup.Items)
            {
                if (question.Required.QuestionGroup.Id == questionGroup.Id)
                {
                    break;
                }
                index++;
            }
            RequiredQuestionGroup.SelectedIndex = index;
        }
        // Set Question
        private void setRequriedQuestion()
        {
            try
            {
                var selectedQuestionGroup = getSelectedQuestionGroup();
                RequiredQuestion.ItemsSource = selectedQuestionGroup.Questions;
                setRequiredquestionIndex();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Model.DomainModel.QuestionGroup getSelectedQuestionGroup()
        {
            Model.DomainModel.QuestionGroup selectedQuestionGroup = RequiredQuestionGroup.SelectedItem as Model.DomainModel.QuestionGroup;
            if (selectedQuestionGroup != null)
            {
                return selectedQuestionGroup;
            }
            throw new Exception("Ingen selected questiongroup i required");
        }
        private void setRequiredquestionIndex()
        {
            int index = 0;
            foreach (Model.DomainModel.Question question in RequiredQuestion.Items)
            {
                if (this.question.Required.Id == question.Id)
                {
                    break;
                }
                index++;
            }
            RequiredQuestion.SelectedIndex = index;
        }
        // set answer
        private void setRequiredAnswer()
        {
            try
            {
                var selectedQuestion = getSelectedQuestion();
                RequiredAnswer.ItemsSource = selectedQuestion.Answers;
                setRequiredAnswerIndex();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private Model.DomainModel.Question getSelectedQuestion()
        {
            Model.DomainModel.Question selectedQuestion = RequiredQuestion.SelectedItem as Model.DomainModel.Question;
            if (selectedQuestion != null)
            {
                return selectedQuestion;
            }
            throw new Exception("Intet valgt i Question Required");
        }
        private void setRequiredAnswerIndex()
        {
            int index = 0;
            foreach (Model.DomainModel.Answer answer in RequiredAnswer.Items)
            {
                if (question.Required.Value.Rank == answer.Rank)
                {
                    break;
                }
                index++;
            }
            RequiredAnswer.SelectedIndex = index;
        }

        // Save update
        private void saveUpdatedQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.TextBoxNotNull(QuestionTitelTextBox);
                Validate.TextBoxNotNull(QuestionRankTextBox);
                decimal rank = Helper.DecimalParse(QuestionRankTextBox.Text);
                Helper.QuestionRankAvailable(rank, question.QuestionGroup, this.question.Id);

                this.question.Title = QuestionTitelTextBox.Text;
                this.question.Rank = decimal.Parse(QuestionRankTextBox.Text);
                this.question.Default = DefaultComboBox.SelectedItem.ToString() != "Ikke required" ? question.Answers.SingleOrDefault(q => q.Title == DefaultComboBox.SelectedItem.ToString()) : null;
                this.question.Required = requiredQuestion();
                this.question.PrintTitle = QuestionPrintTitleTextBox.Text;
                Close();
            }
            catch (Exception ex)
            {
                ErrorLabel.Content = ex.Message;
            }
        }
        private Model.DomainModel.Question requiredQuestion()
        {
            // Tjek om alle 3 er sat
            Model.DomainModel.QuestionGroup selectedQuestionGroup = RequiredQuestionGroup.SelectedItem as Model.DomainModel.QuestionGroup;
            if (selectedQuestionGroup.Rank == 0)
            {
                return null;
            }
            if (RequiredQuestion.SelectedItem == null)
            {
                mainWindow.FeedBackLabel.Content = "Du skal vælge det spørgsmål du vil være required til";
                throw new Exception();
            }
            if (RequiredAnswer.SelectedItem == null)
            {
                mainWindow.FeedBackLabel.Content = "Du skal vælge den svarmulighed du vil være required til";
                throw new Exception();
            }

            // Opret required object og return :)
            var question = RequiredQuestion.SelectedItem as Model.DomainModel.Question;
            return question.CreateRequiredObject(RequiredAnswer.SelectedItem as Model.DomainModel.Answer);
        }

        // Selected Change Required
        private void RequiredQuestionGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.DomainModel.QuestionGroup selectedQuestionGroup = RequiredQuestionGroup.SelectedItem as Model.DomainModel.QuestionGroup;
            RequiredQuestion.ItemsSource = null;
            if (selectedQuestionGroup != null)
            {
                if (selectedQuestionGroup.Rank == 0)
                {
                    RequiredQuestion.ItemsSource = null;
                    RequiredAnswer.ItemsSource = null;
                }
                else
                {
                    RequiredQuestion.ItemsSource = selectedQuestionGroup.Questions;
                }

            }
        }         
        private void RequiredQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             Model.DomainModel.Question selectedQuestion = RequiredQuestion.SelectedItem as Model.DomainModel.Question;
            RequiredAnswer.ItemsSource = null;
            if (selectedQuestion != null)
            {
                RequiredAnswer.ItemsSource = selectedQuestion.Answers;

            }

        }
    }
}
