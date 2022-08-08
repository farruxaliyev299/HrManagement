using HR_Management.Models;
using System.Collections.Generic;

namespace HR_Management.ViewModels
{
    public class HolidayVM
    {
        public List<Holiday> Holidays { get; set; }

        public Holiday Holiday { get; set; }

        public object EditHoliday { get; set; }
    }
}
