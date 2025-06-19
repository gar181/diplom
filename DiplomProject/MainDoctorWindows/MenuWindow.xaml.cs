using DiplomProject.Classes;
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

namespace DiplomProject.MainDoctorWindows
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        EmployeeClass employeeClass;
        public MenuWindow(EmployeeClass e)
        {
            InitializeComponent();
            employeeClass = e;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagmentEmployeeWindow window = new ManagmentEmployeeWindow(employeeClass);
            window.Show();  
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {   
            TimetableWindow window = new TimetableWindow(employeeClass);
            window.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ReportWindow window = new ReportWindow(employeeClass);
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
