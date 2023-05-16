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
        private object _selectedCollection;

        public List<AverageResult> AverageResultsList { get; set; }
        public List<LocationResults> LocationResultssList { get; set; }

        // public RestCollection<AverageResult> AverageResults { get; set; }

        public ObservableCollection<AverageResult> AverageResults { get; set; }
        public ObservableCollection<LocationResults> LocationResultss { get; set; }


        public ObservableCollection<string> CollectionNames { get; } = new ObservableCollection<string> { "AverageResults", "LocationResultss" };

        public object SelectedCollection
        {
            get { return _selectedCollection; }
            set
            {
                if (_selectedCollection != value)
                {
                    _selectedCollection = value;
                    OnPropertyChanged(nameof(SelectedCollection));
                }
            }
        }

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
            CollectionNames = new ObservableCollection<string>
        {
            "AverageResults",
            "LocationResultss",

        };

            if (!IsInDesignMode)
            {
                AverageResults = new ObservableCollection<AverageResult>();


                AverageResultsList = restService.Get<AverageResult>("/stat/AvarageByProducers");

                foreach (var item in AverageResultsList)
                {
                    AverageResults.Add(item);
                }

                LocationResultss = new ObservableCollection<LocationResults>();


                LocationResultssList = restService.Get<LocationResults>("/stat/GetLocations");

                foreach (var item in LocationResultssList)
                {
                    LocationResultss.Add(item);
                }




            }
        }

        public class Item
        {
            public string Name { get; set; }

            public string Description { get; set; }
        }





    }
}
