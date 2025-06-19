using DiplomProject.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

namespace DiplomProject.RegistrationWindows
{
    /// <summary>
    /// Логика взаимодействия для FirstCheckAddEditWindow.xaml
    /// </summary>
    public partial class FirstCheckAddEditWindow : Window
    {
        List<FirstCheckClass> firstCheckItem = new List<FirstCheckClass>();
        NpgsqlConnection con = new NpgsqlConnection();   
        public FirstCheckAddEditWindow()
        {
            InitializeComponent();
            ConnectionClass x = new ConnectionClass();
            con = x.con;
            refresh_cmb();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientsWindow window = new PatientsWindow();
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(employee_cmb.Text) || string.IsNullOrWhiteSpace(patient_cmb.Text) || string.IsNullOrWhiteSpace(room_cmb.Text) || date_dp.SelectedDate == null || string.IsNullOrWhiteSpace(pressure_txb.Text) || string.IsNullOrWhiteSpace(pulse_txb.Text) || string.IsNullOrWhiteSpace(comment_txb.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO first_check (employee_id, patient_id, room_id, date, pressure, pulse, comments) VALUES ((SELECT id FROM employees WHERE first_name = @employee_first AND last_name = @employee_last AND patronymic = @employee_patronymic), (SELECT id FROM patients WHERE first_name = @patient_first AND last_name = @patient_last AND patronymic = @patient_patronymic),@room_id::int4, @date::timestamp, @pressure, @pulse,  @comments)", con))
                    {
                        string[] employee = employee_cmb.Text.Split(' ');
                        string[] patient = patient_cmb.Text.Split(' ');
                        cmd.Parameters.AddWithValue("employee_first", employee[1]);
                        cmd.Parameters.AddWithValue("employee_last", employee[0]);
                        cmd.Parameters.AddWithValue("employee_patronymic", employee[2]);
                        cmd.Parameters.AddWithValue("patient_first", patient[1]);
                        cmd.Parameters.AddWithValue("patient_last", patient[0]);
                        cmd.Parameters.AddWithValue("patient_patronymic", patient[2]);
                        cmd.Parameters.AddWithValue("room_id", room_cmb.SelectedValue);
                        cmd.Parameters.AddWithValue("date", date_dp.SelectedDate.Value);
                        cmd.Parameters.AddWithValue("pressure", pressure_txb.Text);
                        cmd.Parameters.AddWithValue("pulse", pulse_txb.Text);
                        cmd.Parameters.AddWithValue("comments", comment_txb.Text);
                        cmd.ExecuteNonQuery();
                    }
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
        public void refresh_cmb()
        {
            try
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select concat(employees.last_name, ' ',employees.first_name,' ', employees.patronymic) from employees", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        employee_cmb.Items.Clear();
                        while (reader.Read())
                        {
                            employee_cmb.Items.Add(reader.GetString(0));
                        }
                    }
                }
                using (NpgsqlCommand cmd = new NpgsqlCommand("select concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic) from patients", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        patient_cmb.Items.Clear();
                        while (reader.Read())
                        {
                            patient_cmb.Items.Add(reader.GetString(0));
                        }
                    }
                }
                using (NpgsqlCommand cmd = new NpgsqlCommand("select id from rooms", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        room_cmb.Items.Clear();
                        while (reader.Read())
                        {
                            room_cmb.Items.Add(reader.GetInt32(0));
                        }
                    }
                }
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
