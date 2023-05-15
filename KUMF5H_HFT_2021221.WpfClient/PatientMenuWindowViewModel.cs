using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using KUMF5H_HFT_2021221.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Numerics;

namespace KUMF5H_HFT_2021221.WpfClient
{
    internal class PatientMenuWindowViewModel : ObservableRecipient
    {

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Patient> Patients { get; set; }

        private Patient selectedPatient;

        public Patient SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                if (value != null)
                {
                    selectedPatient = new Patient()
                    {
                        PatientName = value.PatientName,
                        Id = value.Id,
                        Illness = value.Illness,
                        MedicineID = value.MedicineID,
                    };
                    OnPropertyChanged();
                    (DeleteCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand UpdateCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PatientMenuWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Patients = new RestCollection<Patient>("http://localhost:5000/", "patient");
                CreateCommand = new RelayCommand(() =>
                {
                    Patients.Add(new Patient()
                    {
                        PatientName = SelectedPatient.PatientName
                    });
                });

                UpdateCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Patients.Update(SelectedPatient);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteCommand = new RelayCommand(() =>
                {
                    Patients.Delete(SelectedPatient.Id);
                },
                () =>
                {
                    return SelectedPatient != null;
                });
                SelectedPatient = new Patient();
            }
        }




    }
}
