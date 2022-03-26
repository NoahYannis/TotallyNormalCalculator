using System.Collections.ObjectModel;
using System.Windows;
using TotallyNormalCalculator.Core;
using TotallyNormalCalculator.MVVM.Model;


namespace TotallyNormalCalculator.MVVM.ViewModels
{
    public class DiaryViewModel : BaseViewModel
    {
        public ObservableCollection<DiaryEntryModel> Entries { get; set; }
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand MaximizeCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand AddEntryCommand { get; set; }
        public RelayCommand ReadEntryCommand { get; set; }
        public RelayCommand DeleteEntryCommand { get; set; }
        public RelayCommand SwitchViewCommand { get; set; }

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
                OnPropertyChanged(nameof(Message));
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set 
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

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

        public DiaryViewModel()
        {
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
                    if (SelectedEntry is not null)  // user has selected an entry
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
                if (Entries.Count > 0) // if there is an entry to delete
                {
                    var wantsToDeleteEntry = MessageBox.Show("Do you want to permanently delete this entry?", "TotallyNormalCalculator", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (wantsToDeleteEntry == MessageBoxResult.Yes)
                    {
                        if (SelectedEntry is not null) // user has selected an entry to delete
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

           SwitchViewCommand = new RelayCommand(o =>
           {
               SelectedViewModel = new CalculatorViewModel();
           });
        }
    }
}
