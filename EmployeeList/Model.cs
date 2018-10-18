using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeList
{
    class Model : IDisposable
    {
        #region Данные
        //AttachDbFilename=C:\Users\Skola121\source\repos\GBProjects\EmployeeList\MSSQLLocalDB.mdf;
        //Initial Catalog = Lesson7;
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                    AttachDbFilename=C:\Users\Skola121\source\repos\GBProjects\EmployeeList\MSSQLLocalDB.mdf;
                                    Integrated Security=True;
                                    Pooling=false";
        private SqlConnection connection;
        private ObservableCollection<Department> dep_list;
        private SqlDataReader sqlData;

        public ObservableCollection<Department> Departments { get => dep_list;  set => dep_list = value; }
        #endregion

        public Model()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                dep_list = new ObservableCollection<Department>();
                connection.Open();
                for (int i = 0; i < 3; i++)
                {
                    string com = $@"INSERT INTO Department VALUES (, N'Деп{i}');";
                    SqlCommand cmd = new SqlCommand(com, connection);
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ObservableCollection<Department> LoadData()
        {

            return null;
        }

        public void Dispose()
        {
            connection?.Close();
        }
    }
}