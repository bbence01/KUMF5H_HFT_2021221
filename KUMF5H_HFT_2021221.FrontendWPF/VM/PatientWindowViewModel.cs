using KUMF5H_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KUMF5H_HFT_2021221.FrontendWPF.VM
{
    public class PatientWindowViewModel : ObservableRecipient
    {
        public RestCollection<Patient> Patients { get; set; }

        public Patient SelectedPatient { get; set; }

        RestService restService = new RestService("http://localhost:5000");

        public ICommand GetCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public PatientWindowViewModel()
        {
            string baseurl = "http://localhost:44869/";
            Patients = new RestCollection<Patient>(baseurl, "patients");

            GetCommand = new RelayCommand(GetAllPatients);
            AddCommand = new RelayCommand(AddPatient, () => SelectedPatient != null);
            UpdateCommand = new RelayCommand(UpdatePatient, () => SelectedPatient != null);
            DeleteCommand = new RelayCommand(DeletePatient, () => SelectedPatient != null);
        }

        public void GetAllPatients()
        {
            var res = restService.Get<Producer>("/producer");

            foreach (var item in res)
            {
                Console.WriteLine(new { id = item.Id, name = item.ProducerName, item.Location });
            }
            
        }

        private void AddPatient()
        {
            Patients.Add(SelectedPatient);
        }

        private void UpdatePatient()
        {
            Patients.Update(SelectedPatient);
        }

        private void DeletePatient()
        {
            Patients.Delete(SelectedPatient.Id);
        }
    }

}
