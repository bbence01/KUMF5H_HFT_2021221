using KUMF5H_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace KUMF5H_HFT_2021221.WpfClient.VM
{
    public class ResultsTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element != null && item != null)
            {
                if (item is AverageResult)
                    return element.FindResource("AverageResultTemplate") as DataTemplate;

                if (item is LocationResults)
                    return element.FindResource("LocationResultsTemplate") as DataTemplate;
            }

            return null;
        }
    }

}
