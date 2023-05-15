using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.FrontendWPF
{
    public class ProducerViewModel : ViewModelBase
    {
        private int id;
        private string producerName;
        private string location;
        private RestService _restService;

        public ProducerViewModel(RestService restService)
        {
            _restService = restService;
        }
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string ProducerName
        {
            get => producerName;
            set => SetProperty(ref producerName, value);
        }

        public string Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }
    }

    public class MedicineViewModel : ViewModelBase
    {
        private int id;
        private string medicineName;
        private int basePrice;
        private int producerId;
        private string heals;
        private RestService _restService;

        public MedicineViewModel(RestService restService)
        {
            _restService = restService;
        }
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string MedicineName
        {
            get => medicineName;
            set => SetProperty(ref medicineName, value);
        }

        public int BasePrice
        {
            get => basePrice;
            set => SetProperty(ref basePrice, value);
        }

        public int ProducerId
        {
            get => producerId;
            set => SetProperty(ref producerId, value);
        }

        public string Heals
        {
            get => heals;
            set => SetProperty(ref heals, value);
        }
    }

    public class PatientViewModel : ViewModelBase
    {
        private int id;
        private string patientName;
        private string illness;
        private int medicineId;
        private RestService _restService;

        public PatientViewModel(RestService restService)
        {
            _restService = restService;
        }
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string PatientName
        {
            get => patientName;
            set => SetProperty(ref patientName, value);
        }

        public string Illness
        {
            get => illness;
            set => SetProperty(ref illness, value);
        }

        public int MedicineId
        {
            get => medicineId;
            set => SetProperty(ref medicineId, value);
        }
    }
}
