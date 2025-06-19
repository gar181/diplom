using DiplomProject.Classes;
using Npgsql;
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
using System.Windows.Shapes;

namespace DiplomProject.MainDoctorWindows
{
    /// <summary>
    /// Логика взаимодействия для ManagmentEmployeeWindow.xaml
    /// </summary>
    public partial class ManagmentEmployeeWindow : Window
    {
        public NpgsqlConnection con;
        EmployeeClass employeeClass;
        public ObservableCollection<EmployeeClass> employeesItem { get; set; }
        public ManagmentEmployeeWindow(EmployeeClass e)
        {
            InitializeComponent();
            ConnectionClass x = new ConnectionClass();
            con = x.con;
            employeeClass = e;
            TextBox_TextChanged(null,null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new MenuWindow(employeeClass);
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string text = text_txb.Text;
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT employees.id, employees.first_name, employees.last_name, employees.patronymic, employees.serial_passport, employees.number_passport, employees.phone,  employees.login, employees.password, specializations.name, positions.name FROM employees JOIN specializations ON employees.specialization = specializations.id JOIN positions ON specializations.position_id = positions.id  WHERE employees.first_name ILIKE @text  OR employees.last_name ILIKE @text OR employees.patronymic ILIKE @text", con))
                {
                    cmd.Parameters.AddWithValue("@text", "%" + text + "%");
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        employeesItem = new ObservableCollection<EmployeeClass>();
                        employeesItem.Clear();
                        while (reader.Read())
                        {
                            employeesItem.Add(new EmployeeClass
                            {
                                id = reader.GetInt32(0),
                                first_name = reader.GetString(1),
                                last_name = reader.GetString(2),
                                patronymic = reader.GetString(3),
                                serial_passport = reader.GetString(4),
                                number_passport = reader.GetString(5),
                                phone = reader.GetString(6),
                                login = reader.GetString(7),
                                password = reader.GetString(8),
                                specispecialization = reader.GetString(9),
                                position = reader.GetString(10),
                            });
                        }
                    }
                }
                employee_lb.ItemsSource = employeesItem;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
