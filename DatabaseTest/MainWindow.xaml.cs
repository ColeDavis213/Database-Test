using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            InitializeComponent();

            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/DataBaseTest.accdb");
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {

            string query = "select* from Employees";

            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();

            string employeeData = "";

            while (read.Read())
            {
                employeeData += "EmployeeID: " + read["EmployeeID"].ToString()
                    + " | Last Name: " + read["LastName"].ToString()
                    + " | First Name: " + read["FirstName"].ToString() + "\n";
            }

            EmployeeData.Text = employeeData;

            cn.Close();

        }

        private void Assets_Click(object sender, RoutedEventArgs e)
        {

            string  query = "select* from Assets";

            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();

            string assetData = "";

            while(read.Read())
            {
                assetData += "EmployeeID: " + read["EmployeeID"].ToString() 
                    + " | AssetID: " + read["AssetID"].ToString() 
                    + " | Description: " + read["Description"].ToString() + "\n";
            }

            AssetData.Text = assetData;

            cn.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int employeeIDInput = System.Convert.ToInt32(EmployeeIDText.Text);
            string lastNameInput = LastNameText.Text;
            string firstNameInput = FirstNameText.Text;


            OleDbCommand cmd = cn.CreateCommand();
            string text = "INSERT INTO EMPLOYEES (EmployeeID, LastName, FirstName) VALUES (@EmployeeID, @LastName, @FirstName)";
            cmd.CommandText = text;

            cn.Open();
            cmd.Parameters.AddWithValue("@EmployeeID", employeeIDInput);
            cmd.Parameters.AddWithValue("@LastName", lastNameInput);
            cmd.Parameters.AddWithValue("@FirstName", firstNameInput);

            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void Add_Asset(object sender, RoutedEventArgs e)
        {
            int employeeIDInput = System.Convert.ToInt32(EmployeeIDText2.Text);
            int assetIDinput = System.Convert.ToInt32(AssetIdText.Text);
            string descriptionInput = DescriptionText.Text;


            OleDbCommand cmd = cn.CreateCommand();
            string text = "INSERT INTO ASSETS (EmployeeID, AssetID, Description) VALUES (@EmployeeID, @AssetID, @Description)";
            cmd.CommandText = text;

            cn.Open();
            cmd.Parameters.AddWithValue("@EmployeeID", employeeIDInput);
            cmd.Parameters.AddWithValue("@AssetID", assetIDinput);
            cmd.Parameters.AddWithValue("@FirstName", descriptionInput);

            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }

}
