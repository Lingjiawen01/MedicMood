using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicMood.DataModel
{
    public class Alarm
    {
        public DateTime Time { get; set; }
        public string Label { get; set; }
        public bool IsActive { get; set; }
    }
}
