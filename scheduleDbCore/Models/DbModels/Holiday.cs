using System;

namespace scheduleDbCore.Models
{
    public class Holiday
    {
        public Holiday(string holidayName, DateTime holidayDate)
        {
            HolidayName = holidayName;
            HolidayDate = holidayDate;
        }

        public Holiday() { }


        public int Id { get; set; }

        public DateTime HolidayDate { get; set; }

        public string HolidayName { get; set; }
    }
}
