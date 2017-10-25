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
        private State selectedState;
        private ObservableCollection<State> states;
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
                var statesQuery = (from state in MMABooksEntity.mmaBooks.States orderby state.StateName select state).ToList();
                states = new ObservableCollection<State>(statesQuery);
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
                    this.PutCustomerData(customer);
                    customer = MMABooksEntity.mmaBooks.Customers.Add(customer);
                    MMABooksEntity.mmaBooks.SaveChanges();
                    if (window == null)
                    {
                        Console.WriteLine("wtf");
                    }
                    if (window != null)
                    {
                        window.Close();
                    }

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

        public State SelectedState
        {
            get
            {
                return selectedState;
            }
            set
            {
                selectedState = value;
                RaisePropertyChanged("SelectedState");
            }
        }

        public ObservableCollection<State> States
        {
            get
            {
                return states;
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

        #region Methods
        private void PutCustomerData(Customer customer)
        {
            customer.Name = NameBox;
            customer.Address = AddressBox;
            customer.City = CityBox;
            customer.State = SelectedState.StateName;
            customer.ZipCode = ZipCodeBox;
            customer.State1 = SelectedState;
        }

        public bool IsValidData()
        {
            bool isPresent = Validator.IsPresent(NameBox) 
                                && Validator.IsPresent(AddressBox) 
                                && Validator.IsPresent(CityBox) 
                                && Validator.IsPresent(SelectedState.StateName)
                                && Validator.IsPresent(ZipCodeBox);
            bool isLength = Validator.IsWithinRange(NameBox, 2, 25)
                                && Validator.IsWithinRange(AddressBox, 2, 50)
                                && Validator.IsWithinRange(CityBox, 2, 50)
                                && Validator.IsWithinRange(ZipCodeBox, 5, 5);
            bool isZipCode = Validator.IsInt32(ZipCodeBox);
            if (isPresent && isLength && isZipCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
