using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotallyNormalCalculator.Core;

namespace TotallyNormalCalculator.MVVM.Model
{
    public class DiaryEntryModel : ObservableClass
    {
      public string Title { get; set; }
      public string Message { get; set; }
      public string Date { get; set; } 
     
    }

    
}
