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

namespace DiplomProject.RegistrationWindows
{    
    public partial class TimetableWindow : Window
    {
        public ObservableCollection<TimetableClass> timetableItem { get; set; }
        List<string> employees = new List<string>();
        EmployeeClass employeeClass;
        ConnectionClass con;
        NpgsqlConnection conn;
        public TimetableWindow(EmployeeClass e)
        {
            InitializeComponent();
            con = new ConnectionClass();
            conn = con.con;
            employeeClass = e;
            refresh_combobox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new MenuWindow(employeeClass);
            window.Show();
            this.Close();
        }

        public void refresh_combobox()
        {
            try
            {
                employees_cmb.Items.Clear();
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select distinct(concat(employees.first_name, ' ', employees.last_name, ' ', employees.patronymic)) from timetable left join employees on employees.id = timetable.employee_id", conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(reader.GetString(0));
                        }
                    }
                }
                employees_cmb.ItemsSource = employees;
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

        private void employees_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            try
            {
                
                string selectedEmployee = employees_cmb.SelectedValue.ToString();
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand($"select concat(employees.first_name, ' ', employees.last_name, ' ', employees.patronymic) as full_name, timetable.*  from timetable join employees on employees.id = timetable.employee_id WHERE CONCAT_WS(' ', employees.first_name, employees.last_name, employees.patronymic) = @full_name", conn)) ///*WHERE CONCAT_WS(' ', employees.first_name, employees.last_name, employees.patronymic) = {timetableListBox.SelectedItem}*/
                {
                    cmd.Parameters.AddWithValue("full_name", selectedEmployee);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        timetableItem = new ObservableCollection<TimetableClass>();
                        timetableItem.Clear();
                        while (reader.Read())
                        {
                            timetableItem.Add(new TimetableClass
                            {
                                FullName = reader.IsDBNull(0) ? "Неизвестно" : reader.GetString(0),
                                Id = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                                Day = reader.IsDBNull(2) ? "Не указан" : reader.GetString(2),
                                StartTime = reader.IsDBNull(4) ? TimeSpan.Zero : reader.GetTimeSpan(4),
                                EndTime = reader.IsDBNull(5) ? TimeSpan.Zero : reader.GetTimeSpan(5),
                                StartTimePause = reader.IsDBNull(6) ? TimeSpan.Zero : reader.GetTimeSpan(6),
                                EndTimePause = reader.IsDBNull(7) ? TimeSpan.Zero : reader.GetTimeSpan(7),
                                Holiday = !reader.IsDBNull(8) && reader.GetBoolean(8)
                            });
                        }
                    }
                }
                timetableListBox.ItemsSource = timetableItem;
            }
            catch (Exception ex)
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
