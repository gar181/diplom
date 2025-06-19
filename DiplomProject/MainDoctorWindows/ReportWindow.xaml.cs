using DiplomProject.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        EmployeeClass employeeClass;
        NpgsqlConnection con;
        public ReportWindow(EmployeeClass e)
        {
            InitializeComponent();
            List<string> types_report = new List<string>() { "Аналитические отчёты", "Отчёты по безопасности" };
            type_reports_cmb.ItemsSource = types_report;
            employeeClass = e;
            con = new ConnectionClass().con;
            startDatePicker.SelectedDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            endDatePicker.SelectedDate = startDatePicker.SelectedDate.Value.AddDays(6);
            refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new MenuWindow(employeeClass);
            window.Show();
            this.Close();
        }

        private void type_reports_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> reports = new List<string>();
            reports.Clear();
            switch (type_reports_cmb.SelectedItem)
            {
                case "Аналитические отчёты":
                    reports.Add("Статистика количества приёмов");
                    reports.Add("Статистика используемости кабинетов");
                    break;
                case "Отчёты по безопасности":
                    reports.Add("Статистика количества входов в систему за день");
                    break;
            }
            reports_cmb.ItemsSource = reports;

        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void reports_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (reports_cmb.SelectedValue == "Статистика количества приёмов")
            {
                DateTime startDate = startDatePicker.SelectedDate.Value;
                DateTime endDate = endDatePicker.SelectedDate.Value;
                DataTable table = new DataTable();
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "SELECT employees.last_name, employees.first_name, employees.patronymic, " +
                    "COUNT(first_check.*) FROM employees " +
                    "JOIN first_check ON first_check.employee_id = employees.id " +
                    "WHERE first_check.date BETWEEN @startDate AND @endDate " +
                    "GROUP BY employees.last_name, employees.first_name, employees.patronymic", con))
                {
                    cmd.Parameters.AddWithValue("startDate", startDate);
                    cmd.Parameters.AddWithValue("endDate", endDate.AddDays(1).AddTicks(-1));

                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                    reportDataGrid.ItemsSource = table.DefaultView;
                    reportDataGrid.AutoGenerateColumns = true;
                }
            }
            else if (reports_cmb.SelectedValue == "Статистика используемости кабинетов")
            {
                DateTime startDate = startDatePicker.SelectedDate.Value;
                DateTime endDate = endDatePicker.SelectedDate.Value;
                DataTable table = new DataTable();
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "SELECT rooms.id, rooms.specialization_id, rooms.square, " +
                    "COUNT(first_check.*) as usage_count FROM rooms " +
                    "JOIN first_check ON first_check.room_id = rooms.id " +
                    "WHERE first_check.date BETWEEN @startDate AND @endDate " +
                    "GROUP BY rooms.id, rooms.specialization_id, rooms.square", con))
                {
                    cmd.Parameters.AddWithValue("startDate", startDate);
                    cmd.Parameters.AddWithValue("endDate", endDate.AddDays(1).AddTicks(-1));

                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                    reportDataGrid.ItemsSource = table.DefaultView;
                    reportDataGrid.AutoGenerateColumns = true;
                }
            }
            else if (reports_cmb.SelectedValue == "Статистика количества входов в систему за день")
            {
                DateTime startDate = startDatePicker.SelectedDate.Value;
                DateTime endDate = endDatePicker.SelectedDate.Value;
                DataTable table = new DataTable();
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    "SELECT  employees.last_name, employees.first_name, employees.patronymic, " +
                    "COUNT(log_history.*)  FROM employees " +
                    "JOIN log_history ON log_history.employee_id = employees.id " +
                    "WHERE log_history.date BETWEEN @startDate AND @endDate " +
                    "GROUP BY  employees.last_name, employees.first_name, employees.patronymic", con))
                {
                    cmd.Parameters.AddWithValue("startDate", startDate);
                    cmd.Parameters.AddWithValue("endDate", endDate.AddDays(1).AddTicks(-1));

                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                    reportDataGrid.ItemsSource = table.DefaultView;
                    reportDataGrid.AutoGenerateColumns = true;
                }
            }
        }

        private void type_reports_cmb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
       public void  refresh()
        {
           
        }
    }
}