using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TotallyNormalCalculator.Core;

namespace TotallyNormalCalculator.MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
          
        }

        public ICommand SwitchViewCommand { get; set; }
        public MainViewModel()
        {
            SwitchViewCommand = new SwitchViewCommand(this);
        }

    }
}
