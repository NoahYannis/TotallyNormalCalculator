using System;
using System.Windows;
using System.Linq;
using TotallyNormalCalculator.Core;

namespace TotallyNormalCalculator.MVVM.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        public RelayCommand SwitchViewCommand { get; set; }
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand MaximizeCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand AddCharactersCommand { get; set; }
        public RelayCommand RemoveCharactersCommand { get; set; }
        public RelayCommand CalculateCommand { get; set; }
        public RelayCommand AllClearCommand { get; set; }
       
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

        private string _calculatorText = "";
        public string CalculatorText
        {
            get { return _calculatorText; }
            set 
            {
                _calculatorText = value;
                OnPropertyChanged(nameof(CalculatorText));
            }
        }

        private double _firstNumber;
        public double FirstNumber
        {
            get { return _firstNumber; }
            set 
            {
                _firstNumber = value;
                OnPropertyChanged(nameof(FirstNumber));
            }
        }

        private double _secondNumber;
        public double SecondNumber
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

        private double _result;
        public double Result
        {
            get { return _result; }
            set 
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
                CalculatorText = Result.ToString();
            }
        }

        private int switchViewCounter;


        public CalculatorViewModel()
        {

            SwitchViewCommand = new RelayCommand(o =>
            {
                switchViewCounter++;

                if (switchViewCounter == 4)
                {
                    SelectedViewModel = new DiaryViewModel();
                    switchViewCounter = 0;
                }
            });

            MinimizeCommand = new RelayCommand(o =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            MaximizeCommand = new RelayCommand(o =>
            {
                if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                }
                else
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                }
            });

            CloseWindowCommand = new RelayCommand(o =>
            {
                Application.Current.Shutdown();
            });

            AddCharactersCommand = new RelayCommand(o =>
            {
                string charTest = AddCharactersCommand.ParameterValue.ToString();
                bool IsValidInput = charTest.All(x => char.IsDigit(x) || '-' == x);

                if (CalculatorText.Length == 0)
                {
                    if (IsValidInput)
                    {
                        CalculatorText = AddCharactersCommand.ParameterValue.ToString();
                    }           
                }
                else
                {
                    IsValidInput = charTest.All(x => char.IsDigit(x) || '.' == x || '-' == x);

                    if (Operation == null)
                    {
                        CalculatorText += AddCharactersCommand.ParameterValue;
                    }
                    else
                    {
                        if (IsValidInput)
                        {
                            CalculatorText += AddCharactersCommand.ParameterValue;
                        }
                    }
                }
                
                
                if (CalculatorText.Length > 1)
                {
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
                }

                if (Operation == null)
                {
                    if (CalculatorText.Length == 0)
                    {
                        try
                        {
                            FirstNumber = Convert.ToInt64(AddCharactersCommand.ParameterValue);
                        }
                        catch (Exception)
                        {
                            FirstNumber = 0;
                        }
                    }
                    else
                    {
                        try
                        {
                            FirstNumber = (FirstNumber * 10) + Convert.ToInt64(AddCharactersCommand.ParameterValue);
                        }
                        catch (Exception)
                        {
                            FirstNumber = 0;
                        }
                    }
                }
                else
                {
                    if (CalculatorText.Length == 0)
                    {
                        try
                        {
                            if (!CalculatorText.StartsWith("-"))
                            {
                                SecondNumber = Convert.ToInt64(AddCharactersCommand.ParameterValue);
                            }
                            else
                            {
                                SecondNumber = Convert.ToInt64(AddCharactersCommand.ParameterValue) * (-1);
                            }
                        }
                        catch (Exception)
                        {
                            SecondNumber = 0;
                        }         
                    }
                    else
                    {
                        try
                        {
                            SecondNumber = (SecondNumber * 10) + Convert.ToInt64(AddCharactersCommand.ParameterValue);
                        }
                        catch (Exception)
                        {
                            SecondNumber = 0;
                        }         
                    }
                }
            });

            CalculateCommand = new RelayCommand(o =>
            {
                switch (Operation)
                {
                    case "+":
                        Result = CalculatorModel.Add(FirstNumber, SecondNumber);
                        break;

                    case "-":
                        Result = CalculatorModel.Subtract(FirstNumber, SecondNumber);
                        break;

                    case "×":
                        Result = CalculatorModel.Mulitply(FirstNumber, SecondNumber);
                        break;

                    case "÷":
                        Result = CalculatorModel.Divide(FirstNumber, SecondNumber);
                        break;

                    case "^":
                        Result = Math.Pow(FirstNumber, SecondNumber);
                        break;

                    case "√":
                        Result = Math.Sqrt(FirstNumber);
                        break;

                    case null:
                        CalculatorText = "Invalid operation";
                        break;
                }

                try
                {
                    FirstNumber = Convert.ToDouble(Result);
                }
                catch (Exception)
                {
                    FirstNumber = 0;
                    Result = 0;
                }     
                
                SecondNumber = 0;
                switchViewCounter = 0;

            });

            RemoveCharactersCommand = new RelayCommand(o =>
            {
                try
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
                            SecondNumber = (SecondNumber / 10) - ((long)0.1 * SecondNumber);
                        }
                    }
                }
                catch (Exception)
                {
                    CalculatorText = "";
                }
            });

            AllClearCommand = new RelayCommand(o =>
            {
                FirstNumber = 0;
                SecondNumber = 0;
                Operation = null;
                Result = 0;
                CalculatorText = "";
                switchViewCounter = 0;
            });
        }
    }
}
