using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutoParts.MainApplication.Views;

namespace AutoParts.MainApplication.Services
{
    class OpenNextWindowService : IOpenNextWindowService
    {
        Window DetailWindow = null;

        public void OpenWindow()
        {
            DetailWindow = new AutoPartsDetailView();
            DetailWindow.ShowDialog();
        }

        public void CloseWindow()
        {
            DetailWindow.Close();
            if (DetailWindow != null)
            {
                
            }
        }
    }
}
