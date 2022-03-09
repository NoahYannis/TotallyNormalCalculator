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
        public RelayCommand AddCharactersCommand { get; set; }
        public RelayCommand RemoveCharactersCommand { get; set; }
        public RelayCommand CalculateCommand { get; set; }
        public RelayCommand AllClearCommand { get; set; }
       

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

        private long _firstNumber;
        public long FirstNumber
        {
            get { return _firstNumber; }
            set 
            {
                _firstNumber = value;
                OnPropertyChanged(nameof(FirstNumber));
            }
        }

        private long _secondNumber;
        public long SecondNumber
        {
            get { return _secondNumber; }
            set
            {
                _secondNumber = value;
                OnPropertyChanged(nameof(SecondNumber));
            }
        }

        private string _operation;
        public string Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;
                OnPropertyChanged(nameof(Operation));
            }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set 
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
                CalculatorText = Result;
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

            AddCharactersCommand = new RelayCommand(o =>
            {
                CalculatorText += AddCharactersCommand.ParameterValue;    

                switch (AddCharactersCommand.ParameterValue)
                {
                    case "+":
                        Operation = "+";
                        break;

                    case "-":
                        Operation = "-";
                        break;

                    case "×":
                        Operation = "×";
                        break;

                    case "÷":
                        Operation = "÷";
                        break;

                    case "^":
                        Operation = "^";
                        break;

                    case "√":
                        Operation = "√";
                        break;

                    default:
                        break;
                }

                if (Operation == null)
                {
                    if (CalculatorText.Length == 0)
                    {
                        FirstNumber = Convert.ToInt64(AddCharactersCommand.ParameterValue);
                    }
                    else
                    {
                        FirstNumber = (FirstNumber * 10) + Convert.ToInt64(AddCharactersCommand.ParameterValue);
                    }
                }
                else
                {
                    if (AddCharactersCommand.ParameterValue.Equals(Operation) == false)
                    {
                        if (CalculatorText.Length == 0)
                        {
                            SecondNumber = Convert.ToInt64(AddCharactersCommand.ParameterValue);
                        }
                        else
                        {
                            SecondNumber = (SecondNumber * 10) + Convert.ToInt64(AddCharactersCommand.ParameterValue);
                        }
                    }
                }
            });

            CalculateCommand = new RelayCommand(o =>
            {
                switch (Operation)
                {
                    case "+":
                        Result = CalculatorModel.Add(FirstNumber, SecondNumber).ToString();
                        break;

                    case "-":
                        Result = CalculatorModel.Subtract(FirstNumber, SecondNumber).ToString();
                        break;

                    case "×":
                        Result = CalculatorModel.Mulitply(FirstNumber, SecondNumber).ToString();
                        break;

                    case "÷":
                        Result = CalculatorModel.Divide(FirstNumber, SecondNumber).ToString();
                        break;

                    case "^":
                        Result = Math.Pow(FirstNumber, SecondNumber).ToString();
                        break;

                    case "√":
                        Result = Math.Sqrt(FirstNumber).ToString();
                        break;

                    case null:
                        CalculatorText = "Invalid operation";
                        break;
                }

                FirstNumber = Convert.ToInt64(Result);
                SecondNumber = 0;

            });

            RemoveCharactersCommand = new RelayCommand(o =>
            {
                if (Operation == null)
                {
                    CalculatorText = CalculatorText.Remove(CalculatorText.Length - 1, 1);
                    FirstNumber = Convert.ToInt64(CalculatorText);
                }
                else
                {
                    if (AddCharactersCommand.ParameterValue.ToString() != Operation)
                    {
                        CalculatorText = CalculatorText.Remove(CalculatorText.Length - 1, 1);
                        //SecondNumber = (SecondNumber / 10) - (0,1 * SecondNumber); 
                    }
                }
            });

            AllClearCommand = new RelayCommand(o =>
            {
                FirstNumber = 0;
                SecondNumber = 0;
                Operation = "";
                Result = "";
            });


        }
    }
}
