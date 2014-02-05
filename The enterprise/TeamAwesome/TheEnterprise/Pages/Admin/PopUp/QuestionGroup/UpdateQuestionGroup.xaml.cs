using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Model.DomainModel;
using TheEnterprise.Design;

namespace TheEnterprise.Pages.Admin.PopUp.QuestionGroup
{
    /// <summary>
    /// Interaction logic for UpdateQuestionGroup.xaml
    /// </summary>

    public partial class UpdateQuestionGroup : Window
    {
        MainWindow main;
        private Model.DomainModel.QuestionGroup questionGroup;
        public UpdateQuestionGroup(Model.DomainModel.QuestionGroup questionGroup, MainWindow Main)
        {
            InitializeComponent();
            main = Main;
            this.questionGroup = questionGroup;

            QuestionInfoGroupTextBox.Text = questionGroup.Info;
            QuestionGroupTitleTextBox.Text = questionGroup.Title;
            QuestionRankGroupTextBox.Text = questionGroup.Rank.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Validate.TextBoxNotNull(QuestionGroupTitleTextBox);
                Validate.TextBoxNotNull(QuestionInfoGroupTextBox);
                Validate.TextBoxNotNull(QuestionRankGroupTextBox);

                Decimal rank = Helper.DecimalParse(QuestionRankGroupTextBox.Text);
                Helper.QuestionGroupRankAvailable(rank, main.ModelFacade.Filter.QuestionGroups);

                questionGroup.Info = QuestionInfoGroupTextBox.Text;
                questionGroup.Title = QuestionGroupTitleTextBox.Text;
                questionGroup.Rank = decimal.Parse(QuestionRankGroupTextBox.Text);
                Close();  
            }
            catch (Exception ex)
            {
                updateFeedbackLabel.Content = ex.Message;
            }
        }
    }
}
