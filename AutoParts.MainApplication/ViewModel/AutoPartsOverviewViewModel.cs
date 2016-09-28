using AutoParts.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using AutoParts.DataAccessLayer;
using AutoParts.MainApplication.Extensions;
using AutoParts.MainApplication.Messages;
using AutoParts.MainApplication.Services;
using AutoParts.MainApplication.Utility;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;

namespace AutoParts.MainApplication.ViewModel
{
    class AutoPartsOverviewViewModel : ViewModelBase
    {
        private readonly IDataAccessService _dataAccessService;
        private readonly IOpenNextWindowService _openNextWindowService;
        public AutoPartsOverviewViewModel(IDataAccessService dataService, IOpenNextWindowService WindowService)
        {
            _dataAccessService = dataService;
            _openNextWindowService = WindowService;
            Messenger.Default.Register<UpdatePartsList>(this, OnUpdatePartsListReceived);
            LoadData();
            LoadCommands();
        }

        public AutoPartsOverviewViewModel(): this(new DataAccessService(new AutoPartsRepository()), new OpenNextWindowService())
        {
            
        }

        private void LoadData()
        {
            PartsCollection = _dataAccessService.GetAllParts().ToObservableCollection();
        }
        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditPart, canEditPart);
        }

        public ICommand EditCommand{ get; set; }
        

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

        private ObservableCollection<Parts> _partCollection;
        public ObservableCollection<Parts> PartsCollection
        {
            get
            {
                return _partCollection;
            }
            set
            {
                Set(() => PartsCollection, ref _partCollection, value);
            }
        }

        private void EditPart(object obj)
        {
            Messenger.Default.Send<Parts>(SelectedPart);
            _openNextWindowService.OpenWindow();
        }

        private bool canEditPart(object obj)
        {
            if (SelectedPart != null)
            {
                return true;
            }
            return false;
        }

        private void OnUpdatePartsListReceived(UpdatePartsList obj)
        {
            _openNextWindowService.CloseWindow();
            LoadData();
        }

    }
}
