using System;
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TotallyNormalCalculator.Core
{
    public class DbClass
    {
        public static string GetConnectionStrings()
        {
            string strConString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            return strConString;
        }

        public static string sql;
        public static SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\USER\SOURCE\REPOS\TOTALLYNORMALCALCULATOR\TOTALLYNORMALCALCULATOR\DIARYENTRYDB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static DataSet ds;
        public static SqlCommand cmd = new("", sqlConnection);
        public static SqlDataReader rd;
        public static DataTable dt;
        public static SqlDataAdapter da;
        public static BindingSource bs;

        public static void OpenConnection()
        {
            //try
            //{
            //    if (sqlConnection.State is ConnectionState.Closed)
            //    {
            //        sqlConnection.Open();
            //        MessageBox.Show("The connection is " + sqlConnection.State.ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Open connection failed " + ex.Message);
            //}
        }

        public static void CloseConnection()
        {
            //try
            //{
            //    if (sqlConnection.State is ConnectionState.Open)
            //    {
            //        sqlConnection.Close();
            //        MessageBox.Show("The connection is " + sqlConnection.State.ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Close connection error " + ex.Message);
            //}
        }
    }
}   
