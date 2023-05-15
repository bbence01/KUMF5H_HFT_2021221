using GalaSoft.MvvmLight.Messaging;
using KUMF5H_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using KUMF5H_HFT_2021221.FrontendWPF.Sevice;
using KUMF5H_HFT_2021221.FrontendWPF.Windows;
namespace KUMF5H_HFT_2021221.FrontendWPF.VM
{

    public class MainWindowViewModel : ObservableRecipient
    {
        public ICommand NavigateToPatientCommand { get; private set; }
        public ICommand NavigateToMedicineCommand { get; private set; }
        public ICommand NavigateToProducerCommand { get; private set; }

        private PatientService patientService;
        private MedicineService medicineService;
        private ProducerService producerService;


        public RestCollection<Patient> Patients { get; set; }
        public RestCollection<Medicine> Medicines { get; set; }
        public RestCollection<Producer> Producers { get; set; }



        public NavigationService NavigationService { get; set; }

        public MainWindowViewModel()
        {
            string baseurl = "http://localhost:5000/";
           // var navigationService = new NavigationService(this);

            NavigateToPatientCommand = new RelayCommand(() => NavigationService.NavigateTo(new PatientWindow()));
            NavigateToMedicineCommand = new RelayCommand(() => NavigationService.NavigateTo(new MedicineWindow()));
            NavigateToProducerCommand = new RelayCommand(() => NavigationService.NavigateTo(new ProducerWindow()));

            Patients = new RestCollection<Patient>(baseurl, "patients");
            Medicines = new RestCollection<Medicine>(baseurl, "medicines");
            Producers = new RestCollection<Producer>(baseurl, "producers");
        }
    }
}
