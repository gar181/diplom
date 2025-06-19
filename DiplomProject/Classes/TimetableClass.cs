using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace DiplomProject.Classes
{
     public class TimetableClass
    {
        public string FullName {  get; set; }
        public int Id {  get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartTimePause { get; set; }
        public TimeSpan EndTimePause { get; set; }
        public bool Holiday { get; set; }
    }
}
