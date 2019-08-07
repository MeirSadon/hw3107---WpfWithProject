using FlightManagementProject;
using FlightManagementProject.Facade;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hw3107___ContentPresenter__Exrice2_
{
    public class ViewModelForFlight : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public ICommand SearchCommand { get; set; }

        private Flight _flight;
        public Flight MyFlight {
            get
            {
                return _flight;
            }
            set
            {
                _flight = value;
                OnPropertyChanged("MyFlight");
            }
        }

        public ViewModelForFlight()
        {
            _flight = new Flight();

            SearchCommand = new DelegateCommand<string>(
                (flightNumber) => { MyFlight = new AnonymousUserFacade().GetFlightById(Convert.ToInt32(flightNumber));},
                (flightNumber) => { return true; });
        }

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
