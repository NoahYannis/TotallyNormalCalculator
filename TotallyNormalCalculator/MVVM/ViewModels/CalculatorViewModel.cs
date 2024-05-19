using System;
using System.Linq;
using System.Windows;
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
        private string firstPart;
        private string secondPart;

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
                bool IsValidInput = charTest.All(x => char.IsDigit(x) || '-' == x || '√' == x);

                if (CalculatorText is "Invalid operation")
                {
                    FirstNumber = 0;
                    SecondNumber = 0;
                    Operation = null;
                    Result = 0;
                    CalculatorText = "";
                    switchViewCounter = 0;
                }

                if (CalculatorText.Length is 0)
                {
                    if (IsValidInput)
                    {
                        CalculatorText = AddCharactersCommand.ParameterValue.ToString();
                    }
                }
                else if (AddCharactersCommand.ParameterValue.ToString() is ".")
                {
                    if (CalculatorText.Contains(".") is false)
                    {
                        CalculatorText += ".";
                    }
                }
                else
                {
                    if (AddCharactersCommand.ParameterValue.ToString() is not "√")
                    {
                        CalculatorText += AddCharactersCommand.ParameterValue.ToString();
                    }
                    else
                    {
                        Operation = null;
                    }
                }


                if (CalculatorText.Length > 1)
                {
                    switch (AddCharactersCommand.ParameterValue)
                    {
                        case "+":
                            Operation = "+";
                            CalculatorText = "";
                            break;

                        case "-":
                            Operation = "-";
                            CalculatorText = "";
                            break;

                        case "×":
                            Operation = "×";
                            CalculatorText = "";
                            break;

                        case "÷":
                            Operation = "÷";
                            CalculatorText = "";
                            break;

                        case "^":
                            Operation = "^";
                            CalculatorText = "";
                            break;

                        default:
                            break;
                    }
                }
                else if (CalculatorText.Length == 1 && AddCharactersCommand.ParameterValue.ToString() is "√")
                {
                    Operation = "√";
                }

                if (Operation is null)
                {
                    if (CalculatorText.Length is 0)
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
                            if (AddCharactersCommand.ParameterValue.ToString() is not "." && CalculatorText.Contains(".") is false && CalculatorText.StartsWith("-") is false)  // whole, not negative number
                            {
                                FirstNumber = (FirstNumber * 10) + Convert.ToInt64(AddCharactersCommand.ParameterValue);
                            }
                            else if (CalculatorText.StartsWith("-"))
                            {
                                FirstNumber = Convert.ToDouble(CalculatorText.Substring(0, CalculatorText.Length));

                                if (CalculatorText.Contains("."))
                                {
                                    firstPart = CalculatorText.Substring(0, CalculatorText.IndexOf("."));
                                    secondPart = CalculatorText.Substring(CalculatorText.IndexOf("."), CalculatorText.Length - CalculatorText.IndexOf("."));

                                    FirstNumber = Convert.ToDouble(firstPart + secondPart);
                                }
                            }
                            else // number is a decimal and is not negative
                            {
                                firstPart = CalculatorText.Substring(0, CalculatorText.IndexOf("."));
                                secondPart = CalculatorText.Substring(CalculatorText.IndexOf("."), CalculatorText.Length - CalculatorText.IndexOf("."));

                                FirstNumber = Convert.ToDouble(firstPart + secondPart);
                            }
                        }
                        catch (Exception)
                        {
                            FirstNumber = 0;
                        }
                    }
                }
                else // operation not null -> second number
                {
                    if (CalculatorText.Length is 0)
                    {
                        try
                        {
                            SecondNumber = Convert.ToInt64(AddCharactersCommand.ParameterValue);
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
                            if (AddCharactersCommand.ParameterValue.ToString() is not "." && CalculatorText.Contains(".") is false && CalculatorText.StartsWith("-") is false)
                            {
                                SecondNumber = (SecondNumber * 10) + Convert.ToInt64(AddCharactersCommand.ParameterValue);
                            }
                            else if (CalculatorText.StartsWith("-"))
                            {
                                SecondNumber = Convert.ToDouble(CalculatorText.Substring(0, CalculatorText.Length));

                                if (CalculatorText.Contains("."))
                                {
                                    firstPart = CalculatorText.Substring(0, CalculatorText.IndexOf("."));
                                    secondPart = CalculatorText.Substring(CalculatorText.IndexOf("."), CalculatorText.Length - CalculatorText.IndexOf("."));

                                    SecondNumber = Convert.ToDouble(firstPart + secondPart);
                                }
                            }
                            else
                            {
                                firstPart = CalculatorText.Substring(0, CalculatorText.IndexOf("."));
                                secondPart = CalculatorText.Substring(CalculatorText.IndexOf("."), CalculatorText.Length - CalculatorText.IndexOf("."));

                                SecondNumber = Convert.ToDouble(firstPart + secondPart);
                            }
                        }
                        catch (Exception)
                        {
                            SecondNumber = 0;
                        }
                    }
                }
            });

            RemoveCharactersCommand = new RelayCommand(o =>
            {
                try
                {
                    CalculatorText = CalculatorText.Remove(CalculatorText.Length - 1, 1);

                    if (Operation is null) // It's still the first Number
                    {
                        FirstNumber = Convert.ToDouble(CalculatorText);
                    }
                    else
                    {
                        SecondNumber = Convert.ToDouble(CalculatorText);
                    }
                }
                catch (Exception)
                {

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
                        Result = Math.Sqrt(SecondNumber);
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
                Operation = null;
                switchViewCounter = 0;

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
