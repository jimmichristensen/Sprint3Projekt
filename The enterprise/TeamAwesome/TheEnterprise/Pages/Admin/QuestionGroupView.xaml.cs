using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Model.DomainModel;
using TheEnterprise.Pages.Admin.PopUp.QuestionGroup;

namespace TheEnterprise.Pages
{
    /// <summary>
    /// Interaction logic for QuestionGroupView.xaml
    /// </summary>
    public partial class QuestionGroupView : UserControl
    {
        private MainWindow mainWindow;


        public QuestionGroupView(MainWindow mainWindow)
        {
            try
            {
                InitializeComponent();
                this.mainWindow = mainWindow;

                QuestionGroupListBox.ItemsSource = mainWindow.ModelFacade.Filter.QuestionGroups;
                //AnimationClass.fadeOut(viewGrid, 0); AnimationClass.fadeIn(viewGrid, MainWindow.AnimationSpeed);
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message,true);
            }
        }

        private void saveAndRefresh()
        {
            QuestionGroupListBox.Items.Refresh();
            mainWindow.ModelFacade.Save();
        }

        // UI Event
        private void OpenQuestionGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.SelectedItemNotNull(QuestionGroupListBox);
                QuestionGroup selectedQuestionGroup = QuestionGroupListBox.SelectedItem as QuestionGroup;
                mainWindow.ChangeView(new QuestionView(mainWindow,selectedQuestionGroup), false);
            }
            catch (Exception ex)
            {
                 mainWindow.ShowError(ex.Message, true);
            }       
        }
        private void CreateQuestionGroup_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestianGroup createWindow = new CreateQuestianGroup(mainWindow);
            createWindow.CreateNewQuestionGroup += createNewQuestionGroup;
            createWindow.Show();
        }
        private void UpdateQuetionGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.SelectedItemNotNull(QuestionGroupListBox);
                QuestionGroup selectedQuestionGroup = QuestionGroupListBox.SelectedItem as QuestionGroup;
                UpdateQuestionGroup window = new UpdateQuestionGroup(selectedQuestionGroup, mainWindow);
                window.Show();
                window.Closed += SaveChanges;
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message, true);
            }           
        }   
        private void DeleteQuestionGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.SelectedItemNotNull(QuestionGroupListBox);
                QuestionGroup selectedQuestionGroup = QuestionGroupListBox.SelectedItem as QuestionGroup;
                mainWindow.ModelFacade.Filter.QuestionGroups.Remove(selectedQuestionGroup);
                saveAndRefresh();

                var LoadedFilterType = mainWindow.ModelFacade.Filter.Type;

                if (LoadedFilterType != FilterType.TestTemplate)
                {
                    if (LoadedFilterType != FilterType.DanishTemplate)
                    {
                        var mf = new ModelFacade(FilterType.DanishTemplate);
                        mf.Filter.QuestionGroups.Remove(mf.FindQuestionGroup(selectedQuestionGroup.Id));
                        mf.Save();
                    }
                    if (LoadedFilterType != FilterType.EnglishTemplate)
                    {
                        var mf = new ModelFacade(FilterType.EnglishTemplate);
                        mf.Filter.QuestionGroups.Remove(mf.FindQuestionGroup(selectedQuestionGroup.Id));
                        mf.Save();
                    }
                    if (LoadedFilterType != FilterType.DeutschTemplate)
                    {
                        var mf = new ModelFacade(FilterType.DeutschTemplate);
                        mf.Filter.QuestionGroups.Remove(mf.FindQuestionGroup(selectedQuestionGroup.Id));
                        mf.Save();
                    }
                }

            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message, true);
            }
        }
        private void QuestionGroupListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Validate.DoubleClickNotNull(QuestionGroupListBox, mainWindow);
        }
        private void backToStart_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ChangeView(new homeView(mainWindow), true);
        }
        // Window Event
        private void createNewQuestionGroup(string title, decimal rank, string info)
        {
            QuestionGroup questionGroup = new QuestionGroup()
            {
                Info = info,
                Title = title,
                Rank = rank
            };
            QuestionGroup questionGroupNotTranslated = new QuestionGroup()
            {
                Id = questionGroup.Id,
                Info = info,
                Title = title   + " (not translated)",
                Rank = rank
            };
            mainWindow.ModelFacade.Filter.QuestionGroups.Add(questionGroup);
            saveAndRefresh();

            var LoadedFilterType = mainWindow.ModelFacade.Filter.Type;

            if (LoadedFilterType != FilterType.TestTemplate)
            {
                if (LoadedFilterType != FilterType.DanishTemplate)
                {
                    var mf = new ModelFacade(FilterType.DanishTemplate);
                    mf.Filter.QuestionGroups.Add(questionGroupNotTranslated);
                    mf.Save();
                }
                if (LoadedFilterType != FilterType.EnglishTemplate)
                {
                    var mf = new ModelFacade(FilterType.EnglishTemplate);
                    mf.Filter.QuestionGroups.Add(questionGroupNotTranslated);
                    mf.Save();
                }
                if (LoadedFilterType != FilterType.DeutschTemplate)
                {
                    var mf = new ModelFacade(FilterType.DeutschTemplate);
                    mf.Filter.QuestionGroups.Add(questionGroupNotTranslated);
                    mf.Save();
                }
            }

        }
        private void SaveChanges(object sender, EventArgs e)
        {
            saveAndRefresh();
        }
    }
}
