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

        public SwitchViewCommand(BaseViewModel viewModel)
        {
            this.viewModel = (MainViewModel)viewModel;
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
                viewModel.CurrentDataContext = viewModel.SelectedViewModel;
            }
            else if (parameter.ToString() == "Calculator")
            {
                viewModel.SelectedViewModel = new CalculatorViewModel();
                viewModel.CurrentDataContext = new CalculatorViewModel();

            }
        }
    }
}
