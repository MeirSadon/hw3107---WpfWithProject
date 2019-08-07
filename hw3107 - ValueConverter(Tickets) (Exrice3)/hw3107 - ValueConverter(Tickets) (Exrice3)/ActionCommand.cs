using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hw3107___ValueConverter_Tickets___Exrice3_
{
    public class ActionCommand<T> : ICommand
    {

        Func<T, bool> _canExecute;
        Action<T> _execute;

        public ActionCommand(Func<T, bool> canExecute, Action<T> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
