using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeWPF
{
    class Presenter
    {
        Model model;
        IEmpDep empDep;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="view">Форма-наследник от IEmpDep.</param>
        public Presenter(IEmpDep view)
        {
            try
            {
                model = new Model();
                empDep = view;
                empDep.Emps = new ObservableCollection<Employee>(model.Employees);
                empDep.Deps = new ObservableCollection<Department>(model.Departments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Получает список сотрудников по идентификатору департамента.
        /// </summary>
        /// <param name="id">Идентификатор департамента.</param>
        public void GetEmpsByDep(int id)
        {
            empDep.Emps = new ObservableCollection<Employee>((from emp in model.GetEmployees()
                                                              where emp.DepartmentID == id
                                                              select emp).ToList());
        }

        /// <summary>
        /// Добавление департамента.
        /// </summary>
        /// <param name="dep">Новый департамент.</param>
        /// <returns></returns>
        public void AddDep(Department dep)
        {
            try
            {
                model.AddDepartment(dep);
                empDep.Deps = new ObservableCollection<Department>(model.GetDepartments());
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Добавление сотрудника.
        /// </summary>
        /// <param name="emp">Новый сотрудник.</param>
        public void AddEmp(Employee emp)
        {
            try
            {
                model.AddEmployee(emp);
                empDep.Emps = new ObservableCollection<Employee>(model.GetEmployees());
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Изменение департамента.
        /// </summary>
        /// <param name="dep">Некоторый департамент.</param>
        public void ChangeDep(Department dep)
        {
            try
            {
                model.ChangeDepartment(dep);
                empDep.Deps = new ObservableCollection<Department>(model.GetDepartments());
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Изменение сотрудника.
        /// </summary>
        /// <param name="emp">Некоторый сотрудник.</param>
        public void ChangeEmp(Employee emp)
        {
            try
            {
                model.ChangeEmployee(emp);
                empDep.Emps = new ObservableCollection<Employee>(model.GetEmployees());
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void DelDep(int id)
        {
            try
            {
                model.DelDepartment(id);
                empDep.Deps = new ObservableCollection<Department>(model.GetDepartments());
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void DelEmp(int id)
        {
            try
            {
                model.DelEmployee(id);
                empDep.Emps = new ObservableCollection<Employee>(model.GetEmployees());
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }
}