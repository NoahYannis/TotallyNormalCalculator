using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotallyNormalCalculator.MVVM.Model;

namespace TotallyNormalCalculator.Core
{
    public class DataAccess
    {
        public void InsertDiaryEntry(string title, string message, string date)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DiaryEntryDB")))
            {
                ObservableCollection<DiaryEntryModel> Entries = new();
                Entries.Add(new DiaryEntryModel { Title = title, Message = message, Date = date });
                connection.Execute("dbo.spInsertDiaryEntry @Title, @Message, @Date", Entries);
            }
        }
    }
}
