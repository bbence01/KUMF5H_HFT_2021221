using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KUMF5H_HFT_2021221.FrontendWPF.Sevice
{
    public class NavigationService
    {
        public MainWindow mainWindow;

        public NavigationService(MainWindow mw )
        {
            mainWindow = mw;
        }

        public void NavigateTo(Window window)
        {
            mainWindow.Hide(); // Hide the current window
            window.Show(); // Show the new window
        }
    }

}
