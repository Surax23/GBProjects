using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Department> dep_list;
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Skola121\source\repos\GBProjects\EmployeeList\MSSQLLocalDB.mdf;Integrated Security=True;Connect Timeout=30

        public MainWindow()
        {
            InitializeComponent();
            dep_list = new ObservableCollection<Department>();
            dep_list.Add(new Department("Строители"));
            dep_list.Add(new Department("Менеджеры"));
            dep_list.Add(new Department("Управление"));

            Random c = new Random();
            foreach (Department dp in dep_list)
            {
                int k = c.Next(5, 11);
                for (int i = 0; i < k; i++)
                {
                    dp.Collection.Add(new Employee("Имя " + i, c.Next(18, 60), c.Next(45, 65) * 1000));
                }
            }

            cmbx_departments.ItemsSource = dep_list;

            Model model = new Model();

            cmbx_departments.SelectionChanged += Selection_Changed;
            btnAddDep.Click += DepAdd;
            btnEditDep.Click += DepEdit;

            btnEditEmp.Click += EmpEdit;
            btnAddEmp.Click += EmpAdd;
        }

        /// <summary>
        /// Добавление работника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpAdd(object sender, RoutedEventArgs e)
        {
            (cmbx_departments.SelectedItem as Department).Collection.Add(new Employee());
            lv_employees.SelectedIndex = lv_employees.Items.Count - 1;
            new EditEmp(lv_employees.SelectedItem as Employee).ShowDialog();
        }

        /// <summary>
        /// Редактирование работника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpEdit(object sender, RoutedEventArgs e)
        {
            if (lv_employees.SelectedItem != null)
                new EditEmp(lv_employees.SelectedItem as Employee).ShowDialog();
        }

        /// <summary>
        /// Добавление депратамента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepAdd(object sender, RoutedEventArgs e)
        {
            dep_list.Add(new Department(string.Empty));
            cmbx_departments.SelectedIndex = cmbx_departments.Items.Count - 1;
            new EditDep(cmbx_departments.SelectedItem as Department).ShowDialog();
        }

        /// <summary>
        /// Редактирование департамента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepEdit(object sender, RoutedEventArgs e)
        {
            if (cmbx_departments.SelectedItem != null)
            {
                new EditDep(cmbx_departments.SelectedItem as Department).ShowDialog();
            }
        }

        /// <summary>
        /// Выбор департамента из комбобокса и загрузка коллекции департамента в листвью.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            lv_employees.ItemsSource = (e.AddedItems[0] as Department).Collection;
        }
    }
}