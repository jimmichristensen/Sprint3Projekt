using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Model.DomainModel;
using TheEnterprise.Design;

namespace TheEnterprise.Pages
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        private MainWindow mainWindow;
        private List<GridPresent> grids = new List<GridPresent>();
        private Grid mainGrid = new Grid();
        private int count = 0;
        private List<RowEntity> TextBoxes; 

        public Main(MainWindow mainWindow)
        {
            InitializeComponent();
            GridTemplate();
            Content.Children.Add(mainGrid);
            this.mainWindow = mainWindow;
            resetValues();
            TextBoxes = addTextBoxRows();
            foreach (QuestionGroup questionGroup in mainWindow.ModelFacade.Filter.QuestionGroups)
            {
                addRow();
                Label l = new Label()
                {
                    FontSize = 25,
                    Content = questionGroup.Title
                };
                Grid.SetRow(l, count++);
                Grid.SetColumn(l, 0);
                mainGrid.Children.Add(l);

                GridPresent gp = new GridPresent(questionGroup);
                grids.Add(gp);
                foreach (Question q in questionGroup.Questions)
                {
                    if (q.IsActive(mainWindow.ModelFacade.Filter))
                    {
                        RowEntity row = gp.addRow(q.Rank, q);
                        row.SelectionChanged += AnswerSelectionChanged;
                    }

                }

                addRow();
                Grid g = gp.LoadGrid();
                Grid.SetRow(g, count++);
                Grid.SetColumn(g, 0);
                mainGrid.Children.Add(g);
                checkActiveQuestions();
            }


            addRow();
            Button btn = new Button()
            {
               Content = "Print",
               Margin = new Thickness(0,40,0,40),
               Width = 50
            };
            btn.Click += print;

            Grid.SetRow(btn, count++);
            Grid.SetColumn(btn, 0);
            mainGrid.Children.Add(btn);

        }

        private void print(object sender, RoutedEventArgs e)
        {
            try
            {
                    foreach (RowEntity re in TextBoxes)
                    {
                        if( re.AnswerTextBox.Text.Trim() == "" )throw new Exception(re.QuestionLabel.Text + " Skal udfyldes");
                        if (re.QuestionObject.PrintTitle == "1") mainWindow.ModelFacade.Filter.FilterType = re.AnswerTextBox.Text;
                        if (re.QuestionObject.PrintTitle == "2") mainWindow.ModelFacade.Filter.Customer = re.AnswerTextBox.Text;
                        if (re.QuestionObject.PrintTitle == "3") mainWindow.ModelFacade.Filter.Order = re.AnswerTextBox.Text;
                        if (re.QuestionObject.PrintTitle == "4") mainWindow.ModelFacade.Filter.MachineNr = re.AnswerTextBox.Text;
                        if (re.QuestionObject.PrintTitle == "5") mainWindow.ModelFacade.Filter.Name = re.AnswerTextBox.Text;
                    }
                    mainWindow.ModelFacade.Print();
            }
            catch (Exception ex)
            {
                mainWindow.ShowError(ex.Message,true);
            }
       
        }
        private void AnswerSelectionChanged(RowEntity row)
        {

            var selectedAnswer = row.AnswerComboBox.SelectedItem as Answer;
            row.QuestionObject.Value = selectedAnswer;
            // Aktivere jeg nogle nye?
            checkActiveQuestions();
        }

        public void checkActiveQuestions()
        {
            foreach (GridPresent gp in grids)
            {
                foreach (Question q in gp.QuestionGroup.Questions)
                {
                    if (q.Id != 0)
                    {
                        if (q.IsActive(mainWindow.ModelFacade.Filter) && !gp.IsCopy(q))
                        {
                            RowEntity newRow = gp.addRow(q.Rank, q);
                            newRow.SelectionChanged += AnswerSelectionChanged;
                        }
                    }
                }
                gp.Refresh(mainWindow.ModelFacade.Filter);
            }
        }

        private void resetValues()
        {
            foreach (QuestionGroup qg in mainWindow.ModelFacade.Filter.QuestionGroups)
            {
                foreach (Question question in qg.Questions)
                {
                    question.Value = null;
                }
            }
        }

        private void GridTemplate()
        {
            mainGrid = new Grid();
     
            // Create Columns
            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(1.0, GridUnitType.Star);
            mainGrid.ColumnDefinitions.Add(gridCol1);

           
        }
        private void addRow()
        {
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = GridLength.Auto;
            mainGrid.RowDefinitions.Add(gridRow1);
        }

        private List<RowEntity> addTextBoxRows()
        {

            var myTempQuestionGroup = new List<QuestionGroup>()
            {
                new QuestionGroup()
                {
                    Title = "Settings",
                    Rank = 0,
                    Questions = new BindingList<Question>()
                    {
                         new Question()
                        {
                            Title = "FilterType",
                            PrintTitle = "1",
                            Id = 0
                        },
                        new Question()
                        {
                            Title = "Kunde",
                            PrintTitle = "2",
                            Id = 0
                        },
                         new Question()
                        {
                            Title = "Ordrenr",
                            PrintTitle = "3",
                            Id = 0
                        },
                        new Question()
                        {
                            Title = "Maskin nr",
                            PrintTitle = "4",
                            Id = 0
                        },
                        new Question()
                        {
                            Title = "Konfigurationsnavn",
                            PrintTitle = "5",
                            Id = 0
                        }

                    }
                }
            };

            List<RowEntity> textBoxSettings = new List<RowEntity>();
   
           foreach (QuestionGroup questionGroup in myTempQuestionGroup)
            {
                addRow();
                Label l = new Label()
                {
                    FontSize = 25,
                    Content = questionGroup.Title
                };
                Grid.SetRow(l, count++);
                Grid.SetColumn(l, 0);
                mainGrid.Children.Add(l);

                GridPresent gp = new GridPresent(questionGroup);
                grids.Add(gp);
                foreach (Question q in questionGroup.Questions)
                {
                    if (q.IsActive(mainWindow.ModelFacade.Filter))
                    {
                        RowEntity row = gp.addRow(q.Rank, q,true);
                        textBoxSettings.Add(row);
                        row.SelectionChanged += AnswerSelectionChanged;
                    }

                }

                addRow();
                Grid g = gp.LoadGrid();
                Grid.SetRow(g, count++);
                Grid.SetColumn(g, 0);
                mainGrid.Children.Add(g);

            }

            return textBoxSettings;

        }

    } 

}
