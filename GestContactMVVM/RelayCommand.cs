using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestContactMVVM
{
    public class RelayCommand : ICommand
    {
        private Action _Execute;
        private Func<bool> _CanExecute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_CanExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_CanExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action Execute) : this(Execute, null)
        {
        }

        public RelayCommand(Action Execute, Func<bool> CanExecute)
        {
            if (Execute == null)
                throw new ArgumentNullException();

            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return (_CanExecute == null) ? true : _CanExecute();
        }

        public void Execute(object parameter)
        {
            _Execute();
        }
    }
}
