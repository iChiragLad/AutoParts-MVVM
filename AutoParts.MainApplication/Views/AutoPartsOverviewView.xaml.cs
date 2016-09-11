using System.Windows;

namespace AutoParts.MainApplication.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AutoPartsOverviewView : Window
    {
        public AutoPartsOverviewView()
        {
            InitializeComponent();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            var autoPartsDetailView = new AutoPartsDetailView();
            autoPartsDetailView.ShowDialog();
        }
    }
}
