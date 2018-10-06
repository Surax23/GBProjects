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
    /// Логика взаимодействия для EditDep.xaml
    /// </summary>
    public partial class EditDep : Window
    {
        public EditDep(Department e)
        {
            InitializeComponent();
            tb_Name.DataContext = e;
        }
    }
}
