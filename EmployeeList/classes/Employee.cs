using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList
{
    public class Employee : ICloneable
    {
        string name;
        int age;
        int salary;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int Salary { get => salary; set => salary = value; }

        public Employee()
        {
            
        }

        public Employee(string name, int age, int salary)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;
        }

        public object Clone()
        {
            Employee tmp = new Employee();
            tmp.name = this.name;
            tmp.salary = this.salary;
            return tmp;
        }
    }
}