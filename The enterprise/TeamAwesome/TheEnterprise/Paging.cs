using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using TheEnterprise.Pages;
using TheEnterprise.Pages.Admin;

namespace TheEnterprise
{


    public class Paging
    {
        private MainWindow mainWindow;

        public Paging(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void ChangePage(UserControl page)
        {
            //ChangedPage(page);
            mainWindow.Content.Children.Clear();
            mainWindow.Content.Children.Add(page);
        }
    }

   
}