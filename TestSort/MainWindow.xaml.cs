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

namespace TestSort
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<int> db = new ObservableCollection<int>();

        public MainWindow()
        {
            InitializeComponent();
            lb.ItemsSource = db;
            Random c = new Random();
            addBtn.Click += delegate
            {
                for (int i = 0; i < 200; i++)
                {
                    db.Add(c.Next(0, 1000));
                }
            };
            sortBtn.Click += delegate { sort(); };
        }

        private async void sort()
        {
            for (int i = 0; i < db.Count - 1; i++)
            {
                int t = i;
                for (int j = i; j < db.Count; j++)
                {
                    if (db[j] > db[t]) t = j;
                }
                await Task.Delay(30);
                int temp = db[i];
                db[i] = db[t];
                db[t] = temp;
            }
        }
    }
}
