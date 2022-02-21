using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TotallyNormalCalculator.MVVM.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));  
        }

        protected void OnPropertyChanged(BaseViewModel baseViewModel)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(baseViewModel.ToString()));
        }
    }
}
