using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal struct HiringDate
    {
        int day, month, year;

        public HiringDate(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public override string ToString()
        {
            return $"{day}-{month}-{year}";
        }
        public int getYear()
        {
            return year;
        }
        public int getDay()
        {
            return day;
        }
        public int getMonth()
        {
            return month;
        }
    }
}
