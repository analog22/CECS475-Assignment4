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
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Assignment4.ViewModel
{
    public class ModifyViewModel : ViewModelBase
    {
        #region DataMembers
        private Customer selectedCustomer;
        private string name;
        private string address;
        private string city;
        private State selectedState;
        private ObservableCollection<State> states;
        private string zipCode;
        #endregion

        #region Commands
        public RelayCommand<Window> AcceptCommand { get; private set; }
        public RelayCommand<Window> CloseWindowCommand { get; private set; }
        #endregion

        public ModifyViewModel()
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

            Messenger.Default.Register<Customer>(this, "mod", (customer) =>
            {
                SelectedCustomer = customer;
                NameBox = customer.Name;
                AddressBox = customer.Address;
                CityBox = customer.City;
                SelectedState = customer.State1;
                ZipCodeBox = customer.ZipCode;
            });

            AcceptCommand = new RelayCommand<Window>((window) =>
            {
                //Check customer information before updating
                if (IsValidData())
                {
                    //update the customer
                    PutCustomerData(SelectedCustomer);
                    try
                    {
                        // Update the database.
                        MMABooksEntity.mmaBooks.SaveChanges();

                        if (window != null)
                        {
                            window.Close();
                        }

                        //Notify user and send customer back to MainViewModel for display
                        Messenger.Default.Send(new NotificationMessage("Changes Saved!"));
                        Messenger.Default.Send(SelectedCustomer, "modify");
                    }
                    // Add concurrency error handling.
                    // Place the catch block before the one for a generic exception.
                    catch (DbUpdateConcurrencyException ex)
                    {
                        ex.Entries.Single().Reload();
                        if (MMABooksEntity.mmaBooks.Entry(SelectedCustomer).State == EntityState.Detached)
                        {
                            MessageBox.Show("Another user has deleted " + "that customer.", "Concurrency Error");
                        }
                        else
                        {
                            MessageBox.Show("Another user has updated " + "that customer.", "Concurrency Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
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
        public Customer SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");
            }
        }

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
            SelectedCustomer.Name = NameBox;
            SelectedCustomer.Address = AddressBox;
            SelectedCustomer.City = CityBox;
            SelectedCustomer.State = SelectedState.StateName;
            SelectedCustomer.ZipCode = ZipCodeBox;
            SelectedCustomer.State1 = SelectedState;
            Messenger.Default.Send(SelectedCustomer, "modData");
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
