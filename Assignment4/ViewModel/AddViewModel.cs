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
        #region DataMembers
        private string name;
        private string address;
        private string city;
        private ObservableCollection<State> States;
        private string zipCode;
        private Customer customer;
        #endregion

        #region Commands
        public RelayCommand<Window> AcceptCommand { get; private set; }
        public RelayCommand<Window> CloseWindowCommand { get; private set; }
        #endregion

        public AddViewModel()
        {
            try
            {
                // Code a query to retrieve the required information from
                // the States table, and sort the results by state name.
                // Bind the State combo box to the query results.
                var states = (from state in MMABooksEntity.mmaBooks.States orderby state.StateName select state).ToList();
                States = new ObservableCollection<State>(states);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

            AcceptCommand = new RelayCommand<Window>((window) =>
            {
                //Check customer information before adding
                if (IsValidData())
                {
                    //create a new customer, populate, and add to db
                    customer = new Customer();
                    //this.PutCustomerData(customer);
                    customer = MMABooksEntity.mmaBooks.Customers.Add(customer);
                    MMABooksEntity.mmaBooks.SaveChanges();

                    window.Close();

                    //notify user and send the customer back to MainViewModel for display
                    Messenger.Default.Send(new NotificationMessage("Customer Added!"));
                    Messenger.Default.Send(customer, "add");
                }
            });

            CloseWindowCommand = new RelayCommand<Window>((window) =>
            {
                if (window != null)
                {
                    window.Close();
                }
            });
        }

        #region Properties
        public string NameBox
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("NameBox");
            }
        }

        public string AddressBox
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                RaisePropertyChanged("AddressBox");
            }
        }

        public string CityBox
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                RaisePropertyChanged("CityBox");
            }
        }

        public string ZipCodeBox
        {
            get
            {
                return zipCode;
            }
            set
            {
                zipCode = value;
                RaisePropertyChanged("ZipCodeBox");
            }
        }
        #endregion

        public bool IsValidData()
        {
            return true;
        }
    }
}
