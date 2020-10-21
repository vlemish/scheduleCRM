using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleDbLayer.Models
{
    public class Holiday
    {
        public int Id { get; set; }

        public DateTime HoldayDate { get; set; }

        public string HolidayName { get; set; }
    }
}
