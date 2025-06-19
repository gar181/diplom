using DiplomProject.Classes;
using Npgsql;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeClass employeeClass = new EmployeeClass();
        ConnectionClass con;
        NpgsqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            con = new ConnectionClass();
            conn = con.con;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select employees.id, employees.first_name, employees.last_name, employees.patronymic, employees.serial_passport, employees.number_passport, employees.phone, employees.login, employees.password, specializations.name, positions.name from employees join specializations on employees.specialization = specializations.id join positions on specializations.position_id = positions.id where employees.login = @login and employees.password = @password", conn))
                {
                    cmd.Parameters.AddWithValue("@login", login_txb.Text);
                    cmd.Parameters.AddWithValue("@password", password_txb.Password);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            employeeClass.id = reader.GetInt32(0);
                            employeeClass.first_name = reader.GetString(1);
                            employeeClass.last_name = reader.GetString(2);
                            employeeClass.patronymic = reader.GetString(3);
                            employeeClass.serial_passport = reader.GetString(4);
                            employeeClass.number_passport = reader.GetString(5);
                            employeeClass.phone = reader.GetString(6);
                            employeeClass.login = reader.GetString(7);
                            employeeClass.password = reader.GetString(8);
                            employeeClass.specispecialization = reader.GetString(9);
                            employeeClass.position = reader.GetString(10);
                        }
                    }
                }
                using (NpgsqlCommand cmd = new NpgsqlCommand("insert into log_history(employee_id) values (@employeee_id)", conn))
                {
                    cmd.Parameters.AddWithValue("@employeee_id", employeeClass.id);
                    cmd.Parameters.AddWithValue("@password", password_txb.Password);
                    cmd.ExecuteNonQuery();
                }
                switch (employeeClass.position)
                {
                    case "Регистратура":
                        RegistrationWindows.MenuWindow window = new RegistrationWindows.MenuWindow(employeeClass);
                        window.Show();
                        this.Close();
                        break;
                    case "Врач":
                        SpecialistWindows.MenuWindow window1 = new SpecialistWindows.MenuWindow(employeeClass);
                        window1.Show();
                        this.Close();
                        break;
                    case "Главный врач":
                        MainDoctorWindows.MenuWindow window2 = new MainDoctorWindows.MenuWindow(employeeClass);
                        window2.Show();
                        this.Close();
                        break;
                    default:
                        MessageBox.Show("Такого пользователя не существует!", "Ошибка входа",MessageBoxButton.OK,MessageBoxImage.Error);
                        break;
                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
