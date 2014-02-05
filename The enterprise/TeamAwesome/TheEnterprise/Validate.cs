﻿using Model.DomainModel;
using System;
using System.Windows.Controls;
using TheEnterprise.Pages;

namespace TheEnterprise
{
    public static class Validate
    {
        public static void SelectedItemNotNull(object item)
        {
            if (item as ListBox != null)
            {
                ListBox listBox = item as ListBox;
                if (listBox.SelectedItem == null)
                {
                    throw new Exception("intet element valgt i listbox");
                }
            }
            if (item as ListView != null)
            {
                ListView listView = item as ListView;
                if (listView.SelectedItem == null)
                {
                    throw new Exception("intet element valgt i listbox");
                }
            }
            if (item as ComboBox != null)
            {
                ComboBox comboBox = item as ComboBox;
                if (comboBox.SelectedItem == null)
                {
                    throw new Exception("intet element valgt i listbox");
                }
            }
            
        }
        public static void TextBoxNotNull(TextBox textBox,string name = null)
        {
            if (textBox.Text.Trim() == "")
            {
                if (name == null)
                {
                    throw new Exception("Du skal udfylde " + name);
                }
                else
                {
                    throw new Exception("Du mangler at udfylde et felt");
                }               
            }
        }
        public static void DoubleClickNotNull(ListView listview, MainWindow mainWindow)
        {
            if (listview.SelectedItem != null)
            {
                QuestionGroup selectedQuestionGroup = listview.SelectedItem as QuestionGroup;
                mainWindow.ChangeView(new QuestionView(mainWindow, selectedQuestionGroup), false);
            }            
        }
    }
}