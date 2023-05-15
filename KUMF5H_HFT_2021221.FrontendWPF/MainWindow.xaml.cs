using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using KUMF5H_HFT_2021221.FrontendWPF;
using Microsoft.Toolkit.Mvvm.Messaging;
using KUMF5H_HFT_2021221.FrontendWPF.Sevice;
using NavigationService = KUMF5H_HFT_2021221.FrontendWPF.Sevice.NavigationService;
using KUMF5H_HFT_2021221.FrontendWPF.VM;

namespace KUMF5H_HFT_2021221.FrontendWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel vm = new MainWindowViewModel();
            this.DataContext = vm;
            NavigationService navigationService = new NavigationService(this);
            vm.NavigationService = navigationService;



            // Mediator pattern, better than hacky VM access from window
            WeakReferenceMessenger.Default.Register<object, string, string>(this, "ContentChanged", (sender, args) =>
            {
              
            });
        }

        // Event redirect
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Mediator pattern, forward event to VM
            WeakReferenceMessenger.Default.Send("MainWindowLoaded", "MainWindowLoaded");
        }
    }
}
