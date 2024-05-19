using TotallyNormalCalculator.MVVM.ViewModels;

namespace TotallyNormalCalculator.MVVM.Model
{
    public class DiaryEntryModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }

    }
}
