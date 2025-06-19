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
    public partial class FirstCheckWindow : Window
    {
        public NpgsqlConnection con;
        public ObservableCollection<FirstCheckClass> firstCheckItem { get; set; }
        public List<string> patientItem = new List<string>();
        public List<string> speciallizationItem = new List<string>();
        public FirstCheckWindow()
        {
            
            InitializeComponent();
            ConnectionClass x = new ConnectionClass();
            con = x.con;
            refresh_cmb();
            patients_cmb_SelectionChanged(null,null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new MenuWindow(null);
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void patients_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string employee = patients_cmb.SelectedValue.ToString();
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select concat(employees.last_name, ' ',employees.first_name,' ', employees.patronymic), concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic) , first_check.* from first_check join employees on first_check.employee_id = employees.id join patients on first_check.patient_id = patients.id where concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic) = @employee", con))
                {
                    cmd.Parameters.AddWithValue("employee", employee);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        firstCheckItem = new ObservableCollection<FirstCheckClass>();
                        firstCheckItem.Clear();
                        while (reader.Read())
                        {
                            patientItem.Add(reader.GetString(0));
                            firstCheckItem.Add(new FirstCheckClass
                            {
                                employeeFullName = reader.GetString(0),
                                patientFullNmae = reader.GetString(1),
                                id = reader.GetInt32(2),
                                employeeId = reader.GetInt32(3),
                                patientId = reader.GetInt32(4),
                                roomId = reader.GetInt32(5),
                                date = reader.GetDateTime(6),
                                pressure = reader.GetString(7),
                                pulse = reader.GetString(8),
                                comments = reader.GetString(9),
                            });
                        }
                    }
                }
                firstCheckListBox.ItemsSource = firstCheckItem;

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

        private void specialization_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select name from specializations", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        firstCheckItem = new ObservableCollection<FirstCheckClass>();
                        firstCheckItem.Clear();
                        while (reader.Read())
                        {
                            patientItem.Add(reader.GetString(0));
                            firstCheckItem.Add(new FirstCheckClass
                            {
                                employeeFullName = reader.GetString(0),
                                patientFullNmae = reader.GetString(1),
                                id = reader.GetInt32(2),
                                employeeId = reader.GetInt32(3),
                                patientId = reader.GetInt32(4),
                                roomId = reader.GetInt32(5),
                                date = reader.GetDateTime(6),
                                pressure = reader.GetString(7),
                                pulse = reader.GetString(8),
                                comments = reader.GetString(9),
                            });
                        }
                    }
                }
                firstCheckListBox.ItemsSource = firstCheckItem;

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
        public void refresh_cmb()
        {
            try
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic) from patients", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())   
                    {
                        while (reader.Read())
                        {
                            patientItem.Add(reader.GetString(0));
                        }
                    }
                }
                using (NpgsqlCommand cmd = new NpgsqlCommand("select * from specializations", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           speciallizationItem.Add(reader.GetString(1));
                        }
                    }
                }
                patients_cmb.ItemsSource = patientItem;
                specialization_cmb.ItemsSource = speciallizationItem;

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
