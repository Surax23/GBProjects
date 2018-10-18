using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EmployeeWPF
{
    public class Department : INotifyPropertyChanged
    {
        int id;
        string name;

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

        public int Id { get => id; set => id = value; }
    }
}