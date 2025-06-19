using DiplomProject.Classes;
using DiplomProject.SpecialistWindows.AcceptancePatient;
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

namespace DiplomProject.SpecialistWindows
{
    /// <summary>
    /// Логика взаимодействия для AcceptancePatientWindow.xaml
    /// </summary>
    public partial class AcceptancePatientWindow : Window
    {
        bool add = true;
        public NpgsqlConnection con;
        EmployeeClass employeeClass;
        public ObservableCollection<FirstCheckClass> firstCheckItem { get; set; }
        public List<string> patientItem = new List<string>();
        public List<string> speciallizationItem = new List<string>();
        public AcceptancePatientWindow(EmployeeClass e)
        {
            InitializeComponent();
            ConnectionClass x = new ConnectionClass();
            employeeClass = e;
            con = x.con;
            refresh_cmb();
            patients_cmb_SelectionChanged(null, null);            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new MenuWindow(null);
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add = true;
            AcceptancePatientAddEditWindow window = new AcceptancePatientAddEditWindow(employeeClass, add, null,patients_cmb.SelectedValue);
            window.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (firstCheckListBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите запись!");
                }
                else
                {
                    FirstCheckClass selectedItem = (FirstCheckClass)firstCheckListBox.SelectedItem;
                    add = false;
                    AcceptancePatientAddEditWindow window = new AcceptancePatientAddEditWindow(employeeClass, add, selectedItem,null);
                    window.Show();
                    this.Close();

                }
                
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            
        }

        private void patients_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patients_cmb.SelectedValue != null)
            {
                try
                {
                    string patient = patients_cmb.SelectedValue.ToString();
                    string employee = employeeClass.last_name + " " + employeeClass.first_name + " " + employeeClass.patronymic;
                    con.Close();
                    con.Open();
                    if (ch.IsChecked == true)
                    {
                        using (NpgsqlCommand cmd = new NpgsqlCommand("select concat(employees.last_name, ' ',employees.first_name,' ', employees.patronymic), concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic) , first_check.*, specializations.name, diagnosis.name from first_check join employees on first_check.employee_id = employees.id join patients on first_check.patient_id = patients.id join specializations on employees.specialization = specializations.id join diagnosis on first_check.diagnose_id = diagnosis.id\r\n  where concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic) = @patient and concat(employees.last_name, ' ',employees.first_name,' ', employees.patronymic) = @employee", con))
                        {
                            cmd.Parameters.AddWithValue("patient", patient);
                            cmd.Parameters.AddWithValue("employee", employee);
                            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                            {
                                firstCheckItem = new ObservableCollection<FirstCheckClass>();
                                firstCheckItem.Clear();
                                while (reader.Read())
                                {
                                    firstCheckItem.Add(new FirstCheckClass
                                    {
                                        employeeFullName = reader.GetString(0),
                                        patientFullNmae = reader.GetString(1),
                                        id = reader.GetInt32(2),
                                        employeeId = reader.GetInt32(3),
                                        patientId = reader.GetInt32(4),
                                        roomId = reader.GetInt32(5),
                                        diagnose_id = reader.GetInt32(6),
                                        date = reader.GetDateTime(7),
                                        pressure = reader.GetString(8),
                                        pulse = reader.GetString(9),
                                        general_status = reader.GetString(10),
                                        skin_status = reader.GetString(11),
                                        mucous_status = reader.GetString(12),
                                        lungs_status = reader.GetString(13),
                                        heart_status = reader.GetString(14),
                                        tongue_status = reader.GetString(15),
                                        stomach_status = reader.GetString(16),
                                        urination_status = reader.GetString(17),
                                        palatine_status = reader.GetString(18),
                                        comments = reader.GetString(19),
                                        report = reader.GetString(20),
                                        complated = reader.GetBoolean(21),
                                        specialization = reader.GetString(22),
                                        diagnose_name = reader.GetString(23)
                                    });
                                }
                            }
                        }
                    }
                    else
                    {
                        using (NpgsqlCommand cmd = new NpgsqlCommand("select concat(employees.last_name, ' ',employees.first_name,' ', employees.patronymic), concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic) , first_check.*, specializations.name, diagnosis.name from first_check join employees on first_check.employee_id = employees.id join patients on first_check.patient_id = patients.id join specializations on employees.specialization = specializations.id join diagnosis on first_check.diagnose_id = diagnosis.id where concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic) = @patient", con))
                        {
                            cmd.Parameters.AddWithValue("patient", patient);
                            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                            {
                                firstCheckItem = new ObservableCollection<FirstCheckClass>();
                                firstCheckItem.Clear();
                                while (reader.Read())
                                {
                                    firstCheckItem.Add(new FirstCheckClass
                                    {
                                        employeeFullName = reader.GetString(0),
                                        patientFullNmae = reader.GetString(1),
                                        id = reader.GetInt32(2),
                                        employeeId = reader.GetInt32(3),
                                        patientId = reader.GetInt32(4),
                                        roomId = reader.GetInt32(5),
                                        diagnose_id = reader.GetInt32(6),
                                        date = reader.GetDateTime(7),
                                        pressure = reader.GetString(8),
                                        pulse = reader.GetString(9),
                                        general_status = reader.GetString(10),
                                        skin_status = reader.GetString(11),
                                        mucous_status = reader.GetString(12),
                                        lungs_status = reader.GetString(13),
                                        heart_status = reader.GetString(14),
                                        tongue_status = reader.GetString(15),
                                        stomach_status = reader.GetString(16),
                                        urination_status = reader.GetString(17),
                                        palatine_status = reader.GetString(18),
                                        comments = reader.GetString(19),
                                        report = reader.GetString(20),
                                        complated = reader.GetBoolean(21),
                                        specialization = reader.GetString(22),
                                        diagnose_name = reader.GetString(23)
                                    });
                                }
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
        }
        public void refresh_cmb()
        {
            patientItem.Clear();
            string employee = employeeClass.last_name + " " + employeeClass.first_name + " " + employeeClass.patronymic;
            try
            {
                con.Close();
                con.Open();
                if (ch.IsChecked == false) {
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
                }
                else
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("select distinct(concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic)) from first_check join employees on first_check.employee_id = employees.id join patients on first_check.patient_id = patients.id join specializations on employees.specialization = specializations.id  where concat(employees.last_name, ' ',employees.first_name,' ', employees.patronymic) = @employee", con))
                    {
                        cmd.Parameters.AddWithValue("employee", employee);
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                patientItem.Add(reader.GetString(0));
                            }
                        }
                    }
                }
                patients_cmb.ItemsSource = null;          
                patients_cmb.ItemsSource = patientItem;
                patients_cmb.SelectedIndex = 0;
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

        private void ch_Click(object sender, RoutedEventArgs e)
        {
            refresh_cmb();
            patients_cmb_SelectionChanged(null,null);
        }
    }
}
