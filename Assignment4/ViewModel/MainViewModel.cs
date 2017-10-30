using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;
using Assignment4.Model;
using Assignment4.View;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
        #region DataMembers
        private Customer selectedCustomer;
        private string customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipCode;
        private bool buttonIsEnabled;
        #endregion

        #region Commands
        public RelayCommand GetCustomerCommand { get; private set; }
        public RelayCommand AddCustomerCommand { get; private set; }
        public RelayCommand ModifyCustomerCommand { get; private set; }
        public RelayCommand DeleteCustomerCommand { get; private set; }
        public RelayCommand<MainWindow> CloseWindowCommand { get; private set; }
        #endregion

        public MainViewModel()
        {
            ButtonIsEnabled = false;
            //Message receivers to accept messages from EditViewModel and AddViewModel
            //The sender also sends a token as the second parameter and only receivers with the same token will accept it.
            Messenger.Default.Register<Customer>(this, "add", (customer) =>
            {
                try
                {
                    // Code a query to retrieve the selected customer
                    // and store the Customer object in the class variable.
                    selectedCustomer = customer;
                    CustomerIDBox = Convert.ToString(customer.CustomerID);
                    this.DisplayCustomer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            });

            Messenger.Default.Register<Customer>(this, "modify", (customer) =>
            {
                try
                {
                    // Code a query to retrieve the selected customer
                    // and store the Customer object in the class variable.
                    selectedCustomer = customer;
                    this.DisplayCustomer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            });

            Messenger.Default.Register<Customer>(this, "modData", (customer) =>
            {
                SelectedCustomer.Name = customer.Name;
                SelectedCustomer.Address = customer.Address;
                SelectedCustomer.City = customer.City;
                SelectedCustomer.State = customer.State;
                SelectedCustomer.ZipCode = customer.ZipCode;
            });

            Messenger.Default.Register<Customer>(this, "clear", (customer) => 
            {
                this.ClearControls();
            });

            Messenger.Default.Register<Customer>(this, "reload", (customer) =>
            {
                this.GetCustomer(customer.CustomerID);
            });

            /// <summary>
            /// Get the customer using the customer ID.
            /// </summary>
            GetCustomerCommand = new RelayCommand(() =>
            {
                if (Validator.IsPresent(CustomerIDBox) &&
                Validator.IsInt32(CustomerIDBox))
                {
                    int customerID = Convert.ToInt32(CustomerIDBox);
                    this.GetCustomer(customerID);
                }
            });

            /// <summary>
            /// Open the add customer view.
            /// </summary>
            AddCustomerCommand = new RelayCommand(() =>
            {
                AddView addView = new AddView();
                addView.Show();
                ButtonIsEnabled = true;
            });

            /// <summary>
            /// Open the modify customer view.
            /// </summary>
            ModifyCustomerCommand = new RelayCommand(() =>
            {
                ModifyView modView = new ModifyView();
                Messenger.Default.Send(SelectedCustomer, "mod");
                modView.Show();
            });

            /// <summary>
            /// Delete a customer from the database.
            /// </summary>
            DeleteCustomerCommand = new RelayCommand(() =>
            {
                try
                {
                    // Mark the row for deletion.
                    // Update the database.
                    MMABooksEntity.mmaBooks.Customers.Remove(selectedCustomer);
                    MMABooksEntity.mmaBooks.SaveChanges();
                    Messenger.Default.Send(new NotificationMessage("Customer Removed!"));

                    CustomerIDBox = "";
                    this.ClearControls();
                }
                // Add concurrency error handling.
                // Place the catch block before the one for a generic exception.
                catch (DbUpdateConcurrencyException ex)
                {
                    ex.Entries.Single().Reload();
                    if (MMABooksEntity.mmaBooks.Entry(selectedCustomer).State == EntityState.Detached)
                    {
                        MessageBox.Show("Another user has deleted " + "that customer.", "Concurrency Error");
                        CustomerIDBox = "";
                        this.ClearControls();
                    }
                    else
                    {
                        MessageBox.Show("Another user has updated " + "that customer.", "Concurrency Error");
                        DisplayCustomer();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }

                ButtonIsEnabled = false;
            });

            /// <summary>
            /// Close the current window.
            /// </summary>
            CloseWindowCommand = new RelayCommand<MainWindow>((window) =>
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

        public string CustomerIDBox
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
                RaisePropertyChanged("CustomerIDBox");
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

        public string StateBox
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                RaisePropertyChanged("StateBox");
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

        public bool ButtonIsEnabled
        {
            get
            {
                return buttonIsEnabled;
            }
            set
            {
                buttonIsEnabled = value;
                RaisePropertyChanged("ButtonIsEnabled");
            }
        }
        #endregion

        #region GetCustomer
        private void GetCustomer(int CustomerID)
        {
            try
            {
                SelectedCustomer = (from customer in MMABooksEntity.mmaBooks.Customers
                                        where customer.CustomerID == CustomerID
                                        select customer).SingleOrDefault();
                if (SelectedCustomer == null)
                {
                    MessageBox.Show("No customer found with this ID. " +
                    "Please try again.", "Customer Not Found");
                    this.ClearControls();
                    ButtonIsEnabled = false;
                }
                else
                {
                    if (!MMABooksEntity.mmaBooks.Entry(
                    SelectedCustomer).Reference("State1").IsLoaded)
                        MMABooksEntity.mmaBooks.Entry(
                        SelectedCustomer).Reference("State1").Load();
                    this.DisplayCustomer();
                    ButtonIsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void DisplayCustomer()
        {
            NameBox = SelectedCustomer.Name;
            AddressBox = SelectedCustomer.Address;
            CityBox = SelectedCustomer.City;
            StateBox = SelectedCustomer.State1.StateName;
            ZipCodeBox = SelectedCustomer.ZipCode;
        }

        private void ClearControls()
        {
            NameBox = "";
            AddressBox = "";
            CityBox = "";
            StateBox = "";
            ZipCodeBox = "";
        }
        #endregion
    }
}