using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Model.DomainModel;
using TheEnterprise.Pages.Admin.PopUp.Answer;

namespace TheEnterprise.Pages.Admin
{
    /// <summary>
    /// Interaction logic for AnswerView.xaml
    /// </summary>
   
    
    
    public partial class AnswerView : UserControl
    {
        private MainWindow mainWindow;
        private QuestionGroup questionGroup;
        private Question question;
        

        public AnswerView(MainWindow mainWindow,QuestionGroup questionGroup, Question question)
        {
            InitializeComponent();
            //AnimationClass.fadeOut(viewGrid, 0); AnimationClass.fadeIn(viewGrid, MainWindow.AnimationSpeed);
            this.mainWindow = mainWindow;
            this.questionGroup = questionGroup;
            this.question = question;
 

            TitleLabel.Content = "Svarmulighed til " + question.Title;
            AnswerListBox.ItemsSource = question.Answers.OrderBy(o => o.Rank).ToList();
        }

        private void CreateAnswer_Click(object sender, RoutedEventArgs e)
        {
            CreateAnswer  window = new CreateAnswer(mainWindow);
            window.Show();
            window.CreatenewAnswer += CreateNewAnswer;
        
        }

        private void CreateNewAnswer(string title, decimal rank, string value, Question question = null)
        {
                try
                {
                    this.question.Answers.Add(new Answer()
                    {
                        Rank = rank,
                        Title = title,
                        Value = value,
                        Question = this.question,
                        Required = question

                    });
                    saveAndUpdate();

                }
                catch (Exception ex)
                {
                        
                 mainWindow.ShowError(ex.Message, true);
                }
                    
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ChangeView(new QuestionView(mainWindow,questionGroup), true);
        }

        private void UpdateAnswer_Click(object sender, RoutedEventArgs e)
        {
            Answer selectedAnswer = AnswerListBox.SelectedItem as Answer;
            if (selectedAnswer != null)
            {
                UpdateAnswer window = new UpdateAnswer(selectedAnswer,mainWindow);
                window.Show();
                window.Closing +=updateAnswer;
            }
            else
            {
                mainWindow.ShowError("Du skal vælge et svar for at kunne ændre", true);
            }         
        }

        private void updateAnswer(object sender, System.ComponentModel.CancelEventArgs e)
        {
               saveAndUpdate(); 
        }

        private void saveAndUpdate()
        {
            mainWindow.ModelFacade.Save();
            AnswerListBox.ItemsSource = null;
            AnswerListBox.ItemsSource = question.Answers.OrderBy(o => o.Rank).ToList();
        }

        private void DeleteAnswer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.SelectedItemNotNull(AnswerListBox);
                question.Answers.Remove(AnswerListBox.SelectedItem as Answer);
                saveAndUpdate();
            }
            catch (Exception ex)
            {
                    
                mainWindow.ShowError(ex.Message,true);
            }
        }

        private void AnswerListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
                Answer selectedAnswer = AnswerListBox.SelectedItem as Answer;
                UpdateAnswer window = new UpdateAnswer(selectedAnswer,mainWindow);
                window.Show();
                window.Closing +=updateAnswer;
        }
    }
}
