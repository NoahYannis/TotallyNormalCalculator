

namespace TotallyNormalCalculator.MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel = new CalculatorViewModel();
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
        }
        
        public MainViewModel()
        {

        }
    }
}
