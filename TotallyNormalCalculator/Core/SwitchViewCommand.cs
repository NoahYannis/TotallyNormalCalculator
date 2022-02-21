using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TotallyNormalCalculator.MVVM.ViewModels;

namespace TotallyNormalCalculator.Core
{
    public class SwitchViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public SwitchViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Diary")
            {
                viewModel.SelectedViewModel = new DiaryViewModel(); 
            }
            else if (parameter.ToString() == "Calculator")
            {
                viewModel.SelectedViewModel = new CalculatorViewModel();
            }
        }
    }
}
