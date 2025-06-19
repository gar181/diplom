using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomProject.Classes
{
    public class FirstCheckClass
    {
        public string employeeFullName { get; set; }
        public string patientFullNmae { get; set; }
        public int id { get; set; }
        public int employeeId { get; set; }
        public int patientId { get; set; }
        public int roomId { get; set; }
        public int diagnose_id {  get; set; }
        public DateTime date { get;set;}
        public string pressure {get;set;}
        public string pulse { get;set;}
        public string comments { get;set;}
        public string report { get; set; }
        public string general_status { get; set; }
        public string skin_status { get; set; }
        public string mucous_status { get; set; }
        public string lungs_status { get; set; }
        public string heart_status { get; set; }
        public string tongue_status { get; set; }
        public string stomach_status { get; set; }
        public string urination_status { get; set; }
        public string palatine_status { get; set; }
        public bool complated {  get; set; }
        public string specialization { get; set; }
        public string diagnose_name { get; set;}
    }
}
