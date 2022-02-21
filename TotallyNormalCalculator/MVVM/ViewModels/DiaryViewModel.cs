using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotallyNormalCalculator.Core;
using TotallyNormalCalculator.MVVM.Model;


namespace TotallyNormalCalculator.MVVM.ViewModels
{ 
    public class DiaryViewModel : BaseViewModel
    {
        public ObservableCollection<DiaryEntryModel> Entries { get; set; }
        public RelayCommand AddEntryCommand { get; set; }
        public RelayCommand ReadEntryCommand { get; set; }
        public RelayCommand DeleteEntryCommand { get; set; }
 

        private DiaryEntryModel _selectedEntry;

        public DiaryEntryModel SelectedEntry
        {
            
            get { return _selectedEntry; }
            set 
            {
                _selectedEntry = value;
                OnPropertyChanged(nameof(SelectedEntry));
            }
        }

        private string _message;

        public string Message
        {
            
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(_message);
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(_title);
            }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set 
            {
                _date = value;
                OnPropertyChanged(_date);
            }
        }

        public DiaryViewModel()
        {

           Entries = new ObservableCollection<DiaryEntryModel>();

           AddEntryCommand = new RelayCommand(o =>
           {
                Entries.Add(new DiaryEntryModel 
                {
                    Title = Title,
                    Message = Message,
                    Date = Date
                });

                Title = "";
                Message = "";
                Date = "";


           });

            ReadEntryCommand = new RelayCommand(o =>
            {
                if (Entries.Count > 0)
                {
                    if (SelectedEntry != null)
                    {
                        Title = SelectedEntry.Title;
                        Message = SelectedEntry.Message;
                        Date = SelectedEntry.Date; 
                    }
                    else
                    {
                        MessageBox.Show("Please select an entry to read.", "TotallyNormalCalculator", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    var result = MessageBox.Show("There is no entry to read. You should create one!", "TotallyNormalCalculator", MessageBoxButton.YesNo, MessageBoxImage.Information);

                    if (result == MessageBoxResult.No)
                    {
                        MessageBox.Show(":(");
                    }
                }

            });

            DeleteEntryCommand = new RelayCommand(o =>
            {

                if (Entries.Count > 0)
                {   
                    var wantsToDeleteEntry = MessageBox.Show("Do you want to permanently delete this entry?", "TotallyNormalCalculator", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (wantsToDeleteEntry == MessageBoxResult.Yes)
                    {
                        if (SelectedEntry != null)
                        {
                            Entries.Remove(SelectedEntry);

                            Title = "";
                            Message = "";
                            Date = "";
                        }
                        else
                        {
                            MessageBox.Show("Please select an entry to delete.", "TotallyNormalCalculator", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }        
                }
                else
                {
                    MessageBox.Show("There is no entry to delete.", "TotallyNormalCalculator", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            });

           

            for (int i = 0; i < 10 ; i++)
            {
                Entries.Add(new DiaryEntryModel
                {
                    Title = "Test",
                    Message = "Test",
                    Date = "Test"
                });
            }
        }
    }
}
