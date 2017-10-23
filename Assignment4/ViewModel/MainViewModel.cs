using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Collections.ObjectModel;
using Assignment4.Model;
using Assignment4.View;
using System;

namespace Assignment4.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        public RelayCommand GetCustomerCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand ModifyCustomerCommand { get; private set; }
        public RelayCommand<MainWindow> CloseWindowCommand { get; private set; }

        public MainViewModel()
        {
            GetCustomerCommand = new RelayCommand(GetCustomerMethod);
            AddCustomerCommand = new RelayCommand(AddCustomerMethod);
            ModifyCustomerCommand = new RelayCommand(ModifyCustomerMethod);
            this.CloseWindowCommand = new RelayCommand<MainWindow>(this.CloseWindow);
        }

        private void GetCustomerMethod()
        {

        }

        private void AddCustomerMethod()
        {
            AddView addView = new AddView();
            addView.Show();
        }

        private void ModifyCustomerMethod()
        {
            ModifyView modView = new ModifyView();
            modView.Show();
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