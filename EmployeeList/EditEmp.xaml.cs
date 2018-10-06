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

namespace EmployeeList
{
    /// <summary>
    /// Логика взаимодействия для EditEmp.xaml
    /// </summary>
    public partial class EditEmp : Window
    {
        public EditEmp(Employee e)
        {
            InitializeComponent();
            grid.DataContext = e;
        }
    }
}
