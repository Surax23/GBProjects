using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EmployeeList
{
    public class Department : INotifyPropertyChanged
    {
        string name;
        ObservableCollection<Employee> collection;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }
        public ObservableCollection<Employee> Collection { get => collection; set => collection = value; }

        public Department(string name)
        {
            collection = new ObservableCollection<Employee>();
            this.name = name;
        }
    }
}