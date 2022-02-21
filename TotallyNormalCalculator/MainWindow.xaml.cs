using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TotallyNormalCalculator.MVVM;
using TotallyNormalCalculator.MVVM.Model;
using TotallyNormalCalculator.MVVM.ViewModels;

namespace TotallyNormalCalculator
{
    //public enum Operation { Null, Addition, Subtraction, Multiplication, Division, Power }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        long firstNumber = 0, secondNumber = 0, result = 0;
        string operation, oldLabel, newLabel;




        private void ObereLeiste_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimieren_MouseDown(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void btnMaximieren_MouseDown(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void btnSchließen_MouseDown(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAc_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            operation = null;
        }


        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(7);
        }
      
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(8);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(9);
        }

       
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(4);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(5);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(6);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(1);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(2);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(3);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            DisplayNumber(0);
        }




        // Operations
        


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            operation = "+";
        }

        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
            operation = "-";
        }


        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            operation = "*";
        }


        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            operation = "/";
        }


        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (!newLabel.Contains("."))
            {
               
            }
        }

        private void btnPower_Click(object sender, RoutedEventArgs e)
        {
            operation = "pow";
        }

        private void ViewModelDiary_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DiaryViewModel();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            oldLabel = (string)lblResult.Content;
            newLabel = oldLabel.Remove(oldLabel.Length - 1, 1);
            lblResult.Content = newLabel;

            if (operation == null)
            {
                firstNumber = int.Parse(newLabel);
                lblResult.Content = firstNumber.ToString();
            }
            else
            {
                secondNumber = int.Parse(newLabel);
                lblResult.Content = secondNumber.ToString();
            }
        }



        private void btnSquareroot_Click(object sender, RoutedEventArgs e)
        {
            operation = "sqrt";
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                   result = CalculatorModel.Add(firstNumber, secondNumber);
                    break;

                case "-":
                    result = CalculatorModel.Subtract(firstNumber, secondNumber);
                    break;

                case "*":
                    result = CalculatorModel.Mulitply(firstNumber, secondNumber);
                    break;

                case "/":
                    result = (long)CalculatorModel.Divide(firstNumber, secondNumber);
                    break;

                case "pow":
                    result = (long)System.Math.Pow(firstNumber, secondNumber);
                    break;

                case "sqrt":
                    result = (long)System.Math.Sqrt(firstNumber);
                    break;

                case null:
                    lblResult.Content = "Invalid operation";
                    break;
            }
            lblResult.Content = result.ToString();
        }


        private void DisplayNumber(long number)
        {
            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = "";
                lblResult.Content += number.ToString();
                firstNumber += number;
            }
            else if (lblResult.Content.ToString() != "0")
            {
                if (operation == null)
                {
                    firstNumber = (firstNumber * 10) + number;
                    lblResult.Content = firstNumber.ToString();
                }
                else
                {
                    secondNumber = (secondNumber * 10) + number;
                    lblResult.Content = secondNumber.ToString();
                }   
            }
        }
    }
}
