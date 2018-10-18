using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWPF
{
    public class Employee : ICloneable, INotifyPropertyChanged
    {
        int id;
        string name;
        int age;
        int salary;
        int departmentId;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set { name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name))); } }
        public int Age { get => age; set { age = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Age))); } }
        public int Salary { get => salary; set { salary = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Salary))); } }
        public int? DepartmentID { get => departmentId;
            set { departmentId = (int)value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DepartmentID))); } }

        public Employee()
        {
            
        }

        public Employee(string name, int age, int salary, int dep)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;
            this.DepartmentID = dep;
        }

        public object Clone()
        {
            Employee tmp = new Employee
            {
                id = this.id,
                name = this.name,
                salary = this.salary,
                departmentId = this.departmentId
            };
            return tmp;
        }
    }
}