using AutoParts.DataAccessLayer;
using AutoParts.MainApplication.Services;
using AutoParts.MainApplication.ViewModel;

namespace AutoParts.MainApplication
{
    class ViewModelLocator
    {
        private static AutoPartsOverviewViewModel _autoPartsOverviewViewModel = new AutoPartsOverviewViewModel();
        private static AutoPartsDetailViewModel _autoPartsDetailViewModel = new AutoPartsDetailViewModel();

        public static AutoPartsOverviewViewModel AutoPartsOverviewViewModelObject
        {
            get { return _autoPartsOverviewViewModel; }
        }

        public static AutoPartsDetailViewModel AutoPartsDetailViewModelObject
        {
            get { return _autoPartsDetailViewModel; }
        }
    }
}
