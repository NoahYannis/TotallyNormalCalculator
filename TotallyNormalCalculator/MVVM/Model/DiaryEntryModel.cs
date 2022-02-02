using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotallyNormalCalculator.Core;

namespace TotallyNormalCalculator.MVVM.Model
{
    public class DiaryEntryModel
    {
      public string Title { get; set; }
      public string Message { get; set; }
      public DateTime Date { get; set; }
     
    }
}
