using EmployeeWPF;
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

namespace EmployeeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IEmpDep
    {
        Presenter presenter;

        public ObservableCollection<Employee> Emps
        {
            get => (lv_employees.ItemsSource as ObservableCollection<Employee>);
            set => lv_employees.ItemsSource = value;
        }
        public ObservableCollection<Department> Deps
        {
            get => (cmbx_departments.ItemsSource as ObservableCollection<Department>);
            set => cmbx_departments.ItemsSource = value;
        }

        public MainWindow()
        {
            InitializeComponent();

            presenter = new Presenter(this);

            cmbx_departments.SelectionChanged += (s, e) => { presenter.GetEmpsByDep((e.AddedItems[0] as Department).Id); };

            //Добавление департамента
            btn_AddDep.Click += delegate {
                Department dep = new Department();
                EditDep ed = new EditDep(dep);
                if ((bool)ed.ShowDialog())
                {
                    presenter.AddDep(dep);
                }
                else
                    dep = null;
            };

            //Добавление сотрудника
            btn_AddEmp.Click += delegate {
                Employee emp = new Employee();
                EditEmp em = new EditEmp(emp, (cmbx_departments.ItemsSource as IEnumerable<Department>));
                if ((bool)em.ShowDialog())
                {
                    presenter.AddEmp(emp);
                }
                else
                    emp = null;
            };

            //Изменение департамента
            btn_ChDep.Click += delegate {
                Department dep = new Department
                {
                    Id = (cmbx_departments.SelectedItem as Department).Id,
                    Name = (cmbx_departments.SelectedItem as Department).Name
                };
                EditDep ed = new EditDep(dep);
                if ((bool)ed.ShowDialog())
                {
                    presenter.ChangeDep(dep);
                }
            };

            //Изменение сотрудника
            btn_ChEmp.Click += delegate {
                Employee emp = new Employee
                {
                    Id = (lv_employees.SelectedItem as Employee).Id,
                    Name = (lv_employees.SelectedItem as Employee).Name,
                     Age = (lv_employees.SelectedItem as Employee).Age,
                    Salary = (lv_employees.SelectedItem as Employee).Salary,
                    DepartmentID = (lv_employees.SelectedItem as Employee).DepartmentID,
                };
                EditEmp em = new EditEmp(emp, (cmbx_departments.ItemsSource as IEnumerable<Department>));
                if ((bool)em.ShowDialog())
                {
                    presenter.ChangeEmp(emp);
                }
                else
                    emp = null;
            };

            //Удаление департамента
            btn_DelDep.Click += delegate { presenter.DelDep((cmbx_departments.SelectedItem as Department).Id); };
            //Удаление сотрудника
            btn_DelEmp.Click += delegate { presenter.DelEmp((lv_employees.SelectedItem as Employee).Id); };
        }
    }
}