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

namespace KUMF5H_HFT_2021221.WpfClient.VM
{
    internal class ProducerMenuWindowViewModel : ObservableRecipient
    {

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Producer> Producers { get; set; }

        private Producer selectedProducer;

        public Producer SelectedProducer
        {
            get { return selectedProducer; }
            set
            {
                if (value != null)
                {
                    selectedProducer = new Producer()
                    {
                        ProducerName = value.ProducerName,
                        Id = value.Id,
                        Location = value.Location,
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

        public ProducerMenuWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Producers = new RestCollection<Producer>("http://localhost:5000/", "producer");
                CreateCommand = new RelayCommand(() =>
                {
                    Producers.Add(new Producer()
                    {
                        ProducerName = SelectedProducer.ProducerName,
                        Location = SelectedProducer.Location,

                    });
                })
                {

                };
                UpdateCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Producers.Update(SelectedProducer);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteCommand = new RelayCommand(() =>
                {
                    Producers.Delete(SelectedProducer.Id);
                },
                () =>
                {
                    return SelectedProducer != null;
                });
                SelectedProducer = new Producer();
            }
        }




    }
}
