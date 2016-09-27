using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.MainApplication.ViewModel
{
    class AutoPartsOverviewViewModel : INotifyPropertyChanged
    {
        private Parts selectedPart;
        public Parts SelectedPart
        {
            get
            {
                return selectedPart;
            }
            set
            {
                selectedPart = value;
                RaisePropertyChanged("SelectedPart");
            }
        }

        private List<Parts> partCollection;
        public List<Parts> PartsCollection
        {
            get
            {
                return partCollection;
            }
            set
            {
                partCollection = value;
                RaisePropertyChanged("PartsCollection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
