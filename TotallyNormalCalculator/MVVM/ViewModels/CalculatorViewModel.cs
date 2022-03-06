using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotallyNormalCalculator.Core;
using TotallyNormalCalculator.MVVM.ViewModels;

namespace TotallyNormalCalculator.MVVM.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        public ICommand SwitchViewCommand { get; set; }
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand MaximizeCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand AddNumbersCommand { get; set; }
       

        private CalculatorViewModel _selectedViewModel;
        public CalculatorViewModel SelectedViewModel

        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        private string _calculatorText;

        public string CalculatorText
        {
            get { return _calculatorText; }
            set 
            {
                _calculatorText = value;
                OnPropertyChanged(nameof(CalculatorText));
            }
        }



        public CalculatorViewModel()
        {          
            SwitchViewCommand = new SwitchViewCommand(new MainViewModel());

            MinimizeCommand = new RelayCommand(o =>
            {
                System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            MaximizeCommand = new RelayCommand(o =>
            {
                if (System.Windows.Application.Current.MainWindow.WindowState != WindowState.Maximized)
                {
                    System.Windows.Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
                else
                {
                    System.Windows.Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
            });

            CloseWindowCommand = new RelayCommand(o =>
            {
                System.Windows.Application.Current.Shutdown();
            });


            AddNumbersCommand = new RelayCommand(o =>
            {
                CalculatorText += AddNumbersCommand.ParameterValue;
            });
       
        }
      
    }
}
