using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace EmployeeWPF
{
    /// <summary>
    /// Логика взаимодействия для EditEmp.xaml
    /// </summary>
    public partial class EditEmp : Window
    {
        public EditEmp(Employee e, IEnumerable<Department> list)
        {
            InitializeComponent();
            grid.DataContext = e;
            cmbx_departments.ItemsSource = list;
            //MessageBox.Show(e.DepartmentID.ToString());
            cmbx_departments.SelectedItem = (cmbx_departments.ItemsSource as IEnumerable<Department>)
                                            .Where(dep => dep.Id == e.DepartmentID)
                                            .First();

            btn_ok.Click += delegate
            {
                e.DepartmentID = (cmbx_departments.SelectedItem as Department).Id;
                this.DialogResult = true;
            };
            btn_cancel.Click += delegate { this.DialogResult = false; };
        }
    }
}
