using System.Windows;
using TotallyNormalCalculator.Core;
using static TotallyNormalCalculator.Core.DbClass;

namespace TotallyNormalCalculator.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                
            DbClass.OpenConnection();
            DbClass.CloseConnection();
        }
    }
}
