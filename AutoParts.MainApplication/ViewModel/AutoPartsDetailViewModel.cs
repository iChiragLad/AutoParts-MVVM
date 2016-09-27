using System.ComponentModel;
using System.Windows.Input;
using AutoParts.DataAccessLayer;
using AutoParts.MainApplication.Messages;
using AutoParts.MainApplication.Utility;
using AutoParts.Model;
using GalaSoft.MvvmLight.Messaging;

namespace AutoParts.MainApplication.ViewModel
{
    class AutoPartsDetailViewModel : INotifyPropertyChanged
    {
        IAutoPartsRepository _autoPartsRepository;
        public AutoPartsDetailViewModel()
        {
            _autoPartsRepository = new AutoPartsRepository();
            LoadCommands();
            Messenger.Default.Register<Parts>(this, OnPartReceived);
        }

        private void OnPartReceived(Parts part)
        {
            SelectedPart = part;
        }

        private void LoadCommands()
        {
            SaveCommand = new CustomCommand(SavePart, canSavePart);
            DeleteCommand = new CustomCommand(DeletePart, canDeletePart);
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Parts _selectedPart;
        public Parts SelectedPart
        {
            get
            {
                return _selectedPart;
            }
            set
            {
                _selectedPart = value;
                RaisePropertyChanged("SelectedPart");
            }
        }

        private void DeletePart(object obj)
        {
            _autoPartsRepository.DeletePart(SelectedPart);
            Messenger.Default.Send<UpdatePartsList>(new UpdatePartsList());
        }
        private bool canDeletePart(object obj)
        {
            return true;
        }
        private bool canSavePart(object obj)
        {
            return true;
        }
        private void SavePart(object obj)
        {
            _autoPartsRepository.UpdatePart(SelectedPart);
            Messenger.Default.Send<UpdatePartsList>(new UpdatePartsList());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
