using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWPF
{
    interface IEmpDep
    {
        ObservableCollection<Employee> Emps { get; set; }
        ObservableCollection<Department> Deps { get; set; }
    }
}
