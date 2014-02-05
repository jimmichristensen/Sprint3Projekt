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
using System.Windows.Shapes;

namespace TheEnterprise.Pages.Admin.PopUp.QuestionGroup
{
    /// <summary>
    /// Interaction logic for CreateQuestianGroup.xaml
    /// </summary>

    public delegate void CreateQuestionGroupDelegate(string title, decimal rank, string info);

    public partial class CreateQuestianGroup : Window
    {
        public event CreateQuestionGroupDelegate CreateNewQuestionGroup;

        MainWindow main;
        public CreateQuestianGroup(MainWindow Main)
        {
            main = Main;
            InitializeComponent();
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

                CreateNewQuestionGroup(QuestionGroupTitleTextBox.Text, decimal.Parse(QuestionRankGroupTextBox.Text),
                QuestionInfoGroupTextBox.Text);
                this.Close();	
            }
            catch (Exception ex)
            {
                createFeedbackLabel.Content = ex.Message;
            }
        }
    }
}
