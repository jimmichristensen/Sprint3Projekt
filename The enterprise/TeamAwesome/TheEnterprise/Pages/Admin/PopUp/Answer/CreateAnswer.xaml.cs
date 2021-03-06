﻿using System;
using System.Collections.Generic;
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

namespace TheEnterprise.Pages.Admin.PopUp.Answer
{
    /// <summary>
    /// Interaction logic for CreateAnswer.xaml
    /// </summary>

    public delegate void CreateAnswerdelegate(
        string title, decimal rank, string value, Model.DomainModel.Question question = null);

    public partial class CreateAnswer : Window
    {
        private MainWindow mainWindow;

        public event CreateAnswerdelegate CreatenewAnswer;

        public CreateAnswer(MainWindow mainWindow)
        {
            try
            {
                InitializeComponent();
                this.mainWindow = mainWindow;
                initComboBox();
                
            
            }
            catch (Exception ex)
            {

                ErrorLabel.Content = ex.Message;
            }
            
           
        }

     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.TextBoxNotNull(QuestionRankTextBox,"Rank");
                Validate.TextBoxNotNull(QuestionTitelTextBox,"Titel");
                Validate.TextBoxNotNull(QuestionValueTextBox,"Værdi");
                decimal parsed = Helper.DecimalParse(QuestionRankTextBox.Text);
                Model.DomainModel.Question required = requiredQuestion();
                CreatenewAnswer(QuestionTitelTextBox.Text, decimal.Parse(QuestionRankTextBox.Text), QuestionValueTextBox.Text, required);
                this.Close();
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
                ErrorLabel.Content = "Du skal vælge det spørgsmål du vil være required til";
                throw new Exception();
            }
            if (RequiredAnswer.SelectedItem == null)
            {
                ErrorLabel.Content = "Du skal vælge den svarmulighed du vil være required til";
                throw new Exception();
            }

            // Opret required object og return :)
            var question = RequiredQuestion.SelectedItem as Model.DomainModel.Question;
            return question.CreateRequiredObject(RequiredAnswer.SelectedItem as Model.DomainModel.Answer);
        }


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
        private void initComboBox()
        {
            var noRequired = new Model.DomainModel.QuestionGroup()
            {
                Title = "Ikke required",
                Rank = 0
            };
            RequiredQuestionGroup.Items.Add(noRequired);
            foreach (Model.DomainModel.QuestionGroup questionGroup in mainWindow.ModelFacade.Filter.QuestionGroups)
            {
                RequiredQuestionGroup.Items.Add(questionGroup);
            }

            RequiredQuestionGroup.SelectedIndex = 0;
        }

    }

}
