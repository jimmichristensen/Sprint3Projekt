using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Model.DomainModel;

namespace TheEnterprise.Design
{
    public delegate void NewRowCreatedDelegate();

    public class QuestionGroupUI
    {
        public TextBox CreateTitleTextBox(int row, string txt = null)
        {
            TextBox tb = new TextBox()
            {
                Text = txt,
                Uid = row.ToString()
            };
            Grid.SetRow(tb, row);
            Grid.SetColumn(tb, 0);
            return tb;
        }
        public TextBox CreateRankTextBox(int row, string txt = null)
        {
            TextBox tb = new TextBox()
            {
                Text = txt,
                Uid = row.ToString()
            };
            Grid.SetRow(tb, row);
            Grid.SetColumn(tb, 1);
            return tb;
        }
        public Button CreateInfoButton(int row, string txt)
        {
            Button btn = CreateNiceButton(txt,row);
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, 2);
            return btn;
        }
        public Button CreateDeleteButton(int row, string txt)
        {
            Button btn = CreateNiceButton(txt,row);
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, 3);
            return btn;
        }
        public Button CreateSaveButton(int row, string txt)
        {
            Button btn = CreateNiceButton(txt,row);
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, 4);
            return btn;
        }
        public Button CreateOpenButton(int row, string txt)
        {
            Button btn = CreateNiceButton(txt,row);
            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, 5);
            return btn;
        }
        public Button CreateNiceButton(string txt,int row)
        {
            var TextBox = new TextBox();

            var Btn = new Button()
            {
                Uid = row.ToString(),
                Content = txt,
                BorderBrush = Brushes.Gray,
                Background = Brushes.White,
                Padding = new Thickness()
                {
                    Bottom = 0,
                    Left = 7,
                    Right = 7,
                    Top = 0

                },
                Margin = new Thickness()
                {
                    Bottom = 0,
                    Left = 0,
                    Right = 0,
                    Top = 0

                },



            };
            return Btn;
        } 

    }

    public class QuestionGroupRow
    {
        public int Row;
        public bool NewRow;
        public QuestionGroup QuestionGroup;
      
        public QuestionGroupRow(QuestionGroup questionGroup,Grid questionGroupList, int rowCount, string title, decimal rank, bool newRow = false)
        {
            Row = rowCount;
            NewRow = newRow;
            QuestionGroup = questionGroup;

            QuestionGroupUI UI = new QuestionGroupUI();
            questionGroupList.Children.Add(UI.CreateTitleTextBox(rowCount, title));
            questionGroupList.Children.Add(UI.CreateRankTextBox(rowCount, rank.ToString()));
            questionGroupList.Children.Add(UI.CreateInfoButton(rowCount, "Info"));
            questionGroupList.Children.Add(UI.CreateDeleteButton(rowCount, "Slet"));
            questionGroupList.Children.Add(UI.CreateSaveButton(rowCount, "Gem"));
            questionGroupList.Children.Add(UI.CreateOpenButton(rowCount, "Åben"));
        }
    }
    public class QuestionGroupGrid
    {
        private int rowCount = 0;
        public List<QuestionGroupRow> QuestionGroupRows = new List<QuestionGroupRow>();
        public event NewRowCreatedDelegate NewRowCrated;

        public void AddRow(QuestionGroup questionGroup,Grid questionGroupList, string title, decimal rank, bool newRow = false)
        {
            QuestionGroupRows.Add(new QuestionGroupRow(questionGroup,questionGroupList, rowCount, title, rank));
            NewRowCrated();
            rowCount++;

        }
    }
}