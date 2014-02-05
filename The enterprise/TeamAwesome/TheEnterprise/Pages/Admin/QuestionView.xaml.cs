using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model.DomainModel;
using TheEnterprise.Pages.Admin;
using TheEnterprise.Pages.Admin.PopUp.Question;

namespace TheEnterprise.Pages
{
    /// <summary>
    /// Interaction logic for QuestionView.xaml
    /// </summary>
    public partial class QuestionView : UserControl
    {
        private MainWindow mainWindow;
        private QuestionGroup questionGroup;

        public QuestionView(MainWindow mainWindow,QuestionGroup questionGroup)
        {
            try
            {
                InitializeComponent();
                this.mainWindow = mainWindow;
                this.questionGroup = questionGroup;
                TitleLabel.Content = "Spørgsmål til " + questionGroup.Title;
                
                QuestionListBox.ItemsSource = questionGroup.Questions.OrderBy(o => o.Rank).ToList();
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message,true);
            }  

            //AnimationClass.fadeOut(viewGrid, 0); AnimationClass.fadeIn(viewGrid, MainWindow.AnimationSpeed);
        }




        private void updateListViewAndSave()
        {
            mainWindow.ModelFacade.Save();
            QuestionListBox.ItemsSource = null;
            QuestionListBox.ItemsSource = questionGroup.Questions.OrderBy(o => o.Rank).ToList();
        }

        // Private methods
        private void saveChanges(object sender, EventArgs e)
        {
            updateListViewAndSave();
        }

        // UI Events
        private void OpenAnswers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.SelectedItemNotNull(QuestionListBox);
                Question selectedQuestion = QuestionListBox.SelectedItem as Question;
                mainWindow.ChangeView(new AnswerView(mainWindow, questionGroup, selectedQuestion), false);
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message,true);
            }        
        }
        private void CreateQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateQuestion createWindow = new CreateQuestion(mainWindow,questionGroup);
                createWindow.CreateNewQuestion += CreateNewQuestionWindow;
                createWindow.Show();
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message,true);    
            }       
        }
        private void PageBack_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ChangeView(new QuestionGroupView(mainWindow), true);
        }
        private void ChangeQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.SelectedItemNotNull(QuestionListBox);
                Question selectedQuestion = QuestionListBox.SelectedItem as Question;
                UpdateQuestion Window = new UpdateQuestion(selectedQuestion, mainWindow);
                Window.Show();
                Window.Closed += saveChanges;
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message,true);
            }      
        }
        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.SelectedItemNotNull(QuestionListBox);
                questionGroup.Questions.Remove(QuestionListBox.SelectedItem as Question);
                updateListViewAndSave();
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message, true);
            }          
        }
        private void QuestionListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Validate.SelectedItemNotNull(QuestionListBox);
                Question selectedQuestion = QuestionListBox.SelectedItem as Question;
                mainWindow.ChangeView(new AnswerView(mainWindow, questionGroup, selectedQuestion), false);
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message, true);
            }      
        }
        // Window event
        private void CreateNewQuestionWindow(string printTitle,string title, decimal rank, Question required = null)
        {
            try
            {
                questionGroup.Questions.Add(new Question()
                {
                    PrintTitle = printTitle,
                    Title = title,
                    Rank = rank,
                    QuestionGroup = questionGroup,
                    Required = required
                });
                updateListViewAndSave();
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message, true);
            }      
        }
    }
}
