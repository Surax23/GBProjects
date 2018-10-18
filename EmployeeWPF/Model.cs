using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmployeeWPF
{
    class Model
    {
        private List<Department> dep_list;
        private List<Employee> emp_list;
        
        

        readonly HttpClient client;
        readonly string url = @"http://localhost:53551/";
        readonly string get = "get";
        readonly string add = "add";
        readonly string change = "change";
        readonly string delete = "del";
        readonly string employee = "emps";
        readonly string department = "deps";
        // ^___^
        // Надеюсь, все понятно.

        public List<Department> Departments { get => dep_list; set => dep_list = value; }
        public List<Employee> Employees { get => emp_list; set => emp_list = value; }

        public Model()
        {
            client = new HttpClient();
            dep_list = GetDepartments();
            emp_list = GetEmployees();
        }

        /// <summary>
        /// Получение списка сотрудников.
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            return JsonConvert.DeserializeObject<List<Employee>>(client.GetStringAsync($"{url}{get}{employee}").Result);
        }

        /// <summary>
        /// Получение списка департаментов.
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments()
        {
            return JsonConvert.DeserializeObject<List<Department>>(client.GetStringAsync($"{url}{get}{department}").Result); 
        }

        /// <summary>
        /// Получение сотрудника по ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployee(int id)
        {
            return JsonConvert.DeserializeObject<Employee>(client.GetStringAsync($"{url}{get}{employee}/{id}").Result);
        }

        /// <summary>
        /// Получение департамента по ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetDepartment(int id)
        {
            return JsonConvert.DeserializeObject<Department>(client.GetStringAsync($"{url}{get}{department}/{id}").Result);
        }

        /// <summary>
        /// Добавление сотрудника в сервис.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public bool AddEmployee(Employee emp)
        {
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(emp),
                Encoding.UTF8,
                "application/json");
            if (client.PostAsync($"{url}{add}{employee}", content).Result.IsSuccessStatusCode == true)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Добавление департамента в сервис.
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        public bool AddDepartment(Department dep)
        {
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(dep),
                Encoding.UTF8,
                "application/json");
            if (client.PostAsync($"{url}{add}{department}", content).Result.IsSuccessStatusCode == true)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Изменение сотрудника в сервисе.
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public bool ChangeEmployee(Employee emp)
        {
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(emp),
                Encoding.UTF8,
                "application/json");
            if (client.PostAsync($"{url}{change}{employee}", content).Result.IsSuccessStatusCode == true)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Изменение департамента в сервисе.
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        public bool ChangeDepartment(Department dep)
        {
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(dep),
                Encoding.UTF8,
                "application/json");
            if (client.PostAsync($"{url}{change}{department}", content).Result.IsSuccessStatusCode == true)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Удаление сотрудника из сервиса.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelEmployee(int id)
        {
            if (client.DeleteAsync($"{url}{delete}{employee}/{id}").Result.IsSuccessStatusCode == true)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Удаление департамента из сервиса.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelDepartment(int id)
        {
            if (client.DeleteAsync($"{url}{delete}{department}/{id}").Result.IsSuccessStatusCode == true)
                return true;
            else
                return false;
        }
    }
}