using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4.Model;

namespace Assignment4.ViewModel
{

    public class AddViewModel : ViewModelBase
    {
        public RelayCommand<Window> CloseWindowCommand { get; private set; }

        public AddViewModel()
        {
            this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
        }

        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
