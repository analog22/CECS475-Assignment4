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
using System.Collections.ObjectModel;

namespace Assignment4.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        private ObservableCollection<State> states = new ObservableCollection<State>();
        public RelayCommand<Window> AcceptCommand { get; private set; }
        public RelayCommand<Window> CloseWindowCommand { get; private set; }

        public AddViewModel()
        {
            AcceptCommand = new RelayCommand<Window>(AcceptMethod);
            this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
        }

        private void AcceptMethod(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
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
