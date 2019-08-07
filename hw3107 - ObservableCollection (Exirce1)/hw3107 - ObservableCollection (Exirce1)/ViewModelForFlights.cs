using FlightManagementProject;
using FlightManagementProject.Facade;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hw3107___ObservableCollection__Exirce1_
{
    public class ViewModelForFlights : INotifyPropertyChanged,  ICommand
    {
        private IList<Flight> flights;
        public IList<Flight> Flights { get
            {
                return flights;
            }
            set
            {
               flights = value;
                OnPropertyChanged("Flights");
            }
        }

        public ICommand ShowButton { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler CanExecuteChanged;

        public ViewModelForFlights()
        {
            ShowButton = new DelegateCommand<string>((airlineName) => {
                AirlineCompany airline = new LoggedInAdministratorFacade().GetAirlineByUserName(new LoginToken<Administrator> { User = new Administrator { User_Name = FlyingCenterConfig.ADMIN_NAME, Password = FlyingCenterConfig.ADMIN_PASSWORD } }, airlineName);
                Flights = new LoggedInAirlineFacade().GetAllFlightsByAirline(new LoginToken<AirlineCompany> { User = airline });
                OnPropertyChanged("Flights");
            }, (airlineName) => { return true; });
        }

        public void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string airlineName = parameter as string;
            AirlineCompany airline = new LoggedInAdministratorFacade().GetAirlineByUserName(new LoginToken<Administrator> { User = new Administrator { User_Name = FlyingCenterConfig.ADMIN_NAME, Password = FlyingCenterConfig.ADMIN_PASSWORD } }, airlineName);
            Flights = new LoggedInAirlineFacade().GetAllFlightsByAirline(new LoginToken<AirlineCompany> { User = airline });
        }
    }
}
