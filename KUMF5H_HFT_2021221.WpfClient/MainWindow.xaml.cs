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

namespace KUMF5H_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            PatientMenuWindow patientMenu = new PatientMenuWindow();
            patientMenu.Show();
        }
        private void MedicineButton_Click(object sender, RoutedEventArgs e)
        {
            MedicineMenuWindow patientMenu = new MedicineMenuWindow();
            patientMenu.Show();
        }
        private void ProducerButton_Click(object sender, RoutedEventArgs e)
        {
            ProducerMenuWindow patientMenu = new ProducerMenuWindow();
            patientMenu.Show();
        }
        private void StatButton_Click(object sender, RoutedEventArgs e)
        {
            StatMenuWindow patientMenu = new StatMenuWindow();
            patientMenu.Show();
        }

    }
}
