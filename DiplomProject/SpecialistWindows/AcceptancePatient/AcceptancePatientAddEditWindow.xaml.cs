using DiplomProject.Classes;
using DiplomProject.RegistrationWindows;
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

namespace DiplomProject.SpecialistWindows.AcceptancePatient
{
    /// <summary>
    /// Логика взаимодействия для AcceptancePatientAddEditWindow.xaml
    /// </summary>
    public partial class AcceptancePatientAddEditWindow : Window
    {
        EmployeeClass employeeClass;
        bool add = true;
        NpgsqlConnection con = new NpgsqlConnection();
        public ObservableCollection<FirstCheckClass> firstCheckItem { get; set; }
        public FirstCheckClass selectedItem;
        public object selectPatient;
        public AcceptancePatientAddEditWindow(EmployeeClass e, bool ch, FirstCheckClass select, object selectPatinet)
        {
            InitializeComponent();
            ConnectionClass x = new ConnectionClass();
            employeeClass = e;
            add = ch;
            selectedItem = select;
            selectPatient = selectPatinet;
            con = x.con;
            refresh_cmb();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AcceptancePatientWindow window = new AcceptancePatientWindow(employeeClass);
            window.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(employee_txb.Text) || string.IsNullOrWhiteSpace(patient_txb.Text) || string.IsNullOrWhiteSpace(room_cmb.Text) || date_dp.SelectedDate == null || string.IsNullOrWhiteSpace(pressure_txb.Text) || string.IsNullOrWhiteSpace(pulse_txb.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    if (add) { 
                        using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO first_check (employee_id, patient_id, diagnose_id, room_id, date, pressure, pulse, report, general_status,skin_status,mucous_status,lungs_status,heart_status, tongue_status, stomach_status, urination_status,palatine_status) VALUES ((SELECT id FROM employees WHERE first_name = @employee_first AND last_name = @employee_last AND patronymic = @employee_patronymic), (SELECT id FROM patients WHERE first_name = @patient_first AND last_name = @patient_last AND patronymic = @patient_patronymic),(select id from diagnosis where name = @diagnose),@room_id::int4, @date ::timestamp, @pressure, @pulse, @report, @general_status,@skin_status,@mucous_status,@lungs_status,@heart_status,@tongue_status,@stomach_status,@urination_status,@palatine_status)", con))
                        {
                            string[] employee = employee_txb.Text.Split(' ');
                            string[] patient = patient_txb.Text.Split(' ');
                            cmd.Parameters.AddWithValue("employee_first", employee[1]);
                            cmd.Parameters.AddWithValue("employee_last", employee[0]);
                            cmd.Parameters.AddWithValue("employee_patronymic", employee[2]);
                            cmd.Parameters.AddWithValue("patient_first", patient[1]);
                            cmd.Parameters.AddWithValue("patient_last", patient[0]);
                            cmd.Parameters.AddWithValue("patient_patronymic", patient[2]);
                            cmd.Parameters.AddWithValue("room_id", room_cmb.SelectedValue);
                            cmd.Parameters.AddWithValue("date", date_dp.SelectedDate.Value.Date + TimeSpan.Parse(time_cmb.SelectedValue.ToString()));
                            cmd.Parameters.AddWithValue("pressure", pressure_txb.Text);
                            cmd.Parameters.AddWithValue("pulse", pulse_txb.Text);

                            cmd.Parameters.AddWithValue("report", report_txb.Text);
                            cmd.Parameters.AddWithValue("general_status", general_status_txb.Text);
                            cmd.Parameters.AddWithValue("skin_status", skin_status_txb.Text);
                            cmd.Parameters.AddWithValue("mucous_status", mucous_status_txb.Text);
                            cmd.Parameters.AddWithValue("lungs_status", lungs_status_txb.Text);
                            cmd.Parameters.AddWithValue("heart_status", heart_status_txb.Text);
                            cmd.Parameters.AddWithValue("tongue_status", tongue_status_txb.Text);
                            cmd.Parameters.AddWithValue("stomach_status", stomach_status_txb.Text);
                            cmd.Parameters.AddWithValue("urination_status", urination_status_txb.Text);
                            cmd.Parameters.AddWithValue("palatine_status", palatine_status_txb.Text);
                            cmd.Parameters.AddWithValue("diagnose", diagnosis_cmb.SelectedValue);
                            cmd.ExecuteNonQuery();

                        }
                        MessageBox.Show("Запись успешно добавлена");
                    }
                    else
                    {
                        using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE first_check SET employee_id = (SELECT id FROM employees WHERE first_name = @employee_first AND last_name = @employee_last AND patronymic = @employee_patronymic), patient_id = (SELECT id FROM patients WHERE first_name = @patient_first AND last_name = @patient_last AND patronymic = @patient_patronymic),diagnose_id = (select id from diagnosis where name = @diagnose),room_id = @room_id, date = @date, pressure = @pressure, pulse = @pulse, report = @report, general_status = @general_status, skin_status = @skin_status, mucous_status = @mucous_status, lungs_status = @lungs_status, heart_status = @heart_status, tongue_status = @tongue_status, stomach_status = @stomach_status, urination_status = @urination_status, palatine_status = @palatine_status  WHERE id = @id", con))
                        {
                            string[] employee = employee_txb.Text.Split(' ');
                            string[] patient = patient_txb.Text.Split(' ');
                            cmd.Parameters.AddWithValue("employee_first", employee[1]);
                            cmd.Parameters.AddWithValue("employee_last", employee[0]);
                            cmd.Parameters.AddWithValue("employee_patronymic", employee[2]);
                            cmd.Parameters.AddWithValue("patient_first", patient[1]);
                            cmd.Parameters.AddWithValue("patient_last", patient[0]);
                            cmd.Parameters.AddWithValue("patient_patronymic", patient[2]);
                            cmd.Parameters.AddWithValue("room_id", room_cmb.SelectedValue);
                            cmd.Parameters.AddWithValue("date", date_dp.SelectedDate.Value.Date + TimeSpan.Parse(time_cmb.SelectedValue.ToString()));
                            cmd.Parameters.AddWithValue("pressure", pressure_txb.Text);
                            cmd.Parameters.AddWithValue("pulse", pulse_txb.Text);
                            cmd.Parameters.AddWithValue("id", selectedItem.id);

                            cmd.Parameters.AddWithValue("report", report_txb.Text);
                            cmd.Parameters.AddWithValue("general_status", general_status_txb.Text);
                            cmd.Parameters.AddWithValue("skin_status", skin_status_txb.Text);
                            cmd.Parameters.AddWithValue("mucous_status", mucous_status_txb.Text);
                            cmd.Parameters.AddWithValue("lungs_status", lungs_status_txb.Text);
                            cmd.Parameters.AddWithValue("heart_status", heart_status_txb.Text);
                            cmd.Parameters.AddWithValue("tongue_status", tongue_status_txb.Text);
                            cmd.Parameters.AddWithValue("stomach_status", stomach_status_txb.Text);
                            cmd.Parameters.AddWithValue("urination_status", urination_status_txb.Text);
                            cmd.Parameters.AddWithValue("palatine_status", palatine_status_txb.Text);
                            cmd.Parameters.AddWithValue("diagnose", diagnosis_cmb.SelectedValue);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Запись успешно изменена");
                    }
                    AcceptancePatientWindow window = new AcceptancePatientWindow(employeeClass);
                    window.Show();
                    this.Close();

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
                TimeSpan start = new TimeSpan(9, 0, 0);  // Начало рабочего дня
                TimeSpan end = new TimeSpan(18, 0, 0);   // Конец рабочего дня
                TimeSpan breakStart = new TimeSpan(13, 0, 0); // Начало перерыва
                TimeSpan breakEnd = new TimeSpan(14, 0, 0);   // Конец перерыва
                TimeSpan interval = new TimeSpan(0, 15, 0);   // Интервал 20 минут

                List<string> timeSlots = new List<string>();

                for (TimeSpan time = start; time <= end; time += interval)
                {
                    if (time >= breakStart && time < breakEnd)
                        continue;

                    timeSlots.Add(time.ToString(@"hh\:mm"));
                }

                time_cmb.ItemsSource = timeSlots;
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select concat(employees.last_name, ' ',employees.first_name,' ', employees.patronymic) from employees", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employee_txb.Text = reader.GetString(0);
                        }
                    }
                }
                using (NpgsqlCommand cmd = new NpgsqlCommand("select concat(patients.last_name, ' ',patients.first_name,' ', patients.patronymic) from patients", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                            while (reader.Read())
                            {
                                patient_txb.Text = reader.GetString(0);
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
                using (NpgsqlCommand cmd = new NpgsqlCommand("select name from diagnosis", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        diagnosis_cmb.Items.Clear();
                        while (reader.Read())
                        {
                            diagnosis_cmb.Items.Add(reader.GetString(0));
                        }
                    }
                }
                urination_status_txb.SelectedValue = "Пастозность";
                employee_txb.Text = employeeClass.last_name + " " + employeeClass.first_name + " " + employeeClass.patronymic;
                date_dp.SelectedDate = DateTime.Now;
                if (!add)
                {

                    employee_txb.Text = selectedItem.employeeFullName;
                    specialization_txb.Text = selectedItem.specialization;
                    patient_txb.Text = selectedItem.patientFullNmae;
                    date_dp.SelectedDate = selectedItem.date;
                    room_cmb.SelectedValue = selectedItem.roomId;
                    pressure_txb.Text = selectedItem.pressure;
                    pulse_txb.Text = selectedItem.pulse;
                    report_txb.Text = selectedItem.report;
                    general_status_txb.SelectedValue = selectedItem.general_status;
                    skin_status_txb.SelectedValue= selectedItem.skin_status;
                    mucous_status_txb.SelectedValue = selectedItem.mucous_status;
                    lungs_status_txb.SelectedValue = selectedItem.lungs_status;
                    heart_status_txb.SelectedValue = selectedItem.heart_status;
                    tongue_status_txb.SelectedValue = selectedItem.tongue_status;
                    stomach_status_txb.SelectedValue = selectedItem.stomach_status;
                    urination_status_txb.SelectedValue = selectedItem.urination_status;
                    palatine_status_txb.SelectedValue = selectedItem.palatine_status;
                    diagnosis_cmb.SelectedValue = selectedItem.diagnose_name;
                    TimeSpan currentTime = selectedItem.date.TimeOfDay;
                    time_cmb.SelectedValue = currentTime.ToString(@"hh\:mm");
                }
                else
                {
                    patient_txb.Text = selectPatient.ToString();
                }
                using (NpgsqlCommand cmd = new NpgsqlCommand("select specializations.name from employees join specializations on specializations.id = employees.specialization  where concat(employees.last_name, ' ',employees.first_name,' ', employees.patronymic) = @employee", con))
                {
                    cmd.Parameters.AddWithValue("employee", employee_txb.Text);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            specialization_txb.Text = reader.GetString(0);
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
            List<string> general_status = new List<string>() { "Удовлетворительное", "Средней тяжести", "Тяжёлое" };
            general_status_txb.ItemsSource = general_status;
            List<string> palatine_status = new List<string>() { "Нет", "Пастозностьи", "Отёк нижних конечностей", "Отёк лица" };
            palatine_status_txb.ItemsSource = palatine_status;
            List<string> heart_status = new List<string>() { "Тоны ясные", "Ритмичные", "Приглушены", "Аритмичны" };
            heart_status_txb.ItemsSource = heart_status;
            List<string> lungs_status = new List<string>() { "Дыхание везукулярное", "Жёсткое", "Ослабленное везукулярное", "Сухие хрипы", "Влажные хрипы" };
            lungs_status_txb.ItemsSource = lungs_status;
            List<string> skin_status = new List<string>() { "Обычной окраски", "Чистые", "Бледные", "Желтушные", "Цианотичные" };
            skin_status_txb.ItemsSource = skin_status;
            List<string> mucous_status = new List<string>() { "Розовые", "Бледные", "Гипермированные", "Иктеричные", "Чистые" };
            mucous_status_txb.ItemsSource = mucous_status;
            List<string> tongue_status = new List<string>() { "Чистый", "Влажный", "Сухой", "Обложен налётом" };
            tongue_status_txb.ItemsSource = tongue_status;
            List<string> stomach_status = new List<string>() { "Мягкий", "Безболезненный", "Участвует в акте дыхания", "Обложен налётом", "Не вздут" };
            stomach_status_txb.ItemsSource = stomach_status;
            List<string> urination_status = new List<string>() { "Нет", "Пастозность", "Отёк нижних конечностей", "Отёк лица" };
            urination_status_txb.ItemsSource= urination_status;

        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ConsulationWindow window = new ConsulationWindow(employeeClass, add, selectedItem);
            window.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AnalysisWindow window = new AnalysisWindow(employeeClass, add, selectedItem);
            window.Show();
            this.Close();
        }
    }
}
