using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MathPracticePlatform.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _executeWithParam;
        private readonly Action _executeWithoutParam;
        private readonly Func<object, bool> _canExecuteWithParam;
        private readonly Func<bool> _canExecuteWithoutParam;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _executeWithParam = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteWithParam = canExecute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _executeWithoutParam = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteWithoutParam = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_executeWithParam != null)
                return _canExecuteWithParam == null || _canExecuteWithParam(parameter);

            return _canExecuteWithoutParam == null || _canExecuteWithoutParam();
        }

        public void Execute(object parameter)
        {
            if (_executeWithParam != null)
                _executeWithParam(parameter);
            else
                _executeWithoutParam?.Invoke();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
