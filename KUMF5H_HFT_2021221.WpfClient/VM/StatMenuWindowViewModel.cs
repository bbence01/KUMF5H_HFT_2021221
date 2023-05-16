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
using System.Collections.ObjectModel;

namespace KUMF5H_HFT_2021221.WpfClient.VM
{
    internal class StatMenuWindowViewModel : ObservableRecipient
    {

        RestService restService = new RestService("http://localhost:5000");

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public List<AverageResult> AverageResultsList { get; set; }

        // public RestCollection<AverageResult> AverageResults { get; set; }

        public ObservableCollection<AverageResult> AverageResults { get; set; }




        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public StatMenuWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                AverageResults= new ObservableCollection<AverageResult>();

              //  AverageResults = new RestCollection<AverageResult>("http://localhost:5000/", "stat");

                AverageResultsList = restService.Get<AverageResult>("/stat/AvarageByProducers");

                foreach (var item in AverageResultsList)
                {
                    AverageResults.Add(item);
                }




            }
        }




    }
}
