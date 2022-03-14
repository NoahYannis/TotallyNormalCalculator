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
        private BaseViewModel _selectedViewModel = new CalculatorViewModel();
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        private BaseViewModel _currentDataContext = new CalculatorViewModel();
        public BaseViewModel CurrentDataContext
        {
            get { return _currentDataContext; }
            set
            { 
                _currentDataContext = value;
                OnPropertyChanged(nameof(CurrentDataContext));
            }
        }

        //private CalculatorViewModel calculatorViewModel;

        //public CalculatorViewModel CalculatorViewModel
        //{
        //    get { return calculatorViewModel; }
        //    set
        //    {
        //        calculatorViewModel = value;
        //        OnPropertyChanged(nameof(CalculatorViewModel));
        //    }
        //}

        //private DiaryViewModel diaryViewModel;

        //public DiaryViewModel DiaryViewModel
        //{
        //    get { return diaryViewModel; }
        //    set
        //    {
        //        diaryViewModel = value;
        //        OnPropertyChanged(nameof(DiaryViewModel));
        //    }
        //}



        //public RelayCommand SwitchViewCommand { get; set; }
        public ICommand SwitchViewCommand { get; set; }
        public MainViewModel()
        {

            //SwitchViewCommand = new RelayCommand(o =>
            //{
            //    if (SwitchViewCommand.ParameterValue.ToString() == "Diary")
            //    {
            //        SelectedViewModel = new DiaryViewModel();
            //    }
            //    else if (SwitchViewCommand.ParameterValue.ToString() == "Calculator")
            //    {
            //        SelectedViewModel = new CalculatorViewModel();
            //    }
            //});
            //
            SwitchViewCommand = new SwitchViewCommand(this);
        }


    }
}
