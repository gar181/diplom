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
using System.Windows.Shapes;

namespace DiplomProject.SpecialistWindows.AcceptancePatient
{
    /// <summary>
    /// Логика взаимодействия для AnalysisWindow.xaml
    /// </summary>
    public partial class AnalysisWindow : Window
    {
        List<SpecializationClass> specializations = new List<SpecializationClass>();
        EmployeeClass employeeClass;
        bool add;
        FirstCheckClass selectedItem;
        NpgsqlConnection con = new NpgsqlConnection();
        public AnalysisWindow(EmployeeClass e, bool ch, FirstCheckClass sel)
        {
            InitializeComponent();
            ConnectionClass c = new ConnectionClass();
            con = c.con;
            employeeClass = e;
            add = ch;
            selectedItem = sel;
            refresh();
        }

        private void analysis_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void room_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        public void refresh()
        {
            try
            {
                analysis_cmb.Items.Clear();
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("select * from specializations", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            analysis_cmb.Items.Add(reader.GetString(1));
                        }
                    }
                }
                using (NpgsqlCommand cmd = new NpgsqlCommand("select id from rooms", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            room_cmb.Items.Add(reader.GetString(0));
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
    }
}
