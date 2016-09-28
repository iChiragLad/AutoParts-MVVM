using System.ComponentModel;
using System.Windows.Input;
using AutoParts.DataAccessLayer;
using AutoParts.MainApplication.Messages;
using AutoParts.MainApplication.Utility;
using AutoParts.Model;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace AutoParts.MainApplication.ViewModel
{
    class AutoPartsDetailViewModel : ViewModelBase
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
            SaveCommand = new RelayCommand<string>(SavePart, canSavePart);
            DeleteCommand = new RelayCommand<string>(DeletePart, canDeletePart);
        }

        public RelayCommand<string> SaveCommand { get; set; }
        public RelayCommand<string> DeleteCommand { get; set; }

        private Parts _selectedPart;
        public Parts SelectedPart
        {
            get
            {
                return _selectedPart;
            }
            set
            {
                Set(() => SelectedPart, ref _selectedPart, value);
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
    }
}
