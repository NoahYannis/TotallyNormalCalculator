using System;
using System.Windows.Input;
using TotallyNormalCalculator.MVVM.ViewModels;


namespace TotallyNormalCalculator.Core
{
    public class RelayCommand : BaseViewModel, ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        private object _parameterValue;
        public object ParameterValue
        {
            get { return _parameterValue; }
            set
            {
                _parameterValue = value;
                OnPropertyChanged(nameof(ParameterValue));
            }
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.ParameterValue = parameter;
            this.execute(parameter);
        }
    }
}
