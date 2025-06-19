using DiplomProject.Classes;
using DiplomProject.SpecialistWindows.AcceptancePatient;
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
using System.Windows.Shapes;

namespace DiplomProject.RegistrationWindows
{
    /// <summary>
    /// Логика взаимодействия для ConsulationWindow.xaml
    /// </summary>
    public partial class ConsulationWindow : Window
    {
        List<SpecializationClass> specializations = new List<SpecializationClass>();
        EmployeeClass employeeClass;
        bool add;
        FirstCheckClass selectedItem;
        NpgsqlConnection con = new NpgsqlConnection();
        public ConsulationWindow(EmployeeClass e, bool ch, FirstCheckClass sel)
        {
            InitializeComponent();
            ConnectionClass c = new ConnectionClass();
            con = c.con;
            employeeClass = e;
            add = ch;
            selectedItem = sel;
            refresh();
            time_refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AcceptancePatientAddEditWindow window = new AcceptancePatientAddEditWindow(employeeClass, add, selectedItem,null);
            window.Show();
            this.Close();
        }

        private void specialization_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select concat(last_name, ' ', first_name, ' ', patronymic) from employees where specialization = (select id from specializations where name = @name)", con))
                {
                    cmd.Parameters.AddWithValue("name", specialization_cmb.SelectedValue);
                    employees_cmb.Items.Clear();
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees_cmb.Items.Add(reader.GetString(0));
                        }
                    }
                }
                
                patients_txb.Text = selectedItem.patientFullNmae;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Консултация успешно выписана", "Уведосление", MessageBoxButton.OK, MessageBoxImage.Information);
            AcceptancePatientAddEditWindow window = new AcceptancePatientAddEditWindow(employeeClass, add, selectedItem, null);
            window.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        public void refresh()
        {
            try
            {
                specialization_cmb.SelectionChanged -= specialization_cmb_SelectionChanged;
                specialization_cmb.Items.Clear();
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select * from specializations", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            specialization_cmb.Items.Add(reader.GetString(1));
                        }
                    }
                }
                using (NpgsqlCommand cmd = new NpgsqlCommand("select id from rooms", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            room_cmb.Items.Add(reader.GetInt32(0));
                        }
                    }
                }
                patients_txb.Text = selectedItem.patientFullNmae;
                date_dp.SelectedDate = DateTime.Now;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                specialization_cmb.SelectionChanged += specialization_cmb_SelectionChanged;
            }
            
        }
        private void time_refresh()
        {
            TimeSpan start = new TimeSpan(9, 0, 0);  // Начало рабочего дня
            TimeSpan end = new TimeSpan(18, 0, 0);   // Конец рабочего дня
            TimeSpan breakStart = new TimeSpan(13, 0, 0); // Начало перерыва
            TimeSpan breakEnd = new TimeSpan(14, 0, 0);   // Конец перерыва
            TimeSpan interval = new TimeSpan(0, 20, 0);   // Интервал 20 минут

            List<string> timeSlots = new List<string>();

            for (TimeSpan time = start; time <= end; time += interval)
            {
                if (time >= breakStart && time < breakEnd)
                    continue;

                timeSlots.Add(time.ToString(@"hh\:mm"));
            }

            time_cmb.ItemsSource = timeSlots;
        }

        private void employees_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void time_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
