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
using KUMF5H_HFT_2021221.WpfClient.VM;

namespace KUMF5H_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for StatMenuWindow.xaml
    /// </summary>
    public partial class StatMenuWindow : Window
    {
        public StatMenuWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as StatMenuWindowViewModel;

            switch (viewModel.SelectedCollection as string)
            {
                case "AverageResults":
                    viewModel.SelectedCollection = viewModel.AverageResults;
                    break;
                case "LocationResultss":
                    viewModel.SelectedCollection = viewModel.LocationResultss;
                    break;
            }
        }

    }
}
