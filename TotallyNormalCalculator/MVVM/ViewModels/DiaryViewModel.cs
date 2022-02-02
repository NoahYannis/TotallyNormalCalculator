using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TotallyNormalCalculator.Core;
using TotallyNormalCalculator.MVVM.Model;

namespace TotallyNormalCalculator.MVVM.ViewModels
{ 
    public class DiaryViewModel : ObservableClass
    {

        public ObservableCollection<DiaryEntryModel> Entries { get; set; }
        public RelayCommand SendCommand { get; set; }

        private DiaryEntryModel _selectedEntry;

        public DiaryEntryModel SelectedEntry
        {
            
            get { return _selectedEntry; }
            set 
            {
                _selectedEntry = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set 
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set 
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public DiaryViewModel()
        {
                
            Entries = new ObservableCollection<DiaryEntryModel>();

            SendCommand = new RelayCommand(o =>
            {
                Entries.Add(new DiaryEntryModel
                {
                    Title = Title,
                    Message = Message,
                    Date = Date

                });

          

            });
            

            


        }

    }
}
