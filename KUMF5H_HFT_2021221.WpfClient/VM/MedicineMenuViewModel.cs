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
using Newtonsoft.Json.Linq;

namespace KUMF5H_HFT_2021221.WpfClient.VM
{
    internal class MedicineMenuViewModel : ObservableRecipient
    {

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Medicine> Medicines { get; set; }

        private Medicine selectedMedicine;

        public Medicine SelectedMedicine
        {
            get { return selectedMedicine; }
            set
            {
                if (value != null)
                {
                    selectedMedicine = new Medicine()
                    {
                        MedicineName = value.MedicineName,
                        Id = value.Id,
                        BasePrice = value.BasePrice,
                        ProducerID = value.ProducerID,
                         Heals = value.Heals

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

        public MedicineMenuViewModel()
        {

            if (!IsInDesignMode)
            {
                Medicines = new RestCollection<Medicine>("http://localhost:5000/", "medicine", "hub");
                CreateCommand = new RelayCommand(() =>
                {
                    Medicines.Add(new Medicine()
                    {
                        MedicineName = SelectedMedicine.MedicineName,
                        BasePrice = SelectedMedicine.BasePrice,
                        ProducerID = SelectedMedicine.ProducerID,
                        Heals = SelectedMedicine.Heals,

                    });
                })
                {

                };
                UpdateCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Medicines.Update(SelectedMedicine);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteCommand = new RelayCommand(() =>
                {
                    Medicines.Delete(SelectedMedicine.Id);
                },
                () =>
                {
                    return SelectedMedicine != null;
                });
                SelectedMedicine = new Medicine();
            }
        }




    }
}
